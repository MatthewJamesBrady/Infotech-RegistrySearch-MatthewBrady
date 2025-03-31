namespace Infotech_RegistrySearch_MatthewBrady.Server.Requests;

public class DailyHistoryQuery
{
    public string Phrase { get; set; }
    public string Engine { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}