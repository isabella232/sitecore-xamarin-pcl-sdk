namespace Sitecore.MobileSDK.API.Fields
{
  /// <summary>
  /// The IField interface represents a single field of the Sitecore Item.
  /// Fields have the content that will actually be presented to the user.
  /// 
  /// Fields are readonly and immutable. If you need to modify the content you should send a new request using the session.
  /// </summary>
  public interface IField
  {
    /// <summary>
    /// Returns field's GUID. Item Web API service returns GUID values enclosed in curly braces.
    /// For example : "{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}"
    /// 
    /// Field's id is case insensitive.
    /// </summary>
    string FieldId { get; }

    /// <summary>
    /// Returns field's name.
    ///
    /// Field's name is case insensitive.
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// Returns field's type. Possible values are :
    /// * Text
    /// * Image
    /// * Rich Text
    /// * Checkbox
    /// * Date
    /// * Datetime
    /// * Multilist
    /// * Treelist
    /// * Checklist
    /// * Droplink
    /// * Droptree
    /// * General Link
    /// * Single-Line Text
    /// </summary>
    string Type { get; }
    
    /// <summary>
    /// Returns field's raw value.
    /// </summary>
    string RawValue { get; }
  }
}

