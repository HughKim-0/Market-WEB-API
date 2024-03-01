using Market_API.Models;

namespace Market_API.Interface
{
    public interface ILocationRepository
    {
        bool LocationExists(int Id);
        bool LocationExists(string name);
        bool Save();
        bool CreateLocaiton(Location location);
        ICollection<Location> GetLocaitons();
        Location GetLocaiton(int Id);
        Location GetLocation(string name);
        Location GetLocationByPhone(int phone);
        bool UpdateLocation(Location location);
        bool DeleteLocaiton(Location location);
    }
}
