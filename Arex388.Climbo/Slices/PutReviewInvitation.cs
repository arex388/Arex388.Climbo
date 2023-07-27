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
	internal static Response Failed(
		Exception? exception) {
		if (exception is null) {
			return _failed ??= new Response {
				Status = ResponseStatus.Failed
			};
		}

		return new Response {
			Errors = new[] {
				$"[{exception.GetType().Name}] {exception.Message}"
			},
			Status = ResponseStatus.Failed
		};
	}
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
		/// The review invitation's recepient's name.
		/// </summary>
		public string Name { get; init; } = null!;

		/// <summary>
		/// The review invitation's retry attempts if the review link is not used.
		/// </summary>
		/// <remarks>>
		///	One (1) attempt is made by default. A maximum of three (3) attempts can be made.
		/// </remarks>
		[JsonPropertyName("retry")]
		public byte RetryAttempts { get; init; }

		/// <summary>
		/// The review invitation's scheduled send timestamp.
		/// </summary>
		[JsonPropertyName("send_datetime")]
		public DateTimeOffset SendAt { get; init; }

		/// <summary>
		/// The review invitation's email template.
		/// </summary>
		/// <remarks>
		///	The built-in account template is used by default. If a custom template is used, it must contain the following keys:
		///	<list type="bullet">
		///		<item>
		///			<term>subject</term>
		///			<description>The email's subject.</description>
		///		</item>
		///		<item>
		///			<term>html</term>
		///			<description>The email's HTML content.</description>
		///		</item>
		///		<item>
		///			<term>text</term>
		///			<description>The email's text content.</description>
		///		</item>
		///	</list>
		///	The following placeholders can be added to the HTML or text content:
		///	<list type="bullet">
		///		<item>
		///			<term>name</term>
		///			<description>Use {{name}} to specify the placeholder for the recepient's name.</description>
		///		</item>
		///		<item>
		///			<term>company_name</term>
		///			<description>Use {{company_name}} to specify the placeholder for the sending company's name.</description>
		///		</item>
		///		<item>
		///			<term>review_link</term>
		///			<description>Use {{review_link}} to specify the placeholder for the email's generated review link.</description>
		///		</item>
		///	</list>
		/// When specifying the language, make sure to have a <c>locale</c> key and use the <c>Language</c> enum to specify the value AND use the enum's <c>ToStringFast()</c> extension to write the value.
		/// </remarks>
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
		/// The response's errors, if any.
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