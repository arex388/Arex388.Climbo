using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.Climbo.Converters;

internal sealed class ReviewInvitationStatusJsonConverter :
	JsonConverter<ReviewInvitationStatus> {
	public override ReviewInvitationStatus Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) => reader.GetString() switch {
			"sent" => ReviewInvitationStatus.Sent,
			"waiting" => ReviewInvitationStatus.Waiting,
			_ => ReviewInvitationStatus.Unknown
		};

	public override void Write(
		Utf8JsonWriter writer,
		ReviewInvitationStatus value,
		JsonSerializerOptions options) => throw new NotImplementedException("You should never see this exception.");
}