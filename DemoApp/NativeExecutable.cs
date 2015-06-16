using System;
using System.Diagnostics;
using System.IO;

namespace DemoApp
{
  public class NativeExecutable
  {
    private readonly string myExePath;

    private NativeExecutable(string pathToExe)
    {
      myExePath = pathToExe;
    }

    public static NativeExecutable Create(String pathToExe)
    {
      if (!File.Exists(pathToExe)) throw new ArgumentException("Failed to find native executable on path " + pathToExe);
      return new NativeExecutable(pathToExe);
    }

    public int CallWithParameter(String parameterValue)
    {
      var nativeExeProcess = Process.Start(myExePath, "parameter=" + parameterValue);
      if (nativeExeProcess == null) throw new ApplicationException("Native executable wasn't started.");
      nativeExeProcess.WaitForExit();
      var nativeExeExitCode = nativeExeProcess.ExitCode;
      return nativeExeExitCode;
    }
  }
}