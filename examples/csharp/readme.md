C# Example for using the Open Exchange Rates API
===

This solution builds an assembly which contain some classes that make it super easy to use the Open Exchange Rates api. 


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