namespace Ordering.Domain.ValueObjects;
public class ClientContacts
{
    public string? FullName { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public Uri SocialUrl { get; private set; }

    public ClientContacts(string fullName, string email, string phoneNumber, Uri socialUrl)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        SocialUrl = socialUrl;
    }

    public void UpdateFullName(string? fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName) || fullName.Any(char.IsDigit))
            return;

        FullName = fullName.Trim();
    }

    public void UpdateEmail(string? email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return;

        Email = email;
    }

    public void UpdatePhoneNumber(string? phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return;

        PhoneNumber = phoneNumber;
    }

    public void UpdateSocialUrl(Uri socialUrl)
    {
        SocialUrl = socialUrl;
    }
}
