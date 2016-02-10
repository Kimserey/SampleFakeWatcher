#I __SOURCE_DIRECTORY__
#r "packages/FAKE/tools/FakeLib.dll"

open Fake
open Fake.MSBuildHelper

Target "Build" (fun _ ->
    build id "./SampleFakeWatcher.sln"
)

Target "Watch" (fun _ ->
    use watcher = 
        !! "SampleFakeWatcher/*.*"
        |> WatchChanges (fun changes -> 
            tracefn "%A" changes
            Run "Build"
        )

    //Needed to keep FAKE from exiting
    System.Console.ReadLine() 
    |> ignore

    // Use to stop the watch from elsewhere, ie another task.
    watcher.Dispose()
)

Run "Watch"