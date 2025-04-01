## Notes on Infotech

The front end is a VUE.JS app in options style.
The back end is a web api with a data layer and a core layer in the clean arch proposed by Microsoft in the eShopOnX series and their architecture guide pdfs.

I couldn't get the HttpClient to work with GoogleSearch as it kept bringing up the CAPTCHA page.  Hence I had to use Playwright.  The user has to solve the captchas in 60s which is about right as some of the google ones are very blurry and difficult to solve. 
But I avoided the use of third party parsing.  

For Bing this only happened the first time so by saving the consent cookies I may be able to use HttpClient but i didn't have time.  I believe the code can be refactored.

I was trying to use composition in a pipeline of steps, e.g. download from page, parse page .  I think this may have got muddled but I would refactor this.



Notes for improvement.

I need clarity on what you mean by a link.  I defined it as an organic search link so I precluded ads, news, vidoes.  This did seem to align with my intuition as by setting num as say 10 in the query string i did see 10 organic results.  Also my output strings of e.g. 3, 4 matched what i counted on screen.

On bing, not sure if I should include the 'main header' link.
There is a bug where sometimes the bing page is blank.  This is probably to do with the user agent settings but I haven't confirmed.



There is already a class by Microsoft called SearchResult hence why I called results SearchResults to avoid name clashes.

I've tried to create a rich domain model layer, but I didn't have time to fully implement creator methods hence why there are annoying SearchPhrase() everywhere but i would refactor this to factory methods etc so the domain model inards aren't leaking.

### Installation

use entity migrations. uses the default db

![Screenshot 2025-03-31 132432](Screenshot%202025-03-31%20132432.png)

Run in https profile in visual studio. with the server project set as startup project.  the client app should load into a command window and you can copy the url into a new chrome window.  if the client doesnt open run 'npm run dev' in the client folder.

Here's the flow below, copy the url that pops up into a new chrome window.

![Screenshot 2025-03-31 233122](Screenshot%202025-03-31%20233122.png)

![Screenshot 2025-04-01 093909](Screenshot%202025-04-01%20093909.png)

There's a scripted version of the db if the migrations don't work.

![Screenshot 2025-04-01 094152](Screenshot%202025-04-01%20094152.png)

![Screenshot 2025-04-01 094222](Screenshot%202025-04-01%20094222.png)

![Screenshot 2025-04-01 094311](Screenshot%202025-04-01%20094311.png)

![Screenshot 2025-04-01 094351](Screenshot%202025-04-01%20094351.png)

![Screenshot 2025-04-01 094425](Screenshot%202025-04-01%20094425.png)

![Screenshot 2025-04-01 094454](Screenshot%202025-04-01%20094454.png)

![Screenshot 2025-04-01 094505](Screenshot%202025-04-01%20094505.png)

![Screenshot 2025-04-01 094515](Screenshot%202025-04-01%20094515.png)

