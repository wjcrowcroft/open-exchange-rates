using System;

namespace OpenExchangeRates
{
	/// <summary>
	/// Currency converter helper class.
	/// </summary>
	public static class CurrencyConverter
	{
		/// <summary>
		/// Converts the specified ammount <paramref name="value"/> in currency <paramref name="from"/> to the currency specified in <paramref name="to"/>.
		/// </summary>
		/// <param name="data">The currency exchange rates to use.</param>
		/// <param name="value">The ammount of money.</param>
		/// <param name="from">The currency code of the given money value.</param>
		/// <param name="to">The currency to convert the given money value to.</param>
		/// <returns></returns>
		public static decimal Convert(this ExchangeRateData data, decimal value, string from, string to)
		{
			decimal rate;

			if (data.Base != from)
			{
				if (!data.Rates.TryGetValue(from, out rate)) throw new ArgumentException("Currency not available.", "from");
				value /= rate;
			}

			if (data.Base != to)
			{
				if (!data.Rates.TryGetValue(to, out rate)) throw new ArgumentException("Currency not available.", "to");
				value *= rate;
			}

			return value;
		}
	}
}