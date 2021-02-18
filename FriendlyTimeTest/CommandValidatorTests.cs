using FriendlyTimeUtils;
using NUnit.Framework;

namespace FriendlyTimeTest
{
    [TestFixture]
    public class CommandValidatorTests
    {
        private CommandValidator _commandValidator;

        [SetUp]
        public void SetUp()
        {
            _commandValidator = new CommandValidator();
        }

        [TestCase("01:00", true)]
        [TestCase("02:00", true)]
        [TestCase("13:00", true)]
        [TestCase("13:05", true)]
        [TestCase("13:25", true)]
        [TestCase("13:30", true)]
        [TestCase("13:35", true)]
        [TestCase("13:55", true)]
        [TestCase("13:60", false)]
        [TestCase("13:70", false)]
        [TestCase("03:40", true)]
        [TestCase("23:55", true)]
        [TestCase("24:00", false)]
        [TestCase("24:01", false)]
        [TestCase("10:01 PM", false)]
        [TestCase("10:01 AM", false)]
        [TestCase("", false)]
        [TestCase(null, false)]
        public void IsValid_GivenCommand_ReturnsExpectedResult(string command, bool expectedResult)
        {
            var result = _commandValidator.IsValid(command);
            Assert.AreEqual(expectedResult, result);
        }
    }
}    
    