using Arex388.Climbo;
using Microsoft.Extensions.Caching.Memory;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// <c>IServiceCollection</c> extensions.
/// </summary>
public static class ServiceCollectionExtensions {
	/// <summary>
	/// Add Climbo.com service for interacting with multiple accounts.
	/// </summary>
	/// <param name="services">The service collection.</param>
	/// <returns>The service collection.</returns>
	public static IServiceCollection AddClimbo(
		this IServiceCollection services) => services.AddSingleton<IClimboClientFactory>(
		_ => {
			var httpClientFactory = _.GetRequiredService<IHttpClientFactory>();
			var memoryCache = _.GetRequiredService<IMemoryCache>();

			return new ClimboClientFactory(httpClientFactory, memoryCache);
		});

	/// <summary>
	/// Add Climbo.com service for interacting with a single account.
	/// </summary>
	/// <param name="services">The service collection.</param>
	/// <param name="apiKey">The Climbo.com API key.</param>
	/// <param name="accountId">The account's id.</param>
	/// <returns>The service collection.</returns>
	public static IServiceCollection AddClimbo(
		this IServiceCollection services,
		string apiKey,
		AccountId accountId) => services.AddSingleton(
		_ => {
			var httpClientFactory = _.GetRequiredService<IHttpClientFactory>();
			var httpClient = httpClientFactory.CreateClient(nameof(ClimboClient));

			httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

			return new ClimboClient(accountId, httpClient);
		});
}