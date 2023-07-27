using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;

namespace Arex388.Climbo.Benchmarks;

[MaxIterationCount(16), MemoryDiagnoser]
public class ReviewInvitation {
	private readonly IClimboClient _climbo;
	private readonly PutReviewInvitation.Request _putRequest;

	public ReviewInvitation() {
		var configuration = new ConfigurationBuilder().AddUserSecrets<IAssemblyMarker>().Build();
		var httpClient = new HttpClient();

		httpClient.DefaultRequestHeaders.Add("x-api-key", configuration["ClimboKey"]!);

		_climbo = new ClimboClient(new AccountId(configuration["ClimboAccountId"]!), httpClient);
		_putRequest = new PutReviewInvitation.Request {
			Email = configuration["RecepientEmail"]!,
			Name = configuration["RecepientName"]!,
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