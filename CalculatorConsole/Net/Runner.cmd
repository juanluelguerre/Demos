@ECHO OFF

REM **************************************************************************
REM Issues: https://github.com/SonarSource/sonar-csharp/issues/492
REM
REM Issues Traker: https://jira.sonarsource.com/browse/SONARMSBRU-167
REM **************************************************************************

MSBuild.SonarQube.Runner begin /k:"CalculatorConsole" /n:"CalculatorConsole" /v:"1.0" /d:sonar.cs.vscoveragexml.reportsPaths="%CD%\VisualStudio.coveragexml"  /d:sonar.verbose=true 

REM SonarQube.Scanner.MSBuild
REM MSBuild.SonarQube.Runner

REM /d:sonar.cs.vscoveragexml.reportsPaths=**/*.coveragexml
REM /d:sonar.cs.vscoveragexml.reportsPaths="%CD%\VisualStudio.coveragexml"

MSBuild.exe /t:Rebuild


"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" collect /output:"%CD%\VisualStudio.coverage"
"%VSAPPIDDIR%\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "CalculatorConsole.Tests\bin\debug\CalculatorConsole.Tests.dll"

"%VSAPPIDDIR%\..\..\Team Tools\Dynamic Code Coverage Tools\CodeCoverage.exe" analyze /output:"%CD%\VisualStudio.coveragexml" "%CD%\VisualStudio.coverage"

MSBuild.SonarQube.Runner end

