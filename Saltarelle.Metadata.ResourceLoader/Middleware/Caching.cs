using System.Runtime.CompilerServices;

namespace Saltarelle.Metadata.ResourceLoader.Middleware
{
    /// <summary>
    /// Represents the out of the box middleware for caching options.
    /// </summary>
    [Imported]
    [ScriptNamespace("Loader.middleware")]
    [ScriptName("caching")]
    public static class Caching
    {
        /// <summary>
        /// Gets a simple in-memory cache middleware for resources.
        /// </summary>
        [IntrinsicProperty]
        public static dynamic Memory
        {
            get { return null; }
        }
    }
}
