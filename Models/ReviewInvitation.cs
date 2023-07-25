﻿using Arex388.Climbo.Converters;
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
	/// The review invitation's retry attempts if the review link is not used. Zero (0) by default. Three (3) maximum.
	/// </summary>
	[JsonPropertyName("retry")]
	public byte RetryAttempts { get; init; }

	/// <summary>
	/// The review invitation's scheduled send timestamp in UTC.
	/// </summary>
	[JsonPropertyName("send_datetime")]
	public string SendAtUtc { get; init; } = null!;

	/// <summary>
	/// The review invitation's status.
	/// </summary>
	[JsonConverter(typeof(ReviewInvitationStatusJsonConverter)), JsonPropertyName("tracking")]
	public ReviewInvitationStatus Status { get; init; }

	/// <summary>
	/// The review invitation's custom email template. Built-in account template by default.
	/// 
	/// - "subject" - The email's subject.
	/// - "html" - The email's HTML content.
	/// - "text" - The email's text content.
	/// </summary>
	public IDictionary<string, string> Template { get; init; } = null!;

	/// <summary>
	/// The review invitation's custom tracking id.
	/// </summary>
	[JsonPropertyName("user_defined_id")]
	public string? UserDefinedTrackingId { get; init; }
}