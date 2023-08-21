using Microsoft.Extensions.Configuration;

namespace Arex388.Climbo.Tests;

internal sealed class Config {
	private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder().AddUserSecrets<Config>().Build();

	public static AccountId ClimboAccountId1 = new(_configuration["ClimboAccountId-1"]!);
	public static AccountId ClimboAccountId2 = new(_configuration["ClimboAccountId-2"]!);
	public static string ClimboKey => _configuration[nameof(ClimboKey)]!;
	public static string RecipientEmail => _configuration[nameof(RecipientEmail)]!;
	public static string RecipientName => _configuration[nameof(RecipientName)]!;
}