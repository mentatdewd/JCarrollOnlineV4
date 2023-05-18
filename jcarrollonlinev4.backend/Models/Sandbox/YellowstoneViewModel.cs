namespace jcarrollonlinev4.backend.Models.Sandbox
{
    public class YellowstoneModel : ModelBase
    {
        private readonly List<ImageFileMetadata> _imageFiles = new List<ImageFileMetadata>();

        public IEnumerable<ImageFileMetadata> ImageFiles => _imageFiles;

        public void AddImageFile(ImageFileMetadata imageFileMetadata)
        {
            _imageFiles.Add(imageFileMetadata);
        }
    }
}
