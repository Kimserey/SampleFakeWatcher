#I __SOURCE_DIRECTORY__
#r "packages/FAKE/tools/FakeLib.dll"

open System
open Fake

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

let build() =
    build id "SampleFakeWatcher.sln"

Target "Build" build

Target "Watch" (fun _ ->
    use watcher = !! "**/*.fs" |> WatchChanges (ignore >> build)
    System.Console.ReadLine() |> ignore
    watcher.Dispose()
)

RunTargetOrDefault "Watch"