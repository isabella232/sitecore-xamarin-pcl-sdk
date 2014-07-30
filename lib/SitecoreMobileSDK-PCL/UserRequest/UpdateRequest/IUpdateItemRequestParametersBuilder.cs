﻿
namespace Sitecore.MobileSDK
{
  using System;
  using System.Collections.Generic;
  using Sitecore.MobileSDK.API.Request;
  using Sitecore.MobileSDK.API.Request.Parameters;

  public interface IUpdateItemRequestParametersBuilder<T> : IBaseRequestParametersBuilder<T>
    where T : class
  {
    IUpdateItemRequestParametersBuilder<T> AddFieldsRawValuesByName (IDictionary<string, string> fieldsRawValuesByName);
    IUpdateItemRequestParametersBuilder<T> AddFieldsRawValuesByName (string fieldKey, string fieldValue);

    new IUpdateItemRequestParametersBuilder<T> Database(string sitecoreDatabase);
    new IUpdateItemRequestParametersBuilder<T> Language(string itemLanguage);
    new IUpdateItemRequestParametersBuilder<T> Payload(PayloadType payload);

    new IUpdateItemRequestParametersBuilder<T> AddFields(ICollection<string> fields);
    new IUpdateItemRequestParametersBuilder<T> AddFields(params string[] fieldParams);

    new IUpdateItemRequestParametersBuilder<T> AddScope(ICollection<ScopeType> scope);
    new IUpdateItemRequestParametersBuilder<T> AddScope(params ScopeType[] scope);
  }
}

