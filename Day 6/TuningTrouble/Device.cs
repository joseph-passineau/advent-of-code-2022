namespace TuningTrouble;
public class Device
{
    private const int PacketSize = 4;
    private const int MessageSize = 14;
    private readonly string datastream;

    public Device(string datastream)
    {
        this.datastream = datastream;
        this.FirstPacketMarkerIndex = FindMarkerIndex(PacketSize);
        this.FirstMessageMarkerIndex = FindMarkerIndex(MessageSize);
    }

    public int? FirstPacketMarkerIndex { get; }

    public int? FirstMessageMarkerIndex { get; }

    private int? FindMarkerIndex(int size)
    {
        var pointer = 0;
        while(pointer + size < datastream.Length)
        {
            var packet = datastream.Substring(pointer, size);

            if (IsMarker(packet, size))
            {
                return pointer + size;
            }
            pointer++;
        }

        return null;
    }

    private bool IsMarker(string packet, int size)
    {
        return packet
            .ToCharArray()
            .Distinct()
            .Count() == size;
    }
}
