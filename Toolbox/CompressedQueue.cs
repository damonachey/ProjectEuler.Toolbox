using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectEuler.Toolbox
{
    /// <summary>
    /// Queue of longs that is compressed to allow for much larger storage than would normally fit in memory.
    /// </summary>
    [DebuggerDisplay("Count = {Count}")]
    public class CompressedQueue
    {
        public static int CompressThreshold { get; } = 1000000; 
        private Queue<long> readQueue { get; } = new Queue<long>();
        private Queue<long> writeQueue { get; } = new Queue<long>();
        private Queue<byte[]> bufferQueue { get; } = new Queue<byte[]>();

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

                var bytes = QuickLZ.decompress(bufferQueue.Dequeue());

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

                bufferQueue.Enqueue(QuickLZ.compress(bytes, 1));
            }
        }
    }
}