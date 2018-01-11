using System.Collections.Generic;

namespace Connector.Tasks.Chunker
{
    public interface IChunkGroup<T> : IEnumerable<IEnumerable<T>> { }
}