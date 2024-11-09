namespace KRM_Events_API.Dtos.Account
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }   

        public bool isSuccess { get; set; }

        public string Message { get; set; } 
    }
}
