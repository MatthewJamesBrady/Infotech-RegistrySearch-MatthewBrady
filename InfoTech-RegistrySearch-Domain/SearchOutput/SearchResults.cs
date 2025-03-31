using System.Runtime.CompilerServices;
using System.Text;
using InfoTech_RegistrySearch_Domain.SearchInput;

namespace InfoTech_RegistrySearch_Domain.SearchOutput;

public class SearchResults
{
    #region Input

    public SearchUrl Url { get; set; } 

    public SearchPhrase Phrase { get; set; }

    public string SearchEngineUrl { get; set; }

    public int Count { get; set; }

    #endregion

    public DateOnly RetirevalDate { get; set; }

    public List<SearchResultLine> SearchResultLines { get; init; } = [];

    public SearchResults()
    {
            
    }

    public void AddLineNumber(int lineNumber, string content)
    {
        this.SearchResultLines.Add(new SearchResultLine { LineNumber = lineNumber, Content = content });
        this.UpdateCount();
    }

    public int UpdateCount()
    {
        this.Count = this.SearchResultLines.Count;
        return this.SearchResultLines.Count;
    }

    public string ProduceFormattedOutput()
    {
        var output = new StringBuilder();
        if (SearchResultLines.Count == 0 )
        {

            output.Append('0');
            return output.ToString();
        }

        for (var index = 0; index < SearchResultLines.Count; index++)
        {
            var searchResultLine = SearchResultLines[index];
            output.Append(searchResultLine.LineNumber);
            if (index == SearchResultLines.Count - 1)
            {
                break;
            }
            output.Append(',');
        }

        return output.ToString();
    }
}