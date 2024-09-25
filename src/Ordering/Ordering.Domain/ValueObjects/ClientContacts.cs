namespace Ordering.Domain.ValueObjects;
public record ClientContacts
{
    private string? _fullName;
    private string? _email;
    private string? _phoneNumber;

    public string? FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Any(char.IsDigit))
                return;

            _fullName = value.Trim();
        }
    }

    public string? Email
    {
        get => _email;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            _email = value;
        }
    }

    public string? PhoneNumber
    {
        get => _phoneNumber;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            _phoneNumber = value;
        }
    }

    public Uri SocialUrl { get; init; }

    public ClientContacts(string fullName, string email, string phoneNumber, Uri socialUrl)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        SocialUrl = socialUrl;
    }
}
