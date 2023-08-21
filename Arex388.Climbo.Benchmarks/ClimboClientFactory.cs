using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Caching.Memory;

namespace Arex388.Climbo.Benchmarks;

[MemoryDiagnoser]
public class ClimboClientFactory {
	private readonly IClimboClientFactory _climboFactory = new Climbo.ClimboClientFactory(new DefaultHttpClientFactory(), new MemoryCache(new MemoryCacheOptions()));

	[Benchmark]
	public void CreateAndCacheClient() {
		var client = _climboFactory.CreateClient(Config.ClimboKey, Config.ClimboAccountId);

		_ = client.ToString();
	}
}