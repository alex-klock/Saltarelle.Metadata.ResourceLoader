using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Saltarelle.Metadata.ResourceLoader
{
    /// <summary>
    /// Options that can be passed into the Loader's Add method.
    /// </summary>
    [Imported]
    [Serializable]
    public class AddResourceOptions : ResourceOptions
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the on complete callback. (gets called aftermiddleware).
        /// </summary>
        public Action<Resource> OnComplete
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets th eurl.
        /// </summary>
        public string Url
        {
            get;
            set;
        }
    }
}
