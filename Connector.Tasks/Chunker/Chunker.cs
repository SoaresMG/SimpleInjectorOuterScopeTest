using System.Collections.Generic;
using System.Linq;

namespace Connector.Tasks.Chunker
{
    public class Chunker : IChunker
    {
        public IChunkGroup<T> Apply<T>(IEnumerable<T> source, int chunkSize)
        {
            if (chunkSize == 0)
                return new ChunkGroup<T>(new List<IEnumerable<T>>() { source });
            else
                return new ChunkGroup<T>(
                    source
                        .Select((x, i) => new { Index = i, Value = x })
                        .GroupBy(x => x.Index / chunkSize)
                        .Select(x => x.Select(v => v.Value))
                );
        }
    }
}