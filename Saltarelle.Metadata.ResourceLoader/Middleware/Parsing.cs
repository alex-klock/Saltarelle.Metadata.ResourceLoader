using System.Runtime.CompilerServices;

namespace Saltarelle.Metadata.ResourceLoader.Middleware
{
    /// <summary>
    /// Represents the out of the box middleware options for parsing.
    /// </summary>
    [Imported]
    [ScriptNamespace("Loader.middleware")]
    [ScriptName("parsing")]
    public static class Parsing
    {
        /// <summary>
        /// Gets a middleware for transforming XHR loaded Blobs into more useful objects.
        /// </summary>
        [IntrinsicProperty]
        public static dynamic Blob
        {
            get { return null; }
        }
    }
}
