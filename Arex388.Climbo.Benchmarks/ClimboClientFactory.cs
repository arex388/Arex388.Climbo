using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace Arex388.Climbo.Benchmarks;

[MemoryDiagnoser]
public class ClimboClientFactory {
	private readonly IClimboClientFactory _climboFactory;
	private readonly IConfigurationRoot _configuration;

	public ClimboClientFactory() {
		_climboFactory = new Climbo.ClimboClientFactory(new DefaultHttpClientFactory(), new MemoryCache(new MemoryCacheOptions()));
		_configuration = new ConfigurationBuilder().AddUserSecrets<IAssemblyMarker>().Build();
	}

	[Benchmark]
	public void CreateAndCacheClient() {
		var client = _climboFactory.CreateClient(_configuration["ClimboKey"]!, new AccountId(_configuration["ClimboAccountId"]!));

		_ = client.ToString();
	}
}