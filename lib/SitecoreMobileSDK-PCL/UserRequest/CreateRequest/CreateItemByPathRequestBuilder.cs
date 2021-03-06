﻿
namespace Sitecore.MobileSDK.UserRequest.CreateRequest
{
  using Sitecore.MobileSDK.API.Request;
  using Sitecore.MobileSDK.Items;
  using Sitecore.MobileSDK.Validators;

  public class CreateItemByPathRequestBuilder : AbstractCreateItemRequestBuilder<ICreateItemByPathRequest>
  {
    public CreateItemByPathRequestBuilder(string itemPath)
    {
      ItemPathValidator.ValidateItemPath(itemPath, this.GetType().Name + ".ItemPath");
      this.ItemPath = itemPath;
    }

    public override ICreateItemByPathRequest Build()
    {
      if (!this.IsCreateFromBranch)
      {
        BaseValidator.CheckForNullAndEmptyOrThrow(this.itemParametersAccumulator.ItemName,
          this.GetType().Name + ".ItemName");
      }

      BaseValidator.CheckForNullAndEmptyOrThrow(this.itemParametersAccumulator.ItemTemplate,
        this.GetType().Name + ".ItemTemplate");

      CreateItemByPathParameters result =
        new CreateItemByPathParameters(null, this.itemSourceAccumulator, this.queryParameters, this.itemParametersAccumulator, this.ItemPath);
      return result;
    }

    private readonly string ItemPath;
  }
}

