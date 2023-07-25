namespace Arex388.Climbo.Extensions;

internal static class GetReviewInvitationExtensions {
	public static string GetEndpoint(
		this GetReviewInvitation.Request request) => $"review/invitation/{request.Id}";
}