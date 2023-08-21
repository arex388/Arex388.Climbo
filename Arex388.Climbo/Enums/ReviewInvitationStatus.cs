namespace Arex388.Climbo;

/// <summary>
/// The review invitation's status.
/// </summary>
public enum ReviewInvitationStatus :
	byte {
	/// <summary>
	/// The invitation was sent.
	/// </summary>
	Sent,

	/// <summary>
	/// The invitation's status is unknown.
	/// </summary>
	Unknown,

	/// <summary>
	/// The invitation is waiting to be sent.
	/// </summary>
	Waiting
}