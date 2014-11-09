using System.Collections.Generic;

namespace OpenExchangeRates
{
	/// <summary>
	/// Data structure containing exchange rates for a moment in time.
	/// </summary>
	public class ExchangeRateData
	{
		/// <summary>
		/// The disclaimer text.
		/// </summary>
		public string Disclaimer { get; set; }
		/// <summary>
		/// The license text.
		/// </summary>
		public string License { get; set; }
		/// <summary>
		/// The linux timestamp.
		/// </summary>
		public int TimeStamp { get; set; }
		/// <summary>
		/// The base currency.
		/// </summary>
		public string Base { get; set; }
		/// <summary>
		/// All currency rates.
		/// </summary>
		public Dictionary<string, decimal> Rates { get; set; }
	}
}