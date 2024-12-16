namespace ContractorDocuments.Application.Users.Models
{
    public partial record UserAuthTokenModel
    {
        public string Token { get; set; } = string.Empty;
        public string TokenExpireAt { get; set; } = string.Empty;
    }

    public partial record UserAuthTokenModel
    {
        public string RefreshToken { get; set; } = string.Empty;
        public string RefreshTokenExpireAt { get; set; } = string.Empty;
    }
}