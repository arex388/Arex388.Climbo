using System.Text.Json.Serialization;

namespace Arex388.Climbo;

/// <summary>
/// <c>GetReviewStatistics</c> request and response containers.
/// </summary>
public sealed class GetReviewStatistics {
	private static Response? _cancelled;
	private static Response? _failed;
	private static Response? _timedOut;

	internal static Response Cancelled => _cancelled ??= new Response {
		Status = ResponseStatus.Cancelled
	};
	internal static Response Failed => _failed ??= new Response {
		Status = ResponseStatus.Failed
	};
	internal static Response TimedOut => _timedOut ??= new Response {
		Status = ResponseStatus.TimedOut
	};

	/// <summary>
	/// <c>GetReviewStatistics</c> request container.
	/// </summary>
	internal sealed class Request {
		/// <summary>
		/// The account's id.
		/// </summary>
		public AccountId Id { get; init; }
	}

	/// <summary>
	/// <c>GetReviewStatistics</c> response container.
	/// </summary>
	public sealed class Response {
		/// <summary>
		/// List of statistics.
		/// </summary>
		public IList<Statistic> Statistics { get; init; } = new List<Statistic>(0);

		/// <summary>
		/// The response's status.
		/// </summary>
		public ResponseStatus Status { get; init; }
	}

	internal sealed class Wrapper {
		[JsonPropertyName("stat")]
		public IList<Statistic> Statistics { get; init; } = new List<Statistic>(0);
	}
}