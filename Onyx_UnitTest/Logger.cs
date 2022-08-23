using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnyxFront;
using System.IO;
using System.Text.RegularExpressions;

namespace Onyx_UnitTest
{
    [TestClass]
    public class LoggerTest
    {
        [TestMethod]
        public void Log()
        {
            var path = "C:\\Users\\marti\\Desktop\\Logger test\\test";

            Logger test = new Logger(path);

            var testFormater = test.LogFormater("my log");

            Assert.IsTrue(Regex.IsMatch (testFormater, "^\\[(\\d{2}).(\\d{2}).(\\d{2}) (\\d{2}):(\\d{2}):(\\d{2})\\].*"));;

        }
    }
}
