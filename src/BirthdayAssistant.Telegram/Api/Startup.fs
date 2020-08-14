module BirthdayAssistant.Telegram.Api.Startup

open BirthdayAssistant.Telegram.Api.Endpoints

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

open System.Threading
open Microsoft.Extensions.Configuration

let [<Literal>] private ConfigSectionName = "Hosting"        
let [<Literal>] private PortField = "Port"
let [<Literal>] private HostField = "Host"

type ApiStartupSettings = {
    Host: string
    Port: int
}
    
let ExtractStartupSettings (configuration: IConfiguration) =
    let hostingSection = configuration.GetSection ConfigSectionName
    {
        Host = hostingSection.GetValue(HostField)
        Port = hostingSection.GetValue(PortField)
    }

let Run (webAppConfig: ApiStartupSettings) =
    let cts = new CancellationTokenSource()
    let suaveConfig = {
        defaultConfig with
            cancellationToken = cts.Token
            bindings = [ HttpBinding.createSimple HTTP webAppConfig.Host webAppConfig.Port ]
    }

    let app =
      choose [
            GET >=> choose
                [ path "/" >=> OK "Hello ROOT" ]
            Static.NotFoundHandler
          ]

    let server = startWebServerAsync suaveConfig app |> snd
      
    Async.Start(server, cts.Token)       
    cts