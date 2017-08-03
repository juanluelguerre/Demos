@ECHO OFF

SonarQube.Scanner.MSBuild begin /k:"CalculatorConsole" /n:"CalculatorConsole" /v:"1.0" /d:sonar.cs.vscoveragexml.reportsPaths="%CD%\VisualStudio.coveragexml" /d:sonar.cs.msbuild.testProjectPattern="*test.cs" /d:sonar.dotnet.test.assemblies="**/bin/Release/*.Test.dll" /d:sonar.donet.visualstudio.testProjectPattern="*.Test.cs"
MSBuild.exe /t:Rebuild


"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" collect /output:"%CD%\VisualStudio.coverage"
"%VSAPPIDDIR%\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "CalculatorConsole.Tests\bin\debug\CalculatorConsole.Tests.dll"

"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" analyze /output:"%CD%\VisualStudio.coveragexml" "%CD%\VisualStudio.coverage"

SonarQube.Scanner.MSBuild end

