@ECHO OFF

MSBuild.SonarQube.Runner.exe begin /k:"CalculatorConsole" /n:"CalculatorConsole" /v:"1.0" /d:sonar.cs.vscoveragexml.reportsPaths="%CD%\VisualStudio.coveragexml"
MSBuild.exe /t:Rebuild


"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" collect /output:"%CD%\VisualStudio.coverage"
"%VSAPPIDDIR%\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "CalculatorConsole.Tests\bin\debug\CalculatorConsole.Tests.dll"

"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" analyze /output:"%CD%\VisualStudio.coveragexml" "%CD%\VisualStudio.coverage"

MSBuild.SonarQube.Runner.exe end

