using System.Text.Json;
using System.Text.Json.Serialization;

namespace Arex388.Climbo;

/// <summary>
/// Account id struct.
/// </summary>
[JsonConverter(typeof(AccountIdSystemTextJsonConverter))]
public readonly struct AccountId :
	IComparable<AccountId>,
	IEquatable<AccountId> {
	public string Value { get; }

	public AccountId(
		string value) => Value = value ?? throw new ArgumentNullException(nameof(value));

	public int CompareTo(
		AccountId other) => (Value, other.Value) switch {
			(null, null) => 0,
			(null, _) => -1,
			(_, null) => 1,
			(_, _) => string.Compare(Value, other.Value, StringComparison.Ordinal)
		};

	public static readonly AccountId Empty = new(string.Empty);

	public bool Equals(
		AccountId other) => (Value, other.Value) switch {
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

		return obj is AccountId other && Equals(other);
	}

	public override int GetHashCode() => Value.GetHashCode();

	public override string ToString() => Value;

	public static bool operator ==(AccountId a, AccountId b) => a.Equals(b);
	public static bool operator !=(AccountId a, AccountId b) => !(a == b);

	internal sealed class AccountIdSystemTextJsonConverter :
		JsonConverter<AccountId> {
		public override AccountId Read(
			ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options) => new(reader.GetString()!);

		public override void Write(
			Utf8JsonWriter writer,
			AccountId value,
			JsonSerializerOptions options) => writer.WriteStringValue(value.Value);
	}
}