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

context ("Google test run")
"Search for facebook" &&& fun _ ->
    url "https://www.google.co.uk/"
    "#lst-ib" << "facebook"
    press enter
    "h3" == "Facebook – log in or sign up"

"Check if title is correct" &&& fun _ ->
    let thisTitle = title().Trim()
    thisTitle === "Search | Plumbs"

"Checked if main content area is shown" &&& fun _ ->
    click ".search-new li a"
    displayed ".main_content_area"

run()

quit()