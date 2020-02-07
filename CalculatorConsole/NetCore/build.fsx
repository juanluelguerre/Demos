// #r "paket:
// nuget Fake.Core.Target
// nuget Fake.DotNet.Testing.OpenCover //"
#load ".fake/build.fsx/intellisense.fsx"

// Dependencies
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

// open Fake.DotNet.Testing
// open Fake.DotNet.Testing.OpenCover

Target.create "Clean" (fun _ ->
    !! "src/**/bin"
    ++ "src/**/obj"
    |> Shell.cleanDirs    
)

Target.create "Build" (fun _ ->
    !! "src/**/*.csproj"
    |> Seq.iter (DotNet.build id)    
)

Target.create "Test" (fun _ ->
    !! "test/**/*.csproj"
    |>  Seq.iter (DotNet.test id)  
)

// Target.create "Coverage" (fun _ ->
//     OpenCover.getVersion (fun p -> { p with ExePath = "./tools/OpenCover/tools/OpenCover.Console.exe" })

//     OpenCover.run (fun p ->
//     { p with
//             ExePath = "./tools/OpenCover/tools/OpenCover.Console.exe"
//             TestRunnerExePath = "./tools/xunit.runner.console/tools/xunit.console.exe";
//             Output = "coverage.xml";
//             Register = RegisterUser;
//             Filter = "+[MyProject]*";
//             ExcludeByAttribute = [ "*.ExcludeFromCodeCoverage*" ];
//             ExcludeByFile = [ "Program.cs"; "Window.cs" ];
//             ExcludeDirs = [ "test" ];
//             HideSkipped = [File; Attribute];
//             MergeOutput = true;
//             ReturnTargetCode = Offset 5;
//             SearchDirs = [ "c:\projects\common\bin\debug\dnx451" ];
//             SkipAutoProps = true;
//     })
//     "CalculatorCoreConsoleTests.dll -noshadow"
// )


Target.create "All" ignore

"Clean"
  ==> "Build"
  ==> "Test"
  // ==> "Coverage"
  ==> "All"

// Start build
Target.runOrDefault "All"
