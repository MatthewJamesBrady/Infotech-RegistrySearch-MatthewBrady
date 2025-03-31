## Notes on Infotech

The front end is a VUE.JS app in options style.
The back end is a web api with a data layer and a core layer in the clean archtiecture propesed by Microsoft in the eShopOnX series and their architecture guide pdfs.

I couldn't get the HttpClient to work with GoogleSearch as it kept bringing up the CAPTCHA page.  Hence I had to use  
But I avoided the use of third party parsing.  

For Bing this only happened the first time so by saving the consent cookies I may be able to use HttpClient but 

Notes for improvement.

I need clarity on what you mean by a link.  I defined it as an organic search link so I precluded ads, news, vidoes.  This did seem to align with my intuition as by setting num as say 10 in the .  Also my output strings of e.g. 3, 4 matched what i counted on screen.

I wasn't aware Microsoft had removed Swagger in .NET 9 so I lost some time trying to figure out why it had dissappeared.  I readded it, even though I know there is a new tool for openapi but I was unfamiliar with it so I removed it for time.

