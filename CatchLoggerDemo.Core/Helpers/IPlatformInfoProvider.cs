using System;
namespace CatchLoggerDemo.Core.Helpers;

public interface IPlatformInfoProvider
{
	public TypeOfPlatform TypeOfPlatform { get; }
}

public enum TypeOfPlatform
{
	App,
	Web,
	Test
}

