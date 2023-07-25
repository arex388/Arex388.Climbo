namespace Arex388.Climbo.Extensions;

internal static class PutReviewInvitaionExtensions {
	public static string GetEndpoint(
		this PutReviewInvitation.Request request) => $"review/invitation";
}