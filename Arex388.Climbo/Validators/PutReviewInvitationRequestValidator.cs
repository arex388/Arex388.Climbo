using FluentValidation;

namespace Arex388.Climbo.Validators;

internal sealed class PutReviewInvitationRequestValidator :
	AbstractValidator<PutReviewInvitation.Request> {
	public PutReviewInvitationRequestValidator() {
		RuleFor(r => r.Email).EmailAddress().NotEmpty();
		RuleFor(r => r.Name).NotEmpty();
		RuleFor(r => r.RetryAttempts).LessThanOrEqualTo((byte)3);
		RuleFor(r => r.AccountId).NotEmpty();
		RuleFor(r => r.SendAt).NotEmpty();
	}
}