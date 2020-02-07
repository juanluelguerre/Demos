// #addin nuget:?package=Cake.Figlet&version=0.17.0º
#addin Cake.Figlet

// Environment.SetVariableNames();
// BuildParameters.PrintParameters(Context);

var isLocalBuild = BuildSystem.IsLocalBuild;
// var isMasterBranch = StringComparer.OrdinalIgnoreCase.Equals("master", BuildSystem.AppVeyor.Environment.Repository.Branch));

var target = Argument("target", "Default");

Setup(ctx => {
  Information(Figlet("Calculator")); 
});

Task("Clean")
    .Does(() =>
    {
    });

Task("Restore")
    .Does(() => 
    {
    });

Task("Build")
  .Does(() =>
  {    
    var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();
    Information("Building using versinón {0} of Cake", cakeVersion);

    // Build

  });

Task("Test")
  .IsDependentOn("Build")
  .Does(()=>
{

  // Tests

});

Task("Deploy")    
    .WithCriteria(!isLocalBuild)    
    .Does(() => 
    {
        // Deploy to some server using content and deployUrl
    }); 

Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Build")
    .IsDependentOn("Test")
    .IsDependentOn("Deploy")    
    .Does(() => 
    {
    });

Teardown(context =>
{
    // Executed AFTER the last task.
});

RunTarget(target);

// -----------------------------------------------------------------
// --------------------rerrelease Version --------------------------
// -----------------------------------------------------------------
// #load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

// Environment.SetVariableNames();

// BuildParameters.SetParameters(
//     context: Context, 
//     buildSystem: BuildSystem,
//     sourceDirectoryPath: "./",
//     title: "CalculatorCoreConsole",
//     repositoryOwner: "cake-contrib",
//     repositoryName: "Cake.Figlet",
//     appVeyorAccountName: "cakecontrib",
//     shouldRunCodecov: false);

// BuildParameters.PrintParameters(Context);

// ToolSettings.SetToolSettings(
//     context: Context,
//     dupFinderExcludePattern: new string[] { BuildParameters.RootDirectoryPath + "/CalculatorCoreConsole/*.cs", BuildParameters.RootDirectoryPath + "/CalculatorCoreConsole/**/*.AssemblyInfo.cs" },
//     testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* ",
//     testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
//     testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

// Build.RunDotNetCore();
