using System;
using System.Configuration;

namespace DemoApp
{
  class Program
  {
    private const int ERROR_EXIT_CODE = -1;

    static void Main(string[] args)
    {
      if(args.Length != 1) ExitWithError("Invalid number of arguments passed.");

      var nativeExePath = ConfigurationManager.AppSettings["nativeExePath"];
      if(nativeExePath == null) ExitWithError("Path to native executable wasn't specified in App.config");

      try
      {
        var executable = NativeExecutable.Create(nativeExePath);
        var nativeExeExitCode = executable.CallWithParameter(args[0]);
        Console.Out.WriteLine("Native executable exits with code " + nativeExeExitCode);
        Environment.Exit(nativeExeExitCode);
      }
      catch (Exception ex)
      {
        ExitWithError(ex.Message);
      }
    }

    private static void ExitWithError(String errorMessage)
    {
      Console.Error.WriteLine(errorMessage);
      Environment.Exit(ERROR_EXIT_CODE);
    }
  }
}
