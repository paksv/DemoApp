using DemoApp;
using NUnit.Framework;

namespace DemoAppTests
{
  [TestFixture]
  public class NativeExecutableTest
  {
    [Test]
    public void CallWithValidParameterValue()
    {
        var nativeExecutable = NativeExecutable.Create("cpp-test-repo.exe");
        Assert.AreEqual(0, nativeExecutable.CallWithParameter("test"));
    }

    [Test]
    public void CallWithInValidParameterValue()
    {
        var nativeExecutable = NativeExecutable.Create("cpp-test-repo.exe");
        Assert.AreNotEqual(0, nativeExecutable.CallWithParameter("InvalidParam"));
    }
  }
}
