steps to do it:-
1. dotnet tool install Nuke.GlobalTool --global
2. create API solution with weather api of .netweb api in .net core 8.0
3. WeatherApi/
├── Controllers/
│   └── WeatherController.cs
├── Models/
│   └── WeatherForecast.cs
├── Services/
│   └── WeatherService.cs
├── Program.cs
├── Startup.cs
└── WeatherApi.csproj

4. nuke :setup(select default aption)
5.  folderstructure will belike 
WeatherApi/
├── Controllers/
│   └── WeatherController.cs
├── Models/
│   └── WeatherForecast.cs
├── Services/
│   └── WeatherService.cs
├── Program.cs
├── Startup.cs
├── WeatherApi.csproj
└── build/
    ├── Build.cs
    └── build.cmd/build.sh
6.build project if getting error Duplicate 'global::System.Runtime.Versioning.TargetFrameworkAttribute' attribute then
  exclude bin,obj folder from API solution********
7.run _buld solution will create publish by running  class Build.cs
8.and publish folder will generate on location \API\output\publish 
9 now in CD part take above generated publish folder and deploy it to server.