/*
 * Interface en repository
Voorzie een interface en repository voor de tabel Store. Volgende methodes moeten aanwezig zijn:

public List<Store> OphalenStoresViaStaat(string staat);
public List<Store> OphalenStoresViaNaam(string naam);
public List<Store> OphalenStoresViaNaamEnStaat(string naam, string staat);
public Store OphalenStoreViaId(int id);
 */
using OefeningPublishers.Models;

namespace OefeningPublishers.Data.Repository
{
    public interface IStore
    {
        public List<Store> OphalenStoresViaStaat(string staat);
        public List<Store> OphalenStoresViaNaam(string naam);
        public List<Store> OphalenStoresViaNaamEnStaat(string naam, string staat);
        public Store OphalenStoreViaId(int storeID);
    }
}
