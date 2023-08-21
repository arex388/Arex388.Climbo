using System.Text.Json.Serialization;

namespace Arex388.Climbo;

/// <summary>
/// Statistics object.
/// </summary>
public sealed class Statistic {
	/// <summary>
	/// The average rating.
	/// </summary>
	[JsonPropertyName("avg")]
	public decimal Average { get; init; }

	/// <summary>
	/// The review count.
	/// </summary>
	[JsonPropertyName("reviews")]
	public int ReviewCount { get; init; }

	/// <summary>
	/// The review source.
	/// </summary>
	public string Source { get; init; } = null!;
}