@ECHO OFF

SET msbuild="%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"

IF '%1'=='' (SET configuration=Release) ELSE (SET configuration=%1)

:: Build the solution. Override the platform to account for running
:: from Visual Studio Tools command prompt (x64). Log quietly to the 
:: console and verbosely to a file.
%msbuild% OpenExchangeRates.sln /t:Rebuild /nologo /property:Configuration=%configuration% /flp:verbosity=diagnostic

IF NOT ERRORLEVEL 0 EXIT /B %ERRORLEVEL%
