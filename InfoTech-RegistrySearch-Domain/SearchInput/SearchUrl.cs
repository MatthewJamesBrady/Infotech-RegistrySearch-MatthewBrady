namespace InfoTech_RegistrySearch_Domain.SearchInput
{
    public class SearchUrl
    {
        public SearchUrl(string url)
        {
            this.Url = new Uri(url);
        }

        public SearchUrl()
        {
            
        }

        public Uri Url { get; set; }
    }
}
