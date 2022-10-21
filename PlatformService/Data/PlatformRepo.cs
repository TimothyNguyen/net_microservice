using PlatformService.Models;

namespace PlatformService.Data 
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        // We already registered it in AppDBContext
        public PlatformRepo(AppDbContext context) {
            _context = context;
        }

         public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.Platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform? GetPlatformById(int id)
        {
            var platforms = _context.Platforms;
            _ = platforms ?? throw new ArgumentNullException(nameof(platforms));
            return platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}