using FluentValidation;

namespace Arex388.Climbo.Validators;

internal sealed class PutReviewInvitationRequestValidator :
	AbstractValidator<PutReviewInvitation.Request> {
	public PutReviewInvitationRequestValidator() {
		RuleFor(_ => _.Email).EmailAddress().NotEmpty();
		RuleFor(_ => _.Name).NotEmpty();
		RuleFor(_ => _.RetryAttempts).LessThanOrEqualTo((byte)3);
		RuleFor(_ => _.AccountId).NotEmpty();
		RuleFor(_ => _.SendAt).NotEmpty();
	}
}