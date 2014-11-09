@ECHO OFF

SET msbuild="%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"

IF '%1'=='' (SET configuration=Release) ELSE (SET configuration=%1)

:: Load HEAD commit in to parameter
:: --------------------------------------------------
git.exe rev-parse --short HEAD > .gitcommit
set /p Revision= < .gitcommit
del .gitcommit
echo Revision: %Revision%

:: Prompt for product version
:: --------------------------------------------------
set /p Major=Major Version: %=%
set /p Minor=Minor Version: %=%
set /p Build=Build Number: %=%

:: Build the solution. Override the platform to account for running
:: from Visual Studio Tools command prompt (x64). Log quietly to the 
:: console and verbosely to a file.
%msbuild% build.proj /nologo /property:Configuration=%configuration% /property:Major=%Major% /property:Minor=%Minor% /property:Build=%Build% /property:Revision=%Revision% /flp:verbosity=diagnostic /property:OutputDir=_build

IF NOT ERRORLEVEL 0 EXIT /B %ERRORLEVEL%

.nuget\nuget.exe pack OpenExchangeRates.nuspec -version %Major%.%Minor%.%Build%
