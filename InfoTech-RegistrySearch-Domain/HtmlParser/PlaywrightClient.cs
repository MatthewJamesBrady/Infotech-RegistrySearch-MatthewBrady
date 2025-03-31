using System.ComponentModel.DataAnnotations;
using Microsoft.Playwright;

public class ClientCreator
{
    public static string ScrapeWebsite(string url, string searchengine)
    {
        var playwright = Playwright.CreateAsync().Result;
        var browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }).Result;


        BrowserNewContextOptions contextOptions = new BrowserNewContextOptions();
        if (File.Exists(searchengine + "_storage.json"))
        {
            contextOptions.StorageStatePath = searchengine + "_storage.json";
        }
        var context = browser.NewContextAsync(contextOptions).Result;
        var page =  context.NewPageAsync().Result;

        page.GotoAsync(url);

        var wait = page.GotoAsync(url, new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        }).Result;


        if (searchengine.ToLower() == "bing")
        {
            Thread.Sleep(10 * 1000);
        }

        if (searchengine.ToLower() == "google")
        {
            Thread.Sleep(60 * 1000);
        }
       
        // Save cookies
        var storage =  context.StorageStateAsync().Result;
        // this needs to be fixed for google
        File.WriteAllText("bing_storage.json", storage);
        //try
        //{

        //    var acceptButton = page.QuerySelectorAsync("#bnp_btn_accept").Result;
        //    if (acceptButton != null)
        //    {
        //        acceptButton.ClickAsync();
        //        Console.WriteLine("Accepted cookies.");
        //        page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        //    }

        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //}
    

    // Wait for search results to load

    if (searchengine.ToLower() == "bing")
    {
        var algoresult = page.WaitForSelectorAsync("li.b_algo").Result;
    }
    else if (searchengine.ToLower() == "google")
    {
       // var googleResult = page.WaitForSelectorAsync("div.g").Result;
        }
        
    var content = page.ContentAsync().Result;
        return content;
    } 
}


