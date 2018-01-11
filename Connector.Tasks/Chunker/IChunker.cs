using System.Collections.Generic;

namespace Connector.Tasks.Chunker
{
    public interface IChunker
    {
        /// <summary>
        /// Creates a group of chunks from the original source
        /// </summary>
        IChunkGroup<T> Apply<T>(IEnumerable<T> source, int chunkSize);
    }
}