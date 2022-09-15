

namespace Services.Contracts
{
    public interface IAiService
    {
        bool UploadImage(string name, string[] listData, string localPath);
        bool RegisterImage(string name, string[] listData, string localPath);
    }
}
