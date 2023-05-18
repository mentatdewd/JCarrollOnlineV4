namespace jcarrollonlinev4.backend.Models.Micropost
{
    public class MicropostFeedModel : MicropostModelBase
    {
        public MicropostFeedModel()
        {
            MicroPostFeedItems = new List<MicropostFeedItemModel>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<MicropostFeedItemModel> MicroPostFeedItems { get; set; }
        //public IPagedList<MicroPostFeedItemModel> OnePageOfMicroPosts { get; set; }
    }
}
