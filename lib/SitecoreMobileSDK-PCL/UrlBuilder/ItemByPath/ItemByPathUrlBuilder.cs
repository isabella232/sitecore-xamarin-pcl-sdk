﻿namespace Sitecore.MobileSDK.UrlBuilder.ItemByPath
{
  using Sitecore.MobileSDK.API.Request;
  using Sitecore.MobileSDK.UrlBuilder.Rest;
  using Sitecore.MobileSDK.UrlBuilder.WebApi;
  using Sitecore.MobileSDK.Utils;
  using Sitecore.MobileSDK.Validators;

  public class ItemByPathUrlBuilder : GetPagedItemsUrlBuilder<IReadItemsByPathRequest>
  {
    public ItemByPathUrlBuilder(IRestServiceGrammar restGrammar, IWebApiUrlParameters webApiGrammar)
      : base(restGrammar, webApiGrammar)
    {
    }

    protected override string GetHostUrlForRequest(IReadItemsByPathRequest request)
    {
      string hostUrl = base.GetHostUrlForRequest(request);
      string result = hostUrl;

      return result;
    }

    protected override string GetItemIdenticationForRequest(IReadItemsByPathRequest request)
    {
      string escapedPath = UrlBuilderUtils.EscapeDataString(request.ItemPath.ToLowerInvariant());
      string strItemPath = this.webApiGrammar.ItemPathParameterName + this.restGrammar.KeyValuePairSeparator + escapedPath;
      string lowerCaseItemPath = strItemPath.ToLowerInvariant();

      return lowerCaseItemPath;
    }

    protected override void ValidateSpecificRequest(IReadItemsByPathRequest request)
    {
      base.ValidateSpecificRequest(request);
      ItemPathValidator.ValidateItemPath(request.ItemPath, this.GetType().Name + ".ItemPath");
    }
  }
}
