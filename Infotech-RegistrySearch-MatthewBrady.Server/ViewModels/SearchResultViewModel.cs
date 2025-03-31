namespace Infotech_RegistrySearch_MatthewBrady.Server.ViewModels
{
    public class SearchResultViewModel
    {
        public string SearchEngine { get; set; }

        public string SearchPhrase { get; set; }

        public string Url { get; set; }

        public string FormattedOutput { get; set; }

        public int Count { get; set; }
        public DateOnly Date { get; set; }
    }
}
