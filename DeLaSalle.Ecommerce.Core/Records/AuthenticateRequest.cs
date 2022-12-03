namespace DeLaSalle.Ecommerce.Core.Records
{
    public record struct AuthenticateRequest(string UserName, string Password);
}