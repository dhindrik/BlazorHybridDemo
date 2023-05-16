using CatchLoggerDemo.Core.Helpers;

namespace CatchLoggerDemo.Apps;

public class AppFilePathProvider : IFilePathProvider
{
    public string GetPathForDb() => FileSystem.Current.AppDataDirectory;
}

