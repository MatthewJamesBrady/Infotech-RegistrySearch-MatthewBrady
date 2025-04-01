namespace InfoTrack_RegistrySearch_Domain.Trends;

public class SearchWeeklyHistory
{
    public string SearchEngine { get; set; }

    public string SearchPhrase { get; set; }

    public string Url { get; set; }

    public int Count { get; set; }

    public DateOnly WeekStart { get; set; }

        
}