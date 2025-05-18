namespace NewmarkIndia.BusinessLogic.Classes
{
    public class BlobReponse
    {
        public string? PropertyId { get; set; }
        public string? PropertyName { get; set; }
        public IEnumerable<string>? Features { get; set; }
        public IEnumerable<string>? Highlights { get; set; }
        public IEnumerable<Transportation>? Transportation { get; set; }
        public IEnumerable<Space>? Spaces { get; set; }
    }
}
