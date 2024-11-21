namespace KRM_Events_API.Helpers
{
    public class EventQueryObject
    {
        public string? AnnouncerId { get; set; } = string.Empty;
        public string? CategoryName { get; set; } = string.Empty;

        public string? HashtagName {  get; set; } = string.Empty;
        public string? City {  get; set; } = string.Empty;
        public string? SortedBy { get; set; } = null;

        public bool IsDesc { get; set; } = false;
    }
}
