namespace KRM_Events_API.Dtos.Event
{
    public class AcceptEventRequestDTO
    {
        public bool status {  get; set; }

        public string? message { get; set; } = string.Empty;
    }
}
