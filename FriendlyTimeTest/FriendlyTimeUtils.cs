using System;
using NUnit.Framework;
using FriendlyTimeUtils;

namespace FriendlyTimeTest
{
    [TestFixture]
    public class DateTimeExtensionsTest
    {
        [Test]
        [TestCase(1, 0,"One o'clock")]
        [TestCase(2,0 , "Two o'clock")]
        [TestCase(13, 0,"One o'clock")]
        [TestCase(13, 5, "Five past one")]
        [TestCase(13, 10, "Ten past one")]
        [TestCase(13, 25, "Twenty five past one")]
        [TestCase(13,30, "Half past one")]
        [TestCase(13, 35, "Twenty five to two")]
        [TestCase(13, 55, "Five to two")]
        [TestCase(0, 23, "Twenty three past zero")]
        [TestCase(0, 0, "Midnight")]
        public void ToHumanFriendlyDateString(int inputHour, int inputMinutes, string expected)
        {
            var dateTime = DateTime.Now.Date.Add(new TimeSpan(inputHour, inputMinutes, 0));
            var actual = dateTime.ToHumanFriendlyDateString();
            Assert.AreEqual(expected, actual);
        }
    }
}