using Microsoft.Extensions.Configuration;

namespace Arex388.Climbo.Benchmarks;

internal sealed class Config {
	private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder().AddUserSecrets<Config>().Build();

	public static AccountId ClimboAccountId = new(_configuration[nameof(ClimboAccountId)]!);
	public static string ClimboKey => _configuration[nameof(ClimboKey)]!;
	public static string RecipientEmail => _configuration[nameof(RecipientEmail)]!;
	public static string RecipientName => _configuration[nameof(RecipientName)]!;
}