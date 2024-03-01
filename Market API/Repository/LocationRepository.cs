using Market_API.Data;
using Market_API.Interface;
using Market_API.Models;

namespace Market_API.Repository
{
    public class LocationRepository : ILocationRepository
    {
        //Date Context//
        private readonly DataContext _context;

        public LocationRepository(DataContext context)
        {
            _context = context;
        }

        //Check the Location Exists//
        public bool LocationExists(int Id)
        {
            return _context.Location.Any(l => l.LocationId == Id);
        }
        public bool LocationExists(string name)
        {
            return _context.Location.Any(l => l.LocationName == name);
        }

        //Save//
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        //Create Method//
        public bool CreateLocaiton(Location location)
        {
            _context.Add(location);
            return Save();
        }

        //Read Method//
        public ICollection<Location> GetLocaitons()
        {
            return _context.Location.ToList();
        }
        public Location GetLocaiton(int Id)
        {
            return _context.Location.Where(l => l.LocationId == Id).FirstOrDefault();
        }
        public Location GetLocation(string name)
        {
            return _context.Location.Where(l => l.LocationName == name).FirstOrDefault();
        }
        public Location GetLocationByPhone(int phone)
        {
            return _context.Location.Where(l => l.LocationPhone == phone).FirstOrDefault();
        }

        //Update Method//
        public bool UpdateLocation(Location location)
        {
            _context.Update(location);
            return Save();
        }

        //Delete Method//
        public bool DeleteLocaiton(Location location)
        {
            _context.Remove(location);
            return Save();
        }
    }
}
