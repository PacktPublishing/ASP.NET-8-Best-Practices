# Chapter 10 - Performance

## Additional Material

There is always something more to do to squeeze performance out of an application.

The chapter covers what some would call "quick wins". The chapter was a great introduction for some to dig into these techniques whether the developer was a frontend or backend developer.

Buck's Coffee Shop was intentionally created with a before/after to show the optimizations throughout the chapter applied to the original site. With every optimization added, there was always two more to mention or discuss.

The checklist below gives a more thorough list of optimizations a web developer and/or designer (or <a href="https://www.danylkoweb.com/Blog/can-web-developers-put-lipstick-on-a-pig-KI" title="Go to ">devigner</a> as I call them) can implement when optimizing a website.

- General
  - [ ] Turn off Debug in your configuration and use Release
  - [ ] Reduce redirects
  - [ ] Shorten the TTFB (Time To First Byte). This deals with your Internet connection.
  - [ ] Use async/await for asynchronous calls
  - [ ] Use server GZip/Compression
  - [ ] Gauge Server Response Time; If using a hosting provider, it may be time to move off of shared-hosting and going with a dedicated server (or a new hosting provider altogether)
- Entity Framework Core
  - [ ] Know when Entity Framework is calling the database; deferred execution.
  - [ ] Minimize Database calls
  - [ ] Use AsNoTracking() for simple SQL calls
  - [ ] Utilize DbContextPool
  - [ ] Use Stored Procedures where it makes sense
  - [ ] (optional) Using CompiledQuery where applicable
- Caching
  - [ ] Cache Static Assets
  - [ ] Cache Pages
  - [ ] Cache Data
  - [ ] Use ETags
  - [ ] Pre-fetching images
- Client Optimization
  - [ ] Bundle JavaScript and CSS (TaskRunner)
  - [ ] Minimize JavaScript and CSS (TaskRunner)
  - [ ] Minimize HTML (TaskRunner)
  - [ ] Minimize requests
  - [ ] Use a CDN
  - [ ] Use Sprites for your images
  - [ ] Optimize images
  - [ ] Define image dimensions in HTML
  - [ ] Create static images based on size rather than resizing dynamically
  - [ ] Location, Location, Location: Always place JavaScript at bottom and CSS files at top
  - [ ] If you have to use web fonts, only use a maximum of two
  - [ ] Use async in your HTML tags for non-blocking files (i.e. <script async ...> and webfonts)
  - [ ] Define your "Above the Fold" content and CSS on the main page. Add the "above the fold" CSS as inline to immediately display the page for the user.
  - [ ] If building a public website, limit your JavaScript Frameworks; Only use what you need.
  - [ ] Avoid adding large amounts of third-party JavaScript (Google Analytics, BuyMeACoffee, AddThis, etc). Pick-and-choose your most important scripts.
  - [ ] Use lazy loading of media on-demand as opposed to loading all at once

While this is by no means the exhaustive list for optimizations, one or two of these techniques should "move the needle" for website optimizations.

Code on, devs...code on!

-JD