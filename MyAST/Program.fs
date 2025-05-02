open System
open Giraffe
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)
    builder.Services.AddGiraffe() |> ignore
    let app = builder.Build()
    app.UseStaticFiles() |> ignore

    let webApp = 
        choose [
            route "/" >=> htmlFile "./wwwroot/index.html"
        ]
    
    app.UseGiraffe(webApp)

    app.Run()

    0 // Exit code

