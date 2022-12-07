using TuningTrouble;

Console.WriteLine("Advent of Code - Day 6");

string dataStream = File.ReadAllText("input.txt");
var device = new Device(dataStream);

Console.WriteLine($"The number of characters needed to be processed before the first start-of-packet marker is detected is {device.FirstPacketMarkerIndex}");
Console.WriteLine($"The number of characters needed to be processed before the first start-of-message marker is detected is {device.FirstMessageMarkerIndex}");