namespace TuningTrouble.Tests;

public class DeviceTests
{
    [Theory]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void When_UsingDevice_ShouldReturnCorrectFirstMarkerIndex(string dataStream, int expectedFirstMarkerIndex)
    {
        var device = new Device(dataStream);

        Assert.Equal(expectedFirstMarkerIndex, device.FirstMarkerIndex);
    }
}