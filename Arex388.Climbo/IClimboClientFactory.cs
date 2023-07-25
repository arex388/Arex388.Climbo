namespace Arex388.Climbo;

/// <summary>
/// Climbo.com API client factory for applications integrating with more than one Climbo.com account.
/// </summary>
public interface IClimboClientFactory {
	/// <summary>
	/// Create and cache an instance of the Climbo.com API client.
	/// </summary>
	/// <param name="apiKey">Your Climbo.com API key. The value will be used as the cache identifier.</param>
	/// <param name="accountId">The account's id.</param>
	/// <returns>A new or cached instance of <c>ClimboClient</c>.</returns>
	IClimboClient CreateClient(
		string apiKey,
		AccountId accountId);
}