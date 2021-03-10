using TheMonarchsApi.DTO;

namespace TheMonarchsApi.Interface
{
    public interface IFileService
    {
        int GetMonarchesTotalNumber();
        Monarch LongestMonarchRuled();
        string LongestHouseRuled();
        string MostCommonName();
    }
}
