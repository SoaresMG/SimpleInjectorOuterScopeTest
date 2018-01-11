namespace Connector.SDK.ViewModels.Files
{
    public class FileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public byte[] Binary { get; set; }
    }
}