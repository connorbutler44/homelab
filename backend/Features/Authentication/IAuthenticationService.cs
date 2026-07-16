namespace Homelab.Features.Authentication;

public interface IAuthenticationService
{
    bool ValidateCredentials(string username, string password);
}