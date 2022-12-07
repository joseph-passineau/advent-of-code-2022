namespace TuningTrouble.Tests;

public class DeviceTests
{
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void When_UsingDevice_ShouldReturnCorrectFirstPacketMarkerIndex(string dataStream, int expectedFirstMarkerIndex)
    {
        var device = new Device(dataStream);

        Assert.Equal(expectedFirstMarkerIndex, device.FirstPacketMarkerIndex);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void When_UsingDevice_ShouldReturnCorrectFirstMessageMarkerIndex(string dataStream, int expectedFirstMarkerIndex)
    {
        var device = new Device(dataStream);

        Assert.Equal(expectedFirstMarkerIndex, device.FirstMessageMarkerIndex);
    }
}