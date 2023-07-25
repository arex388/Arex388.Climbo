namespace Arex388.Climbo.Extensions;

internal static class DeleteReviewInvitationExtensions {
	public static string GetEndpoint(
		this DeleteReviewInvitation.Request request) => $"review/invitation/{request.Id}";
}