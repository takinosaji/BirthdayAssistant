module BirthdayAssistant.Telegram.Api.Endpoints.Static

open Suave
        
let NotFoundHandler = RequestErrors.NOT_FOUND "Resource not found."