using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;

namespace DemoApp
{
  class Program
  {
    static void Main(string[] args)
    {
      if(args.Length != 1) ExitWithError("Invalid number of arguments passed.");

      var nativeExePath = ConfigurationManager.AppSettings["nativeExePath"];
      if(nativeExePath == null) ExitWithError("Path to native executable wasn't specified in App.config");
      if(!File.Exists(nativeExePath)) ExitWithError("Failed to find native executable on path " + nativeExePath);

      var nativeExeProcess = Process.Start(nativeExePath, "parameter=" + args[0]);
      if(nativeExeProcess == null) ExitWithError("Native executable wasn't started.");
      nativeExeProcess.WaitForExit();
      var nativeExeExitCode = nativeExeProcess.ExitCode;
      Console.Out.WriteLine("Native executable exits with code " + nativeExeExitCode);
      Environment.Exit(nativeExeExitCode);
    }

    private static void ExitWithError(String errorMessage)
    {
      Console.Error.WriteLine(errorMessage);
      Environment.Exit(-1);
    }
  }
}
