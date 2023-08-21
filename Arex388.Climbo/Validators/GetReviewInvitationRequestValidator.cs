using FluentValidation;

namespace Arex388.Climbo.Validators;

internal sealed class GetReviewInvitationRequestValidator :
	AbstractValidator<GetReviewInvitation.Request> {
	public GetReviewInvitationRequestValidator() {
		RuleFor(r => r.Id).NotEmpty();
	}
}