module BirthdayAssistant.Telegram.Startup

open Suave
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
      ]

    let server = startWebServerAsync suaveConfig app |> snd
      
    Async.Start(server, cts.Token)       
    cts