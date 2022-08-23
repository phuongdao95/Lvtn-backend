

namespace Services.Contracts
{
    public interface IAiService
    {
        void UploadImage(string name, string data, string localPath);
    }
}
