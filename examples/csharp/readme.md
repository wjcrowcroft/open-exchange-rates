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
	Console.WriteLine("€100 = ${0}", exchangeRateData.Convert(100,"EUR","USD"));

Retrieve historical exchanges rates 
---

	var exchangeRateData = OpenExchangeRates.Client.Get(DateTime.Now.AddDays(-7));
	Console.WriteLine("€100 = ${0}", exchangeRateData.Convert(100,"EUR","USD"));


Convert currency base
---
You often only want to convert to/from a base currency. The default base currency is USD and converting between non USD currencies required two conversions. First from the source to base currency and then from the base currency to the target currency. Both conversions require a lookup and is 'costly'. When you always do currency conversions from/to a specific currency then this could improve conversions.


	var exchangeRateData = OpenExchangeRates.Client.Get(DateTime.Now.AddDays(-7));
	var euroBasedExchangeRateData = exchangeRateData.ConvertBase("EUR"); 
	// Perform a large amount of EUR related currency conversions.


Get exchange rate
---
Sometimes you just need the exchange rate. Accounting often has the requirement to book a foreign currency invoice and mention the exchange rate used to book an invoice and later when the invoice is actually paid to book the exchange rate differences. To get the exchange rate just convert '1' and the result will be the exchange rate which you can then use in the accounting transaction or to actually convert an amount.

	var exchangeRate = exchangeRateData.Convert(1,"EUR","USD");
	// Perform a massive amount of conversions based on a single exchange rate to improve


This method can also be used to so a massive amount of conversions like for example, converting all transaction of the last month although these kind of micro optimizations are neglectable compared to IO but could help improve readability of your code.


Currency digit precision
---
The conversion routine does not perform any rounding on the result. It is advised to round the results to the [ISO 4217 currency digit precision](http://en.wikipedia.org/wiki/ISO_4217) to avoid confusion.

For example, the Euro (EUR) has a precision of two because the Euro uses cents.


	x = Round.Math(x, 2); // Where 'x' is a converted amount and now rounded based on two digits using .net default roundin method .

_Be aware that the default rounding method of `Math.Round` is [AwayFromZero](http://msdn.microsoft.com/en-us/library/system.midpointrounding(v=vs.110))_.

Usage
===

You can either build the solution by executing `build.cmd` or by installing it via nuget:

	PM> Install-Package OpenExchangeRates