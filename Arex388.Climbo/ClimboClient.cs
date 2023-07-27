using Arex388.Climbo.Extensions;
using Arex388.Climbo.Validators;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

//	ReSharper disable MethodHasAsyncOverloadWithCancellation

namespace Arex388.Climbo;

/// <summary>
/// Arex388.Climbo.com API client.
/// </summary>
public sealed class ClimboClient :
	IClimboClient {
	private static readonly JsonSerializerOptions _jsonSerializerOptions = new() {
		DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
		PropertyNamingPolicy = JsonNamingPolicy.CamelCase
	};

	private const string _endpointHost = "https://server.onlinereviews.tech/public-api/v1.0.0";

	private readonly AccountId _accountId;
	private readonly HttpClient _httpClient;

	private DeleteReviewInvitationRequestValidator? _deleteReviewInvitationRequestValidator;
	private GetReviewInvitationRequestValidator? _getReviewInvitationRequestValidator;
	private PutReviewInvitationRequestValidator? _putReviewInvitationRequestValidator;

	/// <summary>
	/// Create an instance of the Arex388.Climbo.com API client.
	/// </summary>
	/// <param name="httpClient">An instance of <c>HttpClient</c>.</param>
	///	<param name="accountId">The account's id.</param>
	public ClimboClient(
		AccountId accountId,
		HttpClient httpClient) {
		_accountId = accountId;
		_httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
	}

	//	============================================================================
	//	Actions
	//	============================================================================

	/// <summary>
	/// Deletes a review invitation.
	/// </summary>
	/// <param name="id">The review invitation's id.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>DeleteReviewInvitation.Response</c>.</returns>
	public Task<DeleteReviewInvitation.Response> DeleteReviewInvitationAsync(
		ReviewInvitationId id,
		CancellationToken cancellationToken = default) => DeleteReviewInvitationAsync(new DeleteReviewInvitation.Request {
			Id = id
		}, cancellationToken);

	/// <summary>
	/// Deletes a review invitation.
	/// </summary>
	/// <param name="request">An instance of <c>DeleteReviewInvitation.Request</c> containing the request's parameters.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>DeleteReviewInvitation.Response</c>.</returns>
	public async Task<DeleteReviewInvitation.Response> DeleteReviewInvitationAsync(
		DeleteReviewInvitation.Request request,
		CancellationToken cancellationToken = default) {
		if (cancellationToken.IsCancellationRequested) {
			return DeleteReviewInvitation.Cancelled;
		}

		var validator = _deleteReviewInvitationRequestValidator ??= new DeleteReviewInvitationRequestValidator();
		var validation = validator.Validate(request);

		if (!validation.IsValid) {
			return DeleteReviewInvitation.Invalid(validation);
		}

		if (cancellationToken.IsCancellationRequested) {
			return DeleteReviewInvitation.Cancelled;
		}

		try {
			var response = await _httpClient.DeleteAsync($"{_endpointHost}/{request.GetEndpoint()}", cancellationToken).ConfigureAwait(false);

			return new DeleteReviewInvitation.Response {
				Status = response.IsSuccessStatusCode
					? ResponseStatus.Succeeded
					: ResponseStatus.Failed
			};
		} catch (TaskCanceledException) {
			return DeleteReviewInvitation.TimedOut;
		} catch (Exception e) {
			return DeleteReviewInvitation.Failed(e);
		}
	}

	/// <summary>
	/// Returns a review invitation.
	/// </summary>
	/// <param name="id">The review invitation's id.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>GetReviewInvitation.Response</c>.</returns>
	public Task<GetReviewInvitation.Response> GetReviewInvitationAsync(
		ReviewInvitationId id,
		CancellationToken cancellationToken = default) => GetReviewInvitationAsync(new GetReviewInvitation.Request {
			Id = id
		}, cancellationToken);

	/// <summary>
	/// Returns a review invitation.
	/// </summary>
	/// <param name="request">An instance of <c>GetReviewInvitation.Request</c> containing the request's parameters.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>GetReviewInvitation.Response</c>.</returns>
	public async Task<GetReviewInvitation.Response> GetReviewInvitationAsync(
		GetReviewInvitation.Request request,
		CancellationToken cancellationToken = default) {
		if (cancellationToken.IsCancellationRequested) {
			return GetReviewInvitation.Cancelled;
		}

		var validator = _getReviewInvitationRequestValidator ??= new GetReviewInvitationRequestValidator();
		var validation = validator.Validate(request);

		if (!validation.IsValid) {
			return GetReviewInvitation.Invalid(validation);
		}

		if (cancellationToken.IsCancellationRequested) {
			return GetReviewInvitation.Cancelled;
		}

		try {
			var reviewInvitation = await _httpClient.GetFromJsonAsync<ReviewInvitation>($"{_endpointHost}/{request.GetEndpoint()}", cancellationToken).ConfigureAwait(false);

			return new GetReviewInvitation.Response {
				ReviewInvitation = reviewInvitation,
				Status = ResponseStatus.Succeeded
			};
		} catch (TaskCanceledException) {
			return GetReviewInvitation.TimedOut;
		} catch (Exception e) {
			return GetReviewInvitation.Failed(e);
		}
	}

	/// <summary>
	/// Returns review statistics for the account.
	/// </summary>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>GetReviewStatistics.Response</c>.</returns>
	public async Task<GetReviewStatistics.Response> GetReviewStatisticsAsync(
		CancellationToken cancellationToken = default) {
		if (cancellationToken.IsCancellationRequested) {
			return GetReviewStatistics.Cancelled;
		}

		var request = new GetReviewStatistics.Request {
			Id = _accountId
		};

		if (cancellationToken.IsCancellationRequested) {
			return GetReviewStatistics.Cancelled;
		}

		try {
			var reviewStatistics = await _httpClient.GetFromJsonAsync<GetReviewStatistics.Wrapper>($"{_endpointHost}/{request.GetEndpoint()}", cancellationToken).ConfigureAwait(false);

			return new GetReviewStatistics.Response {
				Statistics = reviewStatistics!.Statistics,
				Status = ResponseStatus.Succeeded
			};
		} catch (TaskCanceledException) {
			return GetReviewStatistics.TimedOut;
		} catch (Exception e) {
			return GetReviewStatistics.Failed(e);
		}
	}

	/// <summary>
	/// Schedule a review invitation to be sent.
	/// </summary>
	/// <param name="request">An instance of <c>PutReviewInvitation.Request</c> containing the request's parameters.</param>
	/// <param name="cancellationToken">The cancellation token.</param>
	/// <returns>An instance of <c>PutReviewInvitation.Response</c>.</returns>
	public async Task<PutReviewInvitation.Response> PutReviewInvitationAsync(
		PutReviewInvitation.Request request,
		CancellationToken cancellationToken = default) {
		if (cancellationToken.IsCancellationRequested) {
			return PutReviewInvitation.Cancelled;
		}

		request.AccountId = _accountId;

		var validator = _putReviewInvitationRequestValidator ??= new PutReviewInvitationRequestValidator();
		var validation = validator.Validate(request);

		if (!validation.IsValid) {
			return PutReviewInvitation.Invalid(validation);
		}

		if (cancellationToken.IsCancellationRequested) {
			return PutReviewInvitation.Cancelled;
		}

		try {
			var response = await _httpClient.PutAsJsonAsync($"{_endpointHost}/review/invitation", request, _jsonSerializerOptions, cancellationToken).ConfigureAwait(false);
			var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			var reviewInvitation = await JsonSerializer.DeserializeAsync<ReviewInvitation>(content, _jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

			return new PutReviewInvitation.Response {
				ReviewInvitation = reviewInvitation!,
				Status = ResponseStatus.Succeeded
			};
		} catch (TaskCanceledException) {
			return PutReviewInvitation.TimedOut;
		} catch (Exception e) {
			return PutReviewInvitation.Failed(e);
		}
	}
}