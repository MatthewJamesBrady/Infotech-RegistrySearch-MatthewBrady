namespace InfoTrack_RegistrySearch_Domain.HtmlParser;

public interface IPageDownloader
{
    string? DownloadPage(string url, string searchengine, bool usePlaywright);
}