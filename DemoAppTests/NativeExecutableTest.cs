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
//        Assert.Fail("Fail");
/*
        var nativeExecutable = NativeExecutable.Create(@"Release-Desktop\cpp-test-repo.exe");
        var retval = nativeExecutable.CallWithParameter("test");    
        Assert.AreEqual(0, retval);
*/
    }

    [Test]
    public void CallWithInValidParameterValue()
    {
/*
        var nativeExecutable = NativeExecutable.Create(@"Release-Desktop\cpp-test-repo.exe");
        Assert.AreNotEqual(0, nativeExecutable.CallWithParameter("InvalidParam"));
*/
    }
  }
}
