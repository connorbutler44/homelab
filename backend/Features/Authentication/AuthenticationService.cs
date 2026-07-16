using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Homelab.Features.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly AuthenticationOptions _options;
    private readonly PasswordHasher<object> _hasher = new();

    public AuthenticationService(IOptions<AuthenticationOptions> options)
    {
        _options = options.Value;
    }


    /// <summary>
    /// Simple authorization check for a single configured username and password
    /// since this application will only be used by me. It will be running behind
    /// tailscale, so a more extensive solution isn't necessary. This is just a sanity
    /// check in case someone gets access to my device or something
    /// </summary>
    public bool ValidateCredentials(string username, string password)
    {
        if (username != _options.Username)
        {
            return false;
        }

        return _hasher.VerifyHashedPassword(
            null!,
            _options.PasswordHash,
            password)
            == PasswordVerificationResult.Success;
    }
}