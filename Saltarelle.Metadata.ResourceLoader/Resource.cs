using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace Saltarelle.Metadata.ResourceLoader
{
    /// <summary>
    /// Manages the state and loading of a single resource represented by a single URL.
    /// </summary>
    [Imported]
    [ScriptNamespace("Loader")]
    public class Resource
    {
        #region Properties

        /// <summary>
        /// Is this request cross-origin? If unset, determined automatically.
        /// </summary>
        [IntrinsicProperty]
        public string CrossOrigin
        {
            get;
            set;
        }

        /// <summary>
        /// The data that was loaded by the resource.
        /// </summary>
        [IntrinsicProperty]
        public dynamic Data
        {
            get;
            set;
        }

        /// <summary>
        /// The error that occurred while loading (if any).
        /// </summary>
        public dynamic Error
        {
            get;
            set;
        }

        /// <summary>
        /// The name of this resource.
        /// </summary>
        [IntrinsicProperty]
        public string Name
        {
            get { return null; }
        }

        /// <summary>
        /// The url used to load this resource.
        /// </summary>
        [IntrinsicProperty]
        public string Url
        {
            get {  return null; }
        }

        /// <summary>
        /// Describes if this resource was loaded as an audio tag. Only valid after the resource has completely loaded
        /// </summary>
        [IntrinsicProperty]
        public bool IsAudio
        {
            get;
            set;
        }

        /// <summary>
        /// Stores whether or not this url is a data url.
        /// </summary>
        [IntrinsicProperty]
        public bool IsDataUrl
        {
            get { return false; }
        }

        /// <summary>
        /// Describes if this resource was loaded as an image tag. Only valid after the resource has completely loaded.
        /// </summary>
        [IntrinsicProperty]
        public bool IsImage
        {
            get;
            set;
        }

        /// <summary>
        /// Describes if this resource was loaded as json. Only valid after the resource
        /// has completely loaded.
        /// </summary>
        [IntrinsicProperty]
        public bool IsJson
        {
            get;
            set;
        }

        /// <summary>
        /// Describes if this resource was loaded as a video tag. Only valid after the resource has completely loaded.
        /// </summary>
        [IntrinsicProperty]
        public bool IsVideo
        {
            get;
            set;
        }

        /// <summary>
        /// Describes if this resource was loaded as xml. Only valid after the resource has completely loaded.
        /// </summary>
        [IntrinsicProperty]
        public bool IsXml
        {
            get;
            set;
        }

        /// <summary>
        /// The method of loading to use for this resource.
        /// </summary>
        [IntrinsicProperty]
        public LoadTypes LoadType
        {
            get;
            set;
        }

        /// <summary>
        /// The type used to load the resource via XHR. If unset, determined automatically.
        /// </summary>
        [IntrinsicProperty]
        public string XhrType
        {
            get;
            set;
        }

        /// <summary>
        /// The XHR object that was used to load this resource. This is only set when `loadType` 
        /// is `Resource.LOAD_TYPE.XHR`.
        /// </summary>
        [IntrinsicProperty]
        public XmlHttpRequest Xhr
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the resource to load.</param>
        /// <param name="url">The url for this resource, for audio/video loads you can pass an array of sources.</param>
        /// <param name="options">The options for the load.</param>
        public Resource(string name, string url, ResourceOptions options = null)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">The name of the resource to load.</param>
        /// <param name="url">The url for this resource, for audio/video loads you can pass an array of sources.</param>
        /// <param name="options">The options for the load.</param>
        public Resource(string name, string[] urls, ResourceOptions options = null)
        { }

        #endregion

        #region Static Methods

        /// <summary>
        /// Sets the load type to be used for a specific extension.
        /// </summary>
        /// <param name="extname">The extension to set the type for, e.g. "png" or "fnt"</param>
        /// <param name="loadType">The load type to set it to.</param>
        public static void SetExtensionLoadType(string extname, LoadTypes loadType)
        {

        }

        /// <summary>
        /// Sets the load type to be used for a specific extension.
        /// </summary>
        /// <param name="extname">The extension to set the type for, e.g. "png" or "fnt"</param>
        /// <param name="xhrType">The xhr type to set it to.</param>
        public static void SetExtensionXhrType(string extname, XhrResponseTypes xhrType)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Marks the resource as complete.
        /// </summary>
        public void Complete()
        {

        }

        /// <summary>
        /// Kicks off loading of this resource.
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// Kicks off loading of this resource.
        /// </summary>
        /// <param name="cb"> Optional callback to call once the resource is loaded.</param>
        public void Load(Action<Resource> cb)
        {

        }

        #endregion

        #region Events

        /// <summary>
        /// Emitted once this resource has loaded, if there was an error it will be in the `error` property.
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        [InlineCode("{this}.on('complete', {fn})")]
        public Resource OnComplete(Action<Resource> fn)
        {
            return this;
        }

        [InlineCode("{this}.once('complete', {fn})")]
        public Resource OnCompleteOnce(Action<Resource> fn)
        {
            return this;
        }

        [InlineCode("{this}.removeListener('complete', {fn})")]
        public Resource RemoveOnComplete(Action<Resource> fn)
        {
            return this;
        }

        [InlineCode("{this}.removeListener('complete', {fn}, true)")]
        public Resource RemoveOnCompleteOnce(Action<Resource> fn)
        {
            return this;
        }

        /// <summary>
        /// Emitted each time progress of this resource load updates.
        /// Not all resources types and loader systems can support this event
        /// so sometimes it may not be available. If the resource
        /// is being loaded on a modern browser, using XHR, and the remote server
        /// properly sets Content-Length headers, then this will be available.
        /// </summary>
        [InlineCode("{this}.on('progress', {fn})")]
        public Resource OnProgress(Action<Resource, double> fn)
        {
            return this;
        }

        [InlineCode("{this}.once('progress', {fn})")]
        public Resource OnProgressOnce(Action<Resource, double> fn)
        {
            return this;
        }

        [InlineCode("{this}.removeListener('progress', {fn})")]
        public Resource RemoveOnProgress(Action<Resource, double> fn)
        {
            return this;
        }

        [InlineCode("{this}.removeListener('progress', {fn}, true)")]
        public Resource RemoveOnProgressOnce(Action<Resource, double> fn)
        {
            return this;
        }

        /// <summary>
        /// Emitted when the resource beings to load.
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        [InlineCode("{this}.on('start', {fn})")]
        public Resource OnStart(Action<Resource> fn)
        {
            return this;
        }

        [InlineCode("{this}.once('start', {fn})")]
        public Resource OnStartOnce(Action<Resource> fn)
        {
            return this;
        }

        [InlineCode("{this}.removeListener('start', {fn})")]
        public Resource RemoveOnStart(Action<Resource> fn)
        {
            return this;
        }

        [InlineCode("{this}.removeListener('start', {fn}, true)")]
        public Resource RemoveOnStartOnce(Action<Resource> fn)
        {
            return this;
        }

        #endregion

        #region Enums

        /// <summary>
        /// The types of loading a resource can use.
        /// </summary>
        [Imported]
        [ScriptName("LOAD_TYPES")]
        public enum LoadTypes
        {
            /// <summary>
            /// Uses XMLHttpRequest to load the resource.
            /// </summary>
            [ScriptName("XHR")]
            Xhr = 1,
            /// <summary>
            /// Uses an `Image` object to load the resource.
            /// </summary>
            [ScriptName("IMAGE")]
            Image =  2,
            /// <summary>
            /// Uses an `Audio` object to load the resource.
            /// </summary>
            [ScriptName("AUDIO")]
            Audio =  3,
            /// <summary>
            /// Uses a `Video` object to load the resource.
            /// </summary>
            [ScriptName("VIDEO")]
            Video =  4
        }

        /// <summary>
        /// The XHR ready states, used internally.
        /// </summary>
        [Imported]
        [ScriptName("XHR_READY_STATE")]
        public enum XhrReadyStates 
        {
            /// <summary>
            /// open()has not been called yet.
            /// </summary>
            [ScriptName("UNSENT")]
            Unsent = 0,
            /// <summary>
            /// send()has not been called yet.
            /// </summary>
            [ScriptName("OPENED")]
            Opened = 1,
            /// <summary>
            /// send() has been called, and headers and status are available.
            /// </summary>
            [ScriptName("HEADERS_RECEIVED")]
            HeadersReceived = 2,
            /// <summary>
            /// Downloading; responseText holds partial data.
            /// </summary>
            [ScriptName("LOADING")]
            Loading = 3,
            /// <summary>
            /// The operation is complete.
            /// </summary>
            [ScriptName("DONE")]
            Done = 4
        }
        
        /// <summary>
        /// The xhr response types.
        /// </summary>
        [ScriptName("XHR_RESPONSE_TYPE")]
        [Imported]
        public enum XhrResponseTypes
        {
            [ScriptName("DEFAULT")]
            Default,
            [ScriptName("BUFFER")]
            Buffer,
            [ScriptName("BLOB")]
            Blob,
            [ScriptName("DOCUMENT")]
            Document,
            [ScriptName("JSON")]
            Json,
            [ScriptName("TEXT")]
            Text
        }

        #endregion
    }
}
