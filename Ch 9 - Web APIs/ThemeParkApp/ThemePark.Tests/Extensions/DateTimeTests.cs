using ThemePark.Data.Extensions;

namespace ThemePark.Tests.Extensions;

[TestClass]
public class DateTimeTests
{
    [TestMethod]
    public void FormattedDateTimeWithTimeTest()
    {
        // Arrange
        var startDate = new DateTime(2023, 5, 2, 14, 0, 0);
        const string expected = @"May 2<sup>nd</sup>, 2023 at 2:00pm";

        // Act
        var actual = startDate.ToFormattedDateTime();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedDateTimeNoTimeTest()
    {
        // Arrange
        var startDate = new DateTime(2023, 5, 2);
        const string expected = @"May 2<sup>nd</sup>, 2023";

        // Act
        var actual = startDate.ToFormattedDateTime(false);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedDateTimeNoTimeFirstDayTest()
    {
        // Arrange
        var startDate = new DateTime(2023, 5, 1);
        const string expected = @"May 1<sup>st</sup>, 2023";

        // Act
        var actual = startDate.ToFormattedDateTime(false);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedDateTimeNoTimeFifthDayTest()
    {
        // Arrange
        var startDate = new DateTime(2023, 5, 5);
        const string expected = @"May 5<sup>th</sup>, 2023";

        // Act
        var actual = startDate.ToFormattedDateTime(false);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FormattedDateTimeNoTimeThirdDayTest()
    {
        // Arrange
        var startDate = new DateTime(2023, 5, 3);
        const string expected = @"May 3<sup>rd</sup>, 2023";

        // Act
        var actual = startDate.ToFormattedDateTime(false);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
