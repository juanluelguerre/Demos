@ECHO OFF

SonarQube.Scanner.MSBuild begin /k:"CalculatorConsole" /n:"CalculatorConsole" /v:"1.0" /d:sonar.cs.vscoveragexml.reportsPaths=".\VisualStudio.coveragexml" 

MSBuild.exe /t:Rebuild


"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" collect /output:"%CD%\VisualStudio.coverage"
"%VSAPPIDDIR%\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" /EnableCodeCoverage ".\CalculatorConsole.Tests\bin\debug\CalculatorConsole.Tests.dll"

REM "%VSAPPIDDIR%\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" /inIsolation /EnableCodeCoverage "%CD%\CalculatorConsole.Tests\bin\debug\CalculatorConsole.Tests.dll"


"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" analyze /output:"%CD%\VisualStudio.coveragexml" ".\VisualStudio.coverage"

SonarQube.Scanner.MSBuild end

