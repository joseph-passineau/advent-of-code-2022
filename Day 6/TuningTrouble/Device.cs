namespace TuningTrouble;
public class Device
{
    private const int PacketSize = 4;
    private readonly string datastream;

    public Device(string datastream)
    {
        this.datastream = datastream;
        this.FirstMarkerIndex = FindFirstMarkerIndex();
    }

    public int FirstMarkerIndex { get; }

    private int FindFirstMarkerIndex()
    {
        var pointer = 0;
        while(pointer + PacketSize < datastream.Length)
        {
            var packet = datastream.Substring(pointer, PacketSize);

            if (IsMarker(packet))
            {
                return pointer + PacketSize;
            }
            pointer++;
        }

        throw new Exception("No marker found in datastream");
    }

    private bool IsMarker(string packet)
    {
        return packet
            .ToCharArray()
            .Distinct()
            .Count() == PacketSize;
    }
}
