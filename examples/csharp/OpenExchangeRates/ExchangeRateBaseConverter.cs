using System.Collections.Generic;

namespace OpenExchangeRates
{
	/// <summary>
	/// Helper class to convert base currency for the currency exchange rate data structure.
	/// This is usefull when you will need to perform a huge set of currency conversions
	/// based on a single source or destination currency to improve conversion performance.
	/// </summary>
	public static class ExchangeRateBaseConverter
	{
		/// <summary>
		/// The precision of conversion rates returned in the json data of openexchangerates.org
		/// </summary>
		private const int OpenExchangeRoundingPrecision = 6;
		/// <summary>
		/// Convert a supplied <see cref="ExchangeRateData"/> to a new base currency.
		/// </summary>
		/// <param name="oldRates">The currency exchange rate to convert.</param>
		/// <param name="newBaseCurrency">The new base currency.</param>
		/// <param name="rounding">Should the converted exchange rates be rounded (saves space when serializing)</param>
		/// <returns>A new <see cref="ExchangeRateData"/> instance using the new base currency.</returns>
		public static ExchangeRateData ConvertBase(this ExchangeRateData oldRates, string newBaseCurrency, bool rounding = true)
		{
			var newRates = new ExchangeRateData
			{
				Base = newBaseCurrency,
				TimeStamp = oldRates.TimeStamp,
				Rates = new Dictionary<string, decimal>(oldRates.Rates.Count)
			};

			decimal x = oldRates.Rates[newBaseCurrency];

			foreach (var i in oldRates.Rates)
			{
				var rate = i.Value / x;
				if (rounding) rate = decimal.Round(rate, OpenExchangeRoundingPrecision);
				newRates.Rates[i.Key] = rate;
			}

			return newRates;
		}
	}
}