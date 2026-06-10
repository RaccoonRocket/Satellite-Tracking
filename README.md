# Satellite Tracking

A tool for simulation of orbital groupings of satellites.

4.3. Algorithm for converting a cluster into a streaming network. A lattice is given, an arbitrary cluster is built on it, the max flow and the cross section are determined. Application of the Ford-Fulkerson algorithm for a lattice of satellites.

## Web version

The original WinForms project is still available in the repository. The cross-platform version is split into:

- `SatelliteTracking.Core` - reusable C# algorithm code.
- `SatelliteTracking.Web` - browser UI built with Blazor.

## Run with Docker

Install Docker Desktop, then run:

```bash
docker compose up --build
```

Open:

```text
http://localhost:8080
```

## Run with .NET SDK

Install the .NET 8 SDK, then run:

```bash
dotnet run --project SatelliteTracking.Web
```

The terminal will print the local URL.

## Original example

Example of work:
![skrin](https://github.com/Raccoonrocket/Course_Project/assets/90098084/a1a38bd2-fe3d-49a7-a24a-36877169b6b9)
