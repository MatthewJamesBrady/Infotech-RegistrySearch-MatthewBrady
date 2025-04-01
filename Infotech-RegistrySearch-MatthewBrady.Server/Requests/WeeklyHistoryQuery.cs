namespace Infotrack_RegistrySearch_MatthewBrady.Server.Requests;

public class WeeklyHistoryQuery
{
    public string Phrase { get; set; }
    public string Engine { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}