namespace Core.ViewModels
{
    public class LoginResponse
    {
        public bool IsSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; } 
    }
}
