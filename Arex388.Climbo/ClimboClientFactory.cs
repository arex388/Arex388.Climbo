using Microsoft.Extensions.Caching.Memory;

namespace Arex388.Climbo;

/// <summary>
/// Climbo.com API client factory for applications integrating with more than one Climbo.com account.
/// </summary>
public sealed class ClimboClientFactory :
	IClimboClientFactory {
	private static readonly MemoryCacheEntryOptions _memoryCacheEntryOptions = new() {
		SlidingExpiration = TimeSpan.MaxValue
	};

	private readonly IHttpClientFactory _httpClientFactory;
	private readonly IMemoryCache _memoryCache;

	/// <summary>
	/// Create an instance of the Climbo.com client factory.
	/// </summary>
	/// <param name="httpClientFactory">An instance of <c>HttpClientFactory</c>.</param>
	/// <param name="memoryCache">An instance of <c>MemoryCache</c>.</param>
	public ClimboClientFactory(
		IHttpClientFactory httpClientFactory,
		IMemoryCache memoryCache) {
		_httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
		_memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
	}

	/// <summary>
	/// Create and cache an instance of the Climbo.com API client.
	/// </summary>
	/// <param name="apiKey">Your Climbo.com API key.</param>
	/// <param name="accountId">The account's id. The value will be used as the cache identifier.</param>
	/// <returns>A new or cached instance of <c>ClimboClient</c>.</returns>
	public IClimboClient CreateClient(
		string apiKey,
		AccountId accountId) {
		var key = $"{nameof(Climbo)}.Key[{accountId}]";

		if (_memoryCache.TryGetValue(key, out IClimboClient? climboClient)
			&& climboClient is not null) {
			return climboClient;
		}

		var httpClient = _httpClientFactory.CreateClient($"{nameof(ClimboClient)}.Key[{accountId}]");

		httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

		climboClient = new ClimboClient(accountId, httpClient);

		_memoryCache.Set(key, climboClient, _memoryCacheEntryOptions);

		return climboClient;
	}
}