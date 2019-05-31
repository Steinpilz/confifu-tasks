// include Fake lib
#r @"..\packages\FAKE\tools\FakeLib.dll"
#r @"..\packages\Steinpilz.DevFlow.Fake\tools\Steinpilz.DevFlow.Fake.Lib.dll"
//#load @"c:\data\work\github\fake-build\src\app\Steinpilz.DevFlow.Fake\lib.fs"


open Fake
open Steinpilz.DevFlow.Fake 

Lib.setup(fun p -> 
    { p with 
        PublishProjects = !!"src/app/**/*.csproj"
        UseDotNetCliToPack = true
        UseDotNetCliToTest = true
        NuGetFeed = 
            { p.NuGetFeed with 
                ApiKey = environVarOrNone <| "NUGET_API_KEY" 
            }
    }
)

RunTargetOrDefault "Watch"