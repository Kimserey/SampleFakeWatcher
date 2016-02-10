namespace SampleFakeWatcher

open WebSharper
open WebSharper.JavaScript
open WebSharper.JQuery
open WebSharper.UI.Next
open WebSharper.UI.Next.Client
open WebSharper.UI.Next.Html

[<JavaScript>]
module Client =    
    
    let title =
        h1 [ text "Hi, welcome to" ]
    
    let div =
        div [ text "kimsereyblog.blogspot.co.uk" ]

    [ title; div ]
    |> Seq.cast
    |> Doc.Concat
    |> Doc.RunById "main"
