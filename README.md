# Tradelite Solutions SDK for Unity Games

## Introduction

Tradelite Solutions provides distributed services that allows to develop games with financial data—more information on (Tradelite website)[https://tradelite.de/].

This SDK allows game development teams using Unity to exchange data with the Tradelite Platform:
- In closed loop with JSON files during the development;
- In an open loop with heavily instrumented code during the test phases;
- In an open loop with efficient code when the game is freely available.

Tradelite Solutions strategy relies on distributed services, some of them getting data from live data stream (think financial market data), some of them getting data from live services (think event schedules and leaderboards), and finally some of them from static repositories (think graphical assets and informational data). The SDK offers high level business methods that gather transparently information from many sources, with fallback mechanisms in case the traffic over the Internet is not reliable...

The SDK is offered as a Unity Package—more information on (Unity website)[https://docs.unity3d.com/Manual/CustomPackages.html]. The package should be added to Unity projects with the URL of this repository.

## Known Limitations

- The SDK is still in _beta_ phase and instabilies and API updates have to be expected.
- The current code relies on a local HTTP server to produce _mock data_. Please visit the repository of the (Simple Deno Server)[https://github.com/DomDerrien/simple-deno-server] to get your own copy of this local server. The _mock data_ files can be updated locally to produce repeatable use-cases.
- The SDK will have to be initialized with a game identifier that will be used to retrieve the game configuration from the Cloud once the game is on production. Please, send an email to (support-game-registration @ tradelite)[mailto:support-game-registration@tradelite.de] once you are ready to have your game connected to our live services.

## Available APIs

### Authentication: Sign-In, Sign-Up, and Play-as-Guest
### Player Profile
### Player Wallet
### Game Catalog
### Game Configuration
### 1x2 Game
### Matching Game
### Prediction Game 
