using TheMonarchsApi.DTO;

namespace TheMonarchs.Services.Interfaces
{
    public interface IFileService
    {
        int GetMonarchesTotalNumber();
        Monarch LongestMonarchRuled();
        string LongestHouseRuled();
        string MostCommonName();
    }
}
