using BenchmarkDotNet.Attributes;

namespace Arex388.Climbo.Benchmarks;

[MemoryDiagnoser]
public class ReviewStatistics {
	private readonly IClimboClient _climbo;

	public ReviewStatistics() {
		var httpClient = new HttpClient();

		httpClient.DefaultRequestHeaders.Add("x-api-key", Config.ClimboKey);

		_climbo = new ClimboClient(Config.ClimboAccountId, httpClient);
	}

	[Benchmark]
	public async Task GetAsync() {
		var response = await _climbo.GetReviewStatisticsAsync().ConfigureAwait(false);

		_ = response.ToString();
	}
}