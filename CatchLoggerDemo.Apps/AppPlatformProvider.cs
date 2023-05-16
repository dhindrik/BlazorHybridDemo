using System;
using CatchLoggerDemo.Core.Helpers;

namespace CatchLoggerDemo.Apps
{
    public class AppPlatformProvider : IPlatformInfoProvider
    {
        public TypeOfPlatform TypeOfPlatform => TypeOfPlatform.App;
    }
}

