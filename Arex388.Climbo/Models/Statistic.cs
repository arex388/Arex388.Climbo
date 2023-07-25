using System.Text.Json.Serialization;

namespace Arex388.Climbo;

public sealed class Statistic {
	[JsonPropertyName("avg")]
	public decimal Average { get; init; }

	[JsonPropertyName("reviews")]
	public int ReviewCount { get; init; }

	public string Source { get; init; } = null!;
}