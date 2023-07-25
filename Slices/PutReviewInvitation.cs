using Arex388.Climbo.Converters;
using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace Arex388.Climbo;

/// <summary>
/// <c>PutReviewInvitation</c> request and response container.
/// </summary>
public sealed class PutReviewInvitation {
	private static Response? _cancelled;
	private static Response? _failed;
	private static Response? _timedOut;

	internal static Response Cancelled => _cancelled ??= new Response {
		Status = ResponseStatus.Cancelled
	};
	internal static Response Failed => _failed ??= new Response {
		Status = ResponseStatus.Failed
	};
	internal static Response Invalid(
		ValidationResult validation) => new() {
			Errors = validation.GetErrors(),
			Status = ResponseStatus.Invalid
		};
	internal static Response TimedOut => _timedOut ??= new Response {
		Status = ResponseStatus.TimedOut
	};

	/// <summary>
	/// <c>PutReviewInvitation</c> request container.
	/// </summary>
	public sealed class Request {
		/// <summary>
		/// The review invitation's account's id.
		/// </summary>
		[JsonPropertyName("seat")]
		public AccountId AccountId { get; internal set; }

		/// <summary>
		/// The review invitation's recepient's email.
		/// </summary>
		public string Email { get; init; } = null!;

		/// <summary>
		/// The review invitation's response language. English by default.
		/// </summary>
		[JsonConverter(typeof(LanguageJsonConverter)), JsonPropertyName("locale")]
		public Language Language { get; init; } = Language.English;

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
		/// The review invitation's scheduled send timestamp.
		/// </summary>
		[JsonPropertyName("send_datetime")]
		public DateTimeOffset SendAt { get; init; }

		/// <summary>
		/// The review invitation's custom email template. Built-in account template by default.
		/// 
		/// - "subject" - The email's subject.
		/// - "html" - The email's HTML content.
		/// - "text" - The email's text content.
		/// </summary>
		public IDictionary<string, string> Template { get; init; } = new Dictionary<string, string> {
			{ "id", "default" },
			{ "locale", Language.English.ToStringFast() }
		};

		/// <summary>
		/// The review invitation's custom tracking id.
		/// </summary>
		[JsonPropertyName("user_defined_id")]
		public string? UserDefinedTrackingId { get; init; }
	}

	/// <summary>
	/// <c>PutReviewInvitation</c> response container.
	/// </summary>
	public sealed class Response {
		/// <summary>
		/// Validation errors, if any.
		/// </summary>
		public IEnumerable<string> Errors { get; init; } = Enumerable.Empty<string>();

		/// <summary>
		/// The review invitation.
		/// </summary>
		public ReviewInvitation ReviewInvitation { get; init; } = null!;

		/// <summary>
		/// The response's status.
		/// </summary>
		public ResponseStatus Status { get; init; }
	}
}