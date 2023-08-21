using Xunit;

namespace Arex388.Climbo.Tests;

public sealed class ReviewInvitation {
	private readonly IClimboClient _climbo;
	private readonly PutReviewInvitation.Request _putRequest;

	public ReviewInvitation() {
		var httpClient = new HttpClient();

		httpClient.DefaultRequestHeaders.Add("x-api-key", Config.ClimboKey);

		_climbo = new ClimboClient(Config.ClimboAccountId1, httpClient);
		_putRequest = new PutReviewInvitation.Request {
			Email = Config.RecipientEmail,
			Name = Config.RecipientName,
			SendAt = DateTimeOffset.Now.AddMinutes(1)
		};
	}

	[Fact]
	public async Task GetAsync() {
		var put = await _climbo.PutReviewInvitationAsync(_putRequest).ConfigureAwait(false);
		var get = await _climbo.GetReviewInvitationAsync(put.ReviewInvitation.Id).ConfigureAwait(false);

		Assert.Equal(ResponseStatus.Succeeded, put.Status);
		Assert.Equal(ResponseStatus.Succeeded, get.Status);
	}

	[Fact]
	public async Task DeleteAsync() {
		var put = await _climbo.PutReviewInvitationAsync(_putRequest).ConfigureAwait(false);
		var delete = await _climbo.DeleteReviewInvitationAsync(put.ReviewInvitation.Id).ConfigureAwait(false);

		Assert.Equal(ResponseStatus.Succeeded, put.Status);
		Assert.Equal(ResponseStatus.Succeeded, delete.Status);
	}

	[Fact]
	public async Task PutAsync() {
		var response = await _climbo.PutReviewInvitationAsync(_putRequest).ConfigureAwait(false);

		Assert.Equal(ResponseStatus.Succeeded, response.Status);
	}
}