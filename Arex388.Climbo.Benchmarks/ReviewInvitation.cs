using BenchmarkDotNet.Attributes;

namespace Arex388.Climbo.Benchmarks;

[MaxIterationCount(16), MemoryDiagnoser]
public class ReviewInvitation {
	private readonly IClimboClient _climbo;
	private readonly PutReviewInvitation.Request _putRequest;

	public ReviewInvitation() {
		var httpClient = new HttpClient();

		httpClient.DefaultRequestHeaders.Add("x-api-key", Config.ClimboKey);

		_climbo = new ClimboClient(Config.ClimboAccountId, httpClient);
		_putRequest = new PutReviewInvitation.Request {
			Email = Config.RecipientEmail,
			Name = Config.RecipientName,
			SendAt = DateTimeOffset.Now.AddMinutes(1)
		};
	}

	[Benchmark]
	public async Task GetAsync() {
		var response = await _climbo.PutReviewInvitationAsync(_putRequest).ConfigureAwait(false);

		_ = await _climbo.GetReviewInvitationAsync(response.ReviewInvitation.Id).ConfigureAwait(false);
	}

	[Benchmark]
	public async Task DeleteAsync() {
		var response = await _climbo.PutReviewInvitationAsync(_putRequest).ConfigureAwait(false);

		_ = await _climbo.DeleteReviewInvitationAsync(response.ReviewInvitation.Id).ConfigureAwait(false);
	}

	[Benchmark]
	public async Task PutAsync() {
		var response = await _climbo.PutReviewInvitationAsync(_putRequest).ConfigureAwait(false);

		_ = response.ToString();
	}
}