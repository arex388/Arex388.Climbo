namespace Arex388.Climbo.Extensions;

internal static class GetReviewStatisticsExtensions {
	public static string GetEndpoint(
		this GetReviewStatistics.Request request) => $"review/stats/{request.Id}";
}