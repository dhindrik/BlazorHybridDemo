using System;
using CatchLoggerDemo.Core.Helpers;

namespace CatchLoggerDemo.Web;

public class WebPlatformInfoProvider : IPlatformInfoProvider
{
    public WebPlatformInfoProvider()
    {
    }

    public TypeOfPlatform TypeOfPlatform => TypeOfPlatform.Web;
}

