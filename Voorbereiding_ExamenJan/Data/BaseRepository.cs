namespace Voorbereiding_ExamenJan.Data
{
    public abstract class BaseRepository
    {
        protected string ConnectionString { get; }

        public BaseRepository()
        {
            ConnectionString = DatabaseConnection.Connectionstring("OrdersConnectionString");
        }
    }
}
