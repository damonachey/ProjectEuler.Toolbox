using System.Diagnostics;

namespace ProjectEuler.Toolbox;

/// <summary>
/// Queue of longs that is compressed to allow for much larger storage than would normally fit in memory.
/// </summary>
[DebuggerDisplay("Count = {Count}")]
public sealed class CompressedQueue
{
    public static int CompressThreshold { get; } = 1000000; 
    private readonly Queue<long> readQueue = new();
    private readonly Queue<long> writeQueue = new();
    private readonly Queue<byte[]> bufferQueue = new();

    public int Count { get; private set; }

    public long Dequeue()
    {
        Count--;

        if (!readQueue.Any())
        {
            if (!bufferQueue.Any())
            {
                return writeQueue.Dequeue();
            }

            var bytes = QuickLZ.Decompress(bufferQueue.Dequeue());

            for (var offset = 0; offset < bytes.Length; offset += sizeof(long))
            {
                readQueue.Enqueue(BitConverter.ToInt64(bytes, offset));
            }
        }

        return readQueue.Dequeue();
    }

    public void Enqueue(long item)
    {
        Count++;

        writeQueue.Enqueue(item);

        if (writeQueue.Count > CompressThreshold)
        {
            var bytes = Enumerable
                    .Range(1, CompressThreshold)
                    .SelectMany(i => BitConverter.GetBytes(writeQueue.Dequeue()))
                    .ToArray();

            bufferQueue.Enqueue(QuickLZ.Compress(bytes, 1));
        }
    }
}
