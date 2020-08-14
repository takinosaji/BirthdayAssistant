# BirthdayAssistant
Bots for popular messengers who's purpose to assist in tracking and handling birthdays

## Current implementation status
Suave skeleton serving default API


## Core


## Telegram

### Development
> **ngrok**: This tool allows local development and testing using real telegram API and capabilities. Under **tools/ngrok** folder you can find several scripts with default parameters matching parameters of Telegram app in development configuration. Just run one of the scripts and tunneling to your app is ready. Visit **localhost:4040** to get url for your tunnel and use it.

### Docker 
> **DEV**: Open PowerShell and run following command from root folder: ``docker build -f docker/Dockerfile.telegram.dev .``. You should get ___[container_id]___ as a result.\
Once container built you can run it with following command: ``docker run -p 8080:8080 [container-id]``

### Diagrams


