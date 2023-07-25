namespace Arex388.Climbo;

/// <summary>
/// Climbo.com API client.
/// </summary>
public interface IClimboClient {
	/// <summary>
	/// Deletes a review invitation.
	/// </summary>
	/// <param name="id">The review invitation's id.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>DeleteReviewInvitation.Response</c>.</returns>
	Task<DeleteReviewInvitation.Response> DeleteReviewInvitationAsync(
		ReviewInvitationId id,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Deletes a review invitation.
	/// </summary>
	/// <param name="request">An instance of <c>DeleteReviewInvitation.Request</c> containing the request's parameters.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>DeleteReviewInvitation.Response</c>.</returns>
	Task<DeleteReviewInvitation.Response> DeleteReviewInvitationAsync(
		DeleteReviewInvitation.Request request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Returns a review invitation.
	/// </summary>
	/// <param name="id">The review invitation's id.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>GetReviewInvitation.Response</c>.</returns>
	Task<GetReviewInvitation.Response> GetReviewInvitationAsync(
		ReviewInvitationId id,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Returns a review invitation.
	/// </summary>
	/// <param name="request">An instance of <c>GetReviewInvitation.Request</c> containing the request's parameters.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>GetReviewInvitation.Response</c>.</returns>
	Task<GetReviewInvitation.Response> GetReviewInvitationAsync(
		GetReviewInvitation.Request request,
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Returns review statistics for the account.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>GetReviewStatistics.Response</c>.</returns>
	Task<GetReviewStatistics.Response> GetReviewStatisticsAsync(
		CancellationToken cancellationToken = default);

	/// <summary>
	/// Schedule a review invitation to be sent.
	/// </summary>
	/// <param name="request">An instance of <c>PutReviewInvitation.Request</c> containing the request's parameters.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>PutReviewInvitation.Response</c>.</returns>
	Task<PutReviewInvitation.Response> PutReviewInvitationAsync(
		PutReviewInvitation.Request request,
		CancellationToken cancellationToken = default);
}