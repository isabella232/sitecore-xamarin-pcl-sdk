﻿namespace Sitecore.MobileSdkUnitTest
{
  using System;
  using System.Collections.Generic;
  using NUnit.Framework;
  using Sitecore.MobileSDK.API;
  using Sitecore.MobileSDK.API.Request;
  using Sitecore.MobileSDK.API.Request.Parameters;
  using Sitecore.MobileSDK.Items;
  using Sitecore.MobileSDK.MockObjects;
  using Sitecore.MobileSDK.SessionSettings;
  using Sitecore.MobileSDK.UrlBuilder.CreateItem;
  using Sitecore.MobileSDK.UrlBuilder.Rest;
  using Sitecore.MobileSDK.UrlBuilder.WebApi;
  using Sitecore.MobileSDK.UserRequest;

  [TestFixture]
  public class CreateItemByIdUrlBuilderTests
  {
    private CreateItemByIdUrlBuilder builder;
    private UserRequestMerger requestMerger;

    [SetUp]
    public void SetUp()
    {
      IRestServiceGrammar restGrammar = RestServiceGrammar.ItemWebApiV2Grammar();
      IWebApiUrlParameters webApiGrammar = WebApiUrlParameters.ItemWebApiV2UrlParameters();

      this.builder = new CreateItemByIdUrlBuilder(restGrammar, webApiGrammar);

      SessionConfigPOD mutableSessionConfig = new SessionConfigPOD();
      mutableSessionConfig.ItemWebApiVersion = "v234";
      mutableSessionConfig.InstanceUrl = "mobiledev1ua1.dk.sitecore.net:7119";
      mutableSessionConfig.Site = "/sitecore/shell";

      ItemSource source = LegacyConstants.DefaultSource();
      this.requestMerger = new UserRequestMerger(mutableSessionConfig, source);

    }

    [TearDown]
    public void TearDown()
    {
      this.builder = null;
    }

    [Test]
    public void TestCorrectParamsWithoutFields()
    {
      ICreateItemByIdRequest request = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
        .ItemTemplatePath("/Sample/Sample Item")
        .ItemName("item name")
        .Build();

      ICreateItemByIdRequest autocompletedRequest = this.requestMerger.FillCreateItemByIdGaps(request);

      string result = this.builder.GetUrlForRequest(autocompletedRequest);
      string expected = "http://mobiledev1ua1.dk.sitecore.net:7119/-/item/v234%2fsitecore%2fshell" +
        "?sc_database=web" +
        "&language=en" +
        "&template=sample%2fsample%20item" +
        "&name=item%20name" +
        "&sc_itemid=%7b110d559f-dea5-42ea-9c1c-8a5df7e70ef9%7d";

      string fieldsResult = this.builder.GetFieldValuesList(autocompletedRequest);
      string expectedFieldsResult = "";

      Assert.AreEqual(expected, result);
      Assert.AreEqual(expectedFieldsResult, fieldsResult);
    }

    [Test]
    public void TestCorrectParamsWithFields()
    {
      ICreateItemByIdRequest request = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
        .ItemTemplatePath("/Sample/Sample Item")
        .ItemName("item name")
        .AddFieldsRawValuesByNameToSet("field1", "value1")
        .AddFieldsRawValuesByNameToSet("field2", "value2")
        .Build();

      ICreateItemByIdRequest autocompletedRequest = this.requestMerger.FillCreateItemByIdGaps(request);

      string result = this.builder.GetUrlForRequest(autocompletedRequest);
      string expected = "http://mobiledev1ua1.dk.sitecore.net:7119/-/item/v234%2fsitecore%2fshell" +
        "?sc_database=web" +
        "&language=en" +
        "&template=sample%2fsample%20item" +
        "&name=item%20name" +
        "&sc_itemid=%7b110d559f-dea5-42ea-9c1c-8a5df7e70ef9%7d";

      string fieldsResult = this.builder.GetFieldValuesList(autocompletedRequest);
      string expectedFieldsResult = "field1=value1&field2=value2";

      Assert.AreEqual(expected, result);
      Assert.AreEqual(expectedFieldsResult, fieldsResult);
    }

    [Test]
    public void TestFieldsValuesIsCaseInsensitive()
    {
      ICreateItemByIdRequest request = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
        .ItemTemplatePath("/Sample/Sample Item")
        .ItemName("item name")
        .AddFieldsRawValuesByNameToSet("field1", "VaLuE1")
        .AddFieldsRawValuesByNameToSet("field2", "VaLuE2")
        .Build();

      ICreateItemByIdRequest autocompletedRequest = this.requestMerger.FillCreateItemByIdGaps(request);

      string result = this.builder.GetUrlForRequest(autocompletedRequest);
      string expected = "http://mobiledev1ua1.dk.sitecore.net:7119/-/item/v234%2fsitecore%2fshell" +
        "?sc_database=web" +
        "&language=en" +
        "&template=sample%2fsample%20item" +
        "&name=item%20name" +
        "&sc_itemid=%7b110d559f-dea5-42ea-9c1c-8a5df7e70ef9%7d";

      string fieldsResult = this.builder.GetFieldValuesList(autocompletedRequest);
      string expectedFieldsResult = "field1=VaLuE1&field2=VaLuE2";

      Assert.AreEqual(expected, result);
      Assert.AreEqual(expectedFieldsResult, fieldsResult);
    }

    [Test]
    public void TestItemNameIsCaseInsensitive()
    {
      ICreateItemByIdRequest request = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
        .ItemTemplatePath("/Sample/Sample Item")
        .ItemName("ItEmNaMe")
        .AddFieldsRawValuesByNameToSet("field1", "VaLuE1")
        .AddFieldsRawValuesByNameToSet("field2", "VaLuE2")
        .Build();

      ICreateItemByIdRequest autocompletedRequest = this.requestMerger.FillCreateItemByIdGaps(request);

      string result = this.builder.GetUrlForRequest(autocompletedRequest);
      string expected = "http://mobiledev1ua1.dk.sitecore.net:7119/-/item/v234%2fsitecore%2fshell" +
        "?sc_database=web" +
        "&language=en" +
        "&template=sample%2fsample%20item" +
        "&name=ItEmNaMe" +
        "&sc_itemid=%7b110d559f-dea5-42ea-9c1c-8a5df7e70ef9%7d";

      string fieldsResult = this.builder.GetFieldValuesList(autocompletedRequest);
      string expectedFieldsResult = "field1=VaLuE1&field2=VaLuE2";

      Assert.AreEqual(expected, result);
      Assert.AreEqual(expectedFieldsResult, fieldsResult);
    }

    [Test]
    public void TestFieldWithDuplicatedKeyWillCrash()
    {
      var requestBuilder = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
        .ItemTemplatePath("/Sample/Sample Item")
        .ItemName("ItEmNaMe")
        .AddFieldsRawValuesByNameToSet("field1", "VaLuE1")
        .AddFieldsRawValuesByNameToSet("field2", "VaLuE2");

      TestDelegate action = () => requestBuilder.AddFieldsRawValuesByNameToSet("field1", "VaLuE3");
      Assert.Throws<InvalidOperationException>(action);
    }

    [Test]
    public void TestAppendingDuplicatedFieldsCausesInvalidOperationException()
    {
      var requestBuilder = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
        .ItemTemplatePath("/Sample/Sample Item")
        .ItemName("ItEmNaMe")
        .AddFieldsRawValuesByNameToSet("field1", "VaLuE1")
        .AddFieldsRawValuesByNameToSet("field2", "VaLuE2");

      TestDelegate action = () => requestBuilder.AddFieldsRawValuesByNameToSet("field1", "VaLuE3");
      Assert.Throws<InvalidOperationException>(action);
    }

    [Test]
    public void TestNameCanNotBeEmpty()
    {
      var builder = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");

      TestDelegate action = () => builder.ItemTemplatePath("Sample/Sample Item").ItemName(" ");
      Assert.Throws<ArgumentException>(action);
    }

    [Test]
    public void TestTemplateCanNotBeEmpty()
    {
      var builder = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}");

      TestDelegate action = () => builder.ItemTemplatePath(" ");
      Assert.Throws<ArgumentException>(action);
    }

    [Test]
    public void TestFieldsAppending()
    {
      Dictionary<string, string> fields = new Dictionary<string, string>();
      fields.Add("field1", "VaLuE1");
      fields.Add("field2", "VaLuE2");

      ICreateItemByIdRequest request = ItemWebApiRequestBuilder.CreateItemRequestWithParentId("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")
        .ItemTemplatePath("/Sample/Sample Item")
        .ItemName("ItEmNaMe")
        .Database("db")
        .Language("lg")
        .Payload(PayloadType.Full)
        .AddFieldsRawValuesByNameToSet(fields)
        .AddFieldsRawValuesByNameToSet("field3", "VaLuE3")
        .Build();

      ICreateItemByIdRequest autocompletedRequest = this.requestMerger.FillCreateItemByIdGaps(request);

      string result = this.builder.GetUrlForRequest(autocompletedRequest);
      string expected =
        "http://mobiledev1ua1.dk.sitecore.net:7119/-/item/v234%2fsitecore%2fshell" +
        "?sc_database=db" +
        "&language=lg" +
        "&payload=full" +
        "&template=sample%2fsample%20item" +
        "&name=ItEmNaMe" +
        "&sc_itemid=%7b110d559f-dea5-42ea-9c1c-8a5df7e70ef9%7d";

      string fieldsResult = this.builder.GetFieldValuesList(autocompletedRequest);
      string expectedFieldsResult = "field1=VaLuE1&field2=VaLuE2&field3=VaLuE3";

      Assert.AreEqual(expected, result);
      Assert.AreEqual(expectedFieldsResult, fieldsResult);
    }
  }
}
