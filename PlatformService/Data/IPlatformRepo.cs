using PlatformService.Models;

namespace PlatformService.Data 
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        // Should get all platforms
        IEnumerable<Platform> GetAllPlatforms(); 
        Platform? GetPlatformById(int id);
        void CreatePlatform(Platform plat);
    }
}