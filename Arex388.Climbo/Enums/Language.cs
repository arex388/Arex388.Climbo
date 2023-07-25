using NetEscapades.EnumGenerators;
using System.ComponentModel.DataAnnotations;

namespace Arex388.Climbo;

/// <summary>
/// The response language.
/// </summary>
[EnumExtensions]
public enum Language :
	byte {
	/// <summary>
	/// Danish.
	/// </summary>
	[Display(Name = "dk")]
	Danish,

	/// <summary>
	/// Dutch.
	/// </summary>
	[Display(Name = "nl")]
	Dutch,

	/// <summary>
	/// English.
	/// </summary>
	[Display(Name = "en")]
	English,

	/// <summary>
	/// French.
	/// </summary>
	[Display(Name = "fr")]
	French,

	/// <summary>
	/// German.
	/// </summary>
	[Display(Name = "de")]
	German,

	/// <summary>
	/// Italian.
	/// </summary>
	[Display(Name = "it")]
	Italian,

	/// <summary>
	/// Norwegian.
	/// </summary>
	[Display(Name = "no")]
	Norwegian,

	/// <summary>
	/// Polish.
	/// </summary>
	[Display(Name = "pl")]
	Polish,

	/// <summary>
	/// Portuguese.
	/// </summary>
	[Display(Name = "pt")]
	Portuguese,

	/// <summary>
	/// Spanish.
	/// </summary>
	[Display(Name = "es")]
	Spanish
}