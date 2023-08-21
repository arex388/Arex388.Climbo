using FluentValidation.Results;

namespace Arex388.Climbo;

/// <summary>
/// <c>DeleteReviewInvitation</c> request and response container.
/// </summary>
public sealed class DeleteReviewInvitation {
	private static Response? _cancelled;
	private static Response? _failed;
	private static Response? _timedOut;

	internal static Response Cancelled => _cancelled ??= new Response {
		Status = ResponseStatus.Cancelled
	};
	internal static Response Failed(
		Exception? exception) => exception is null
		? _failed ??= new Response {
			Status = ResponseStatus.Failed
		}
		: Failed($"[{exception.GetType().Name}] {exception.Message}");
	internal static Response Failed(
		string error) => new() {
		Errors = new[] {
			error
		},
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
	/// <c>DeleteReviewInvitation</c> request container.
	/// </summary>
	public sealed class Request {
		/// <summary>
		/// The invitation's id.
		/// </summary>
		public ReviewInvitationId Id { get; init; }
	}

	/// <summary>
	/// <c>DeleteReviewInvitation</c> response container.
	/// </summary>
	public sealed class Response {
		/// <summary>
		/// The response's errors, if any.
		/// </summary>
		public IEnumerable<string> Errors { get; init; } = Enumerable.Empty<string>();

		/// <summary>
		/// The response's status.
		/// </summary>
		public ResponseStatus Status { get; init; }
	}
}