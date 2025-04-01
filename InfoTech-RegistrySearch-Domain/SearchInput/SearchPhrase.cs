using System.Net;
using System.Web;

namespace InfoTrack_RegistrySearch_Domain.SearchInput;

public record SearchPhrase
{
    public string Phrase { get; set; }

    public SearchPhrase()
    {
        
    }

    public SearchPhrase(string phase)
    {
        if (string.IsNullOrWhiteSpace(phase))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(phase));

        var parsedPhrase = HttpUtility.UrlEncode(phase);
        this.Phrase = parsedPhrase;
    }
}