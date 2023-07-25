using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.Climbo;

/// <summary>
/// Review Invitation id struct.
/// </summary>
[JsonConverter(typeof(ReviewInvitationIdSystemTextJsonConverter))]
public readonly struct ReviewInvitationId :
	IComparable<ReviewInvitationId>,
	IEquatable<ReviewInvitationId> {
	public string Value { get; }

	public ReviewInvitationId(
		string value) => Value = value ?? throw new ArgumentNullException(nameof(value));

	public int CompareTo(
		ReviewInvitationId other) => (Value, other.Value) switch {
			(null, null) => 0,
			(null, _) => -1,
			(_, null) => 1,
			(_, _) => string.Compare(Value, other.Value, StringComparison.Ordinal)
		};

	public static readonly ReviewInvitationId Empty = new(string.Empty);

	public bool Equals(
		ReviewInvitationId other) => (Value, other.Value) switch {
			(null, null) => true,
			(null, _) => false,
			(_, null) => false,
			(_, _) => Value.Equals(other.Value),
		};

	public override bool Equals(
		object? obj) {
		if (obj is null) {
			return false;
		}

		return obj is ReviewInvitationId other && Equals(other);
	}

	public override int GetHashCode() => Value.GetHashCode();

	public override string ToString() => Value;

	public static bool operator ==(ReviewInvitationId a, ReviewInvitationId b) => a.Equals(b);
	public static bool operator !=(ReviewInvitationId a, ReviewInvitationId b) => !(a == b);

	internal sealed class ReviewInvitationIdSystemTextJsonConverter :
		JsonConverter<ReviewInvitationId> {
		public override ReviewInvitationId Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) => new(reader.GetString()!);

		public override void Write(
			Utf8JsonWriter writer,
			ReviewInvitationId value,
			JsonSerializerOptions options) => writer.WriteStringValue(value.Value);
	}
}