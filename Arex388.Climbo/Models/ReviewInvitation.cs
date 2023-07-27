using Arex388.Climbo.Converters;
using System.Text.Json.Serialization;

namespace Arex388.Climbo;

public sealed class ReviewInvitation {
	/// <summary>
	/// The review invitation's recepient's email.
	/// </summary>
	public string Email { get; init; } = null!;

	/// <summary>
	/// The review invitation's id.
	/// </summary>
	public ReviewInvitationId Id { get; init; }

	/// <summary>
	/// The review invitation's recepient's name.
	/// </summary>
	public string Name { get; init; } = null!;

	/// <summary>
	/// The review invitation's retry attempts if the review link is not used.
	/// </summary>
	[JsonPropertyName("retry")]
	public byte RetryAttempts { get; init; }

	/// <summary>
	/// The review invitation's scheduled send timestamp.
	/// </summary>
	[JsonPropertyName("send_datetime")]
	public string SendAt { get; init; } = null!;

	/// <summary>
	/// The review invitation's status.
	/// </summary>
	[JsonConverter(typeof(ReviewInvitationStatusJsonConverter)), JsonPropertyName("tracking")]
	public ReviewInvitationStatus Status { get; init; }

	/// <summary>
	/// The review invitation's email template.
	/// </summary>
	public IDictionary<string, string> Template { get; init; } = null!;

	/// <summary>
	/// The review invitation's custom tracking id.
	/// </summary>
	[JsonPropertyName("user_defined_id")]
	public string? UserDefinedTrackingId { get; init; }
}