using OplossingPublishers.Models;

namespace OplossingPublishers.Data.Repository
{
    public interface IStoresRepository
    {
        public List<Store> OphalenStoresViaStaat(string stad);

        public List<Store> OphalenStoresViaNaam(string naam);

        public List<Store> OphalenStoresViaNaamEnStaat(string naam, string stad);

        public Store OphalenStoreViaId(int id);

        public List<Store> OphalenStoresViaNaamEnAdres(string naam, string zip, string city);
    }
}