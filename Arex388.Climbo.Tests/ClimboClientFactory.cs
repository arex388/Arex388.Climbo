using Microsoft.Extensions.Caching.Memory;
using Xunit;

namespace Arex388.Climbo.Tests;

public sealed class ClimboClientFactory {
	private readonly IClimboClientFactory _climboFactory = new Climbo.ClimboClientFactory(new DefaultHttpClientFactory(), new MemoryCache(new MemoryCacheOptions()));

	[Fact]
	public void CreateAndCacheClient() {
		var created = _climboFactory.CreateClient(Config.ClimboKey, AccountId.Empty);
		var cached = _climboFactory.CreateClient(Config.ClimboKey, AccountId.Empty);

		Assert.Equal(created, cached);
	}

	[Fact]
	public void CreateClients() {
		var client1 = _climboFactory.CreateClient(Config.ClimboKey, Config.ClimboAccountId1);
		var client2 = _climboFactory.CreateClient(Config.ClimboKey, Config.ClimboAccountId2);

		Assert.NotNull(client1);
		Assert.NotNull(client2);
	}
}