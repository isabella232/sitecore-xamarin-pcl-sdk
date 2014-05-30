﻿using System;

namespace Sitecore.MobileSDK.UrlBuilder
{
    public interface IRestServiceGrammar
    {
        string PathComponentSeparator { get; }
        string KeyValuePairSeparator { get; }
        string FieldSeparator        { get; }
        string HostAndArgsSeparator { get; }
    }
}

