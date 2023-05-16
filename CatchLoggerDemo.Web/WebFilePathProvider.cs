using System;
using System.Reflection;
using CatchLoggerDemo.Core.Helpers;

namespace CatchLoggerDemo.Web;

public class WebFilePathProvider : IFilePathProvider
	{
    public string GetPathForDb() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
}

