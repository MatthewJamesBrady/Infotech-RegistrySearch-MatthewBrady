namespace Infotrack_RegistrySearch_MatthewBrady.Server.ViewModels;

public class SearchWeeklyHistoryViewModel
{
    public string SearchEngine { get; set; }
    public string SearchPhrase { get; set; }
    public string Url { get; set; }
    public DateOnly WeekStart { get; set; }
    public int Count { get; set; }
}