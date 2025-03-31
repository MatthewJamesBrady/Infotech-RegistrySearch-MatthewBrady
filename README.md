## Notes on Infotech

The front end is a VUE.JS app in options style.
The back end is a web api with a data layer and a core layer in the clean archtiecture propesed by Microsoft in the eShopOnX series and their architecture guide pdfs.

I couldn't get the HttpClient to work with GoogleSearch as it kept bringing up the CAPTCHA page.  Hence I had to use Playwrigth.  The user has to solve the captchas in 60s which is about right as some of the google ones are very blurry and repitive to solve. 
But I avoided the use of third party parsing.  

For Bing this only happened the first time so by saving the consent cookies I may be able to use HttpClient but i didnt have time.  I believe the code can be refactored.

I was trying to use composition in a pipeline of steps, e.g. download from page, parse page .  I think this may have got muddled but I would refactor this.



Notes for improvement.

I need clarity on what you mean by a link.  I defined it as an organic search link so I precluded ads, news, vidoes.  This did seem to align with my intuition as by setting num as say 10 in the query string i did see 10 organic results.  Also my output strings of e.g. 3, 4 matched what i counted on screen.

I wasn't aware Microsoft had removed Swagger in .NET 9 so I lost some time trying to figure out why it had dissappeared.  I readded it, even though I know there is a new tool for openapi but I was unfamiliar with it so I removed it for time.

There is already a class by Microsoft called SearchResult hence why I called results SearchResults to avoid name clashes.

I've tried to create a rich domain model layer, but I didn't have time to fully implement creator methods hence why there are annoying SearchPhrase() everywhere but i would refactor this to factory methods etc so the domain model inards aren't leaking.

### Installation

use entity migrations. uses the defaul db

![Screenshot 2025-03-31 132432](Screenshot%202025-03-31%20132432.png)

Run in https profile in visual studio.

