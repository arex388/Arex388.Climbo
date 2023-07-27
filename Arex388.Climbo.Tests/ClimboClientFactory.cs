using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Arex388.Climbo.Tests;

public sealed class ClimboClientFactory {
	private readonly IClimboClientFactory _climboFactory;
	private readonly IConfigurationRoot _configuration;

	public ClimboClientFactory() {
		_climboFactory = new Climbo.ClimboClientFactory(new DefaultHttpClientFactory(), new MemoryCache(new MemoryCacheOptions()));
		_configuration = new ConfigurationBuilder().AddUserSecrets<IAssemblyMarker>().Build();
	}

	[Fact]
	public void CreateAndCacheClient() {
		var created = _climboFactory.CreateClient(_configuration["ClimboKey"]!, AccountId.Empty);
		var cached = _climboFactory.CreateClient(_configuration["ClimboKey"]!, AccountId.Empty);

		Assert.Equal(created, cached);
	}

	[Fact]
	public void CreateClients() {
		var client1 = _climboFactory.CreateClient(_configuration["ClimboKey"]!, new AccountId(_configuration["ClimboAccountId-1"]!));
		var client2 = _climboFactory.CreateClient(_configuration["ClimboKey"]!, new AccountId(_configuration["ClimboAccountId-2"]!));

		Assert.NotNull(client1);
		Assert.NotNull(client2);
	}
}