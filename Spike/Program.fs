open canopy.runner.classic
open canopy.configuration
open canopy.classic
open canopy.types
open canopy.reporters

compareTimeout <- 10.0
elementTimeout <- 10.0
pageTimeout <- 10.0
autoPinBrowserRightOnLaunch <- false
failFast := true

reporter <- new JUnitReporter("./TestResults.xml") :> IReporter

chromeDir <- System.AppDomain.CurrentDomain.BaseDirectory
start ChromeHeadless

resize (1920, 1080)

context ("Sky News test run")
"Search and check it's been searched" &&& fun _ ->
    url "https://news.sky.com/uk"
    ".sdc-news-header__search-input" << "technology"
    press enter
    "h1" == "Search Results"

"Check if title is correct" &&& fun _ ->
    let thisTitle = title().Trim()
    thisTitle === "Search Results"

"Checked if main content area is shown" &&& fun _ ->
    click ".sdc-news-listing__link"
    displayed ".sdc-news-story-article"

run()

quit()