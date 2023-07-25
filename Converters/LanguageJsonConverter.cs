using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.Climbo.Converters;

internal sealed class LanguageJsonConverter :
	JsonConverter<Language> {
	public override Language Read(
		ref Utf8JsonReader reader,
		Type typeToConvert,
		JsonSerializerOptions options) => throw new NotImplementedException("You should never see this exception.");

	public override void Write(
		Utf8JsonWriter writer,
		Language value,
		JsonSerializerOptions options) => writer.WriteStringValue(value.ToStringFast());
}