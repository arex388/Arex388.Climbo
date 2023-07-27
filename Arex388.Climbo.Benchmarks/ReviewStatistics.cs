using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;

namespace Arex388.Climbo.Benchmarks;

[MemoryDiagnoser]
public class ReviewStatistics {
	private readonly IClimboClient _climbo;

	public ReviewStatistics() {
		var configuration = new ConfigurationBuilder().AddUserSecrets<IAssemblyMarker>().Build();
		var httpClient = new HttpClient();

		httpClient.DefaultRequestHeaders.Add("x-api-key", configuration["ClimboKey"]!);

		_climbo = new ClimboClient(new AccountId(configuration["ClimboAccountId"]!), httpClient);
	}

	[Benchmark]
	public async Task GetAsync() {
		var response = await _climbo.GetReviewStatisticsAsync().ConfigureAwait(false);

		_ = response.ToString();
	}
}