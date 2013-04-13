C# Example for using the Open Exchange Rates API
===

This solution builds an assembly which contain some classes that make it super easy to use the Open Exchange Rates api. 
Configuration
===
Make sure that you specify your API key in the appsetting with the key `OpenExchangeRates.ApiKey` or else you will get web exceptions.

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