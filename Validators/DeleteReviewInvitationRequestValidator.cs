using FluentValidation;

namespace Arex388.Climbo.Validators;

internal sealed class DeleteReviewInvitationRequestValidator :
	AbstractValidator<DeleteReviewInvitation.Request> {
	public DeleteReviewInvitationRequestValidator() {
		RuleFor(_ => _.Id).NotEmpty();
	}
}