using System.Collections.Generic;

namespace Connector.Tasks.Chunker
{
    public class ChunkGroup<T> : List<IEnumerable<T>>, IChunkGroup<T>
    {
        public ChunkGroup(IEnumerable<IEnumerable<T>> list) { AddRange(list); }
    }
}