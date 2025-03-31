namespace InfoTech_Data.SearchResultsData
{
    public class SearchResultsEntity
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Phrase { get; set; }

        public string SearchEngineUrl { get; set; }

        public int Count { get; set; }

        public DateOnly RetirevalDate { get; set; }
    }
}
