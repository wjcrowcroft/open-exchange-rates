C# Example for using the Open Exchange Rates API
===

This solution builds an assembly which contain some classes that make it super easy to use the Open Exchange Rates api. 


Configuration
===

API Key
---
Make sure that you specify your API key in the appsetting with the key `OpenExchangeRates.ApiKey` or else you will get web exceptions.


Caching
---

[OpenExchangeRates.org supports Etags](https://openexchangerates.org/documentation#etags) , internally the `WebClient` class is used which supports various caching methods
by default caching is disabled but can be easily enabled by using the following configuration in your application.

	<!-- http://msdn.microsoft.com/en-us/library/ehs1b109.aspx -->
	<system.net>
		<requestCaching isPrivateCache="false" defaultPolicyLevel="CacheIfAvailable"/>
	</system.net>

Be aware that your api count will still increase but this will help in reducing network traffic is.

Examples
===
Retrieve latest exchanges rates 
---

	var exchangeRateData = OpenExchangeRates.Client.Get();
	Console.WriteLine("€100 = ${0}",exchangeRateData.Convert(100,"EUR","USD"));

Retrieve historical exchanges rates 
---

	var exchangeRateData = OpenExchangeRates.Client.Get(DateTime.Now.AddDays(-7));
	Console.WriteLine("€100 = ${0}",exchangeRateData.Convert(100,"EUR","USD"));


Convert currency base
---
	var exchangeRateData = OpenExchangeRates.Client.Get(DateTime.Now.AddDays(-7));
	var euroBasedExchangeRateData = exchangeRateData.ConvertBase("EUR"); 
	// Perform a massive ammount of EUR related currency conversions.

Usage
===

You can either build the solution by executing `build.cmd` or by installing it via nuget:

	PM> Install-Package OpenExchangeRates