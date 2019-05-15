namespace CasePortal.ViewModel
{
    public class MediaViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int Type { get; set; }
        public string TypeName => Type == 1 ? "Video" : "Audio";
        public int LogId { get; set; }
        public string Name { get; set; }
    }
}