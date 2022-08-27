

namespace Services.Contracts
{
    public interface IAiService
    {
        bool UploadImage(string name, string data, string localPath);
        bool RegisterImage(string name, string data, string localPath);
    }
}
