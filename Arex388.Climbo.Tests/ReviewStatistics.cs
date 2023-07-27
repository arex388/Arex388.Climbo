using Microsoft.Extensions.Configuration;
using Xunit;

namespace Arex388.Climbo.Tests;

public sealed class ReviewStatistics {
	private readonly IClimboClient _climbo;

	public ReviewStatistics() {
		var configuration = new ConfigurationBuilder().AddUserSecrets<IAssemblyMarker>().Build();
		var httpClient = new HttpClient();

		httpClient.DefaultRequestHeaders.Add("x-api-key", configuration["ClimboKey"]!);

		_climbo = new ClimboClient(new AccountId(configuration["ClimboAccountId-1"]!), httpClient);
	}

	[Fact]
	public async Task GetAsync() {
		var response = await _climbo.GetReviewStatisticsAsync().ConfigureAwait(false);

		Assert.Equal(ResponseStatus.Succeeded, response.Status);
		Assert.NotEmpty(response.Statistics);
	}
}