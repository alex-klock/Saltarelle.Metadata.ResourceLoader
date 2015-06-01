using System;
using System.Runtime.CompilerServices;

namespace Saltarelle.Metadata.ResourceLoader
{
    /// <summary>
    /// Options for when creating new Resources.
    /// </summary>
    [Imported]
    [Serializable]
    public class ResourceOptions
    {
        /// <summary>
        /// Is this request cross-origin? Default is to determine automatically.
        /// </summary>
        public bool CrossOrigin
        {
            get;
            set;
        }

        /// <summary>
        /// How should this resource be loaded?
        /// </summary>
        public Resource.LoadTypes LoadType
        {
            get;
            set;
        }

        /// <summary>
        /// How should the data being loaded be interpreted when using XHR?
        /// </summary>
        public Resource.XhrResponseTypes XhrType
        {
            get;
            set;
        }
    }
}
