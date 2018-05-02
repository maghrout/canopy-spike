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

context ("Plumbs test run")
"Search and check it's been searched" &&& fun _ ->
    url "https://www.plumbs.co.uk/"
    click "#search_toggle"
    "#search_drop_down" << "covers"
    press enter
    "h1.red" == "Search"

"Check if title is correct" &&& fun _ ->
    let thisTitle = title().Trim()
    thisTitle === "Search | Plumbs"

"Checked if main content area is shown" &&& fun _ ->
    click ".search-new li a"
    displayed ".main_content_area"

run()

quit()