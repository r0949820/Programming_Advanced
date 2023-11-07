using MonkeyFinder.Services;
namespace MonkeyFinder.ViewModel;

public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;

    public ObservableCollection<Monkey> Monkeys { get; } = new();

    IConnectivity connectivity;
    IGeolocation geolocation;

    public MonkeysViewModel(MonkeyService monkeyService, IConnectivity connectivity, IGeolocation geolocation)
    {
        Title = "Monkey Finder";
        this.monkeyService = monkeyService;
        this.connectivity = connectivity;
        this.geolocation = geolocation;
    }

    [RelayCommand]
    async Task GetClosestMonkey()
    {
        if (IsBusy || Monkeys.Count == 0)
        {
            return;
        }

        try
        {
            var location = await geolocation.GetLastKnownLocationAsync();
            if (location == null)
            {
                location = await geolocation.GetLocationAsync(
                    new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30),
                    });
            }

            if (location is null)
            {
                return;
            }

            var first = Monkeys.OrderBy(m =>
                    location.CalculateDistance(m.Latitude, m.Longitude, DistanceUnits.Kilometers)).FirstOrDefault();

            if (first is null)
            {
                return;
            }

            await Shell.Current.DisplayAlert("Closest Monkey", $"{first.Name} in {first.Location}", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get closest monkey: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }

    [RelayCommand]
    async Task GoToDetailsAsync(Monkey monkey)
    {
        if (monkey is null)
        {
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true,
            new Dictionary<string, object>
            {
                {"Monkey", monkey }
            });
    }

    [RelayCommand]
    async Task GetMonkeysAsync()
    {
        if (IsBusy)
        {
            return;
        }

        try
        {
            if (connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine($"Check your internet and try again!");
                await Shell.Current.DisplayAlert("Error!", "Internet isseu", "OK");
                return;
            }

            IsBusy = true;
            var monkeys = await monkeyService.GetMonkeys();

            if (monkeys.Count != 0)
            {
                Monkeys.Clear();

                foreach (var monkey in monkeys)
                {
                    Monkeys.Add(monkey);
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
