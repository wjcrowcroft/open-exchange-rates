using System;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;

namespace OpenExchangeRates
{
	/// <summary>
	/// Open exchange rates data fetcher.
	/// </summary>
	public class Client
	{
		static readonly string ApiKey = ConfigurationManager.AppSettings["OpenExchangeRates.ApiKey"];
		static readonly string LatestUrl = "http://openexchangerates.org/api/latest.json?app_id=" + ApiKey;
		static readonly string HistoryUrl = "http://openexchangerates.org/api/historical/{0:yyyy-MM-dd}.json?app_id=" + ApiKey;

		/// <summary>
		/// Retrieve the latest exchange rate data structure.
		/// </summary>
		/// <returns>An <see cref="ExchangeRateData"/> instance.</returns>
		public static ExchangeRateData Get()
		{
			using (var client = new WebClient())
			{
				var json = client.DownloadString(LatestUrl);
				return JsonConvert.DeserializeObject<ExchangeRateData>(json);
			}
		}

		/// <summary>
		/// Retrieve the historical exchange rate data structure for a given date.
		/// </summary>
		/// <param name="date"></param>
		/// <returns>An <see cref="ExchangeRateData"/> instance.</returns>
		public static ExchangeRateData Get(DateTime date)
		{
			var url = string.Format(HistoryUrl, date);
			using (var client = new WebClient())
			{
				var json = client.DownloadString(url);
				return JsonConvert.DeserializeObject<ExchangeRateData>(json);
			}
		}
	}
}