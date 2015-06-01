using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Saltarelle.Metadata.ResourceLoader
{
    /// <summary>
    /// Manages the state and loading of multiple resources to load.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public class Loader
    {
        #region Properties

        /// <summary>
        /// The base url for all resources loaded by this loader.
        /// </summary>
        [IntrinsicProperty]
        public string BaseUrl
        {
            get;
            set;
        }

        /// <summary>
        /// Loading state of the loader, true if it is currently loading resources.
        /// </summary>
        public bool Loading
        {
            get { return false; }
        }

        /// <summary>
        /// The progress percent of the loader going through the queue.
        /// </summary>
        [IntrinsicProperty]
        public double Progress
        {
            get { return 0; }
        }

        /// <summary>
        /// All the resources for this loader keyed by name.
        /// </summary>
        [IntrinsicProperty]
        public JsDictionary<string, Resource> Resources
        {
            get { return null; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseUrl">The base url for all resources loaded by this loader.</param>
        /// <param name="concurrency">The number of resources to load concurrently.</param>
        public Loader(string baseUrl, int concurrency) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="baseUrl">The base url for all resources loaded by this loader.</param>
        public Loader(string baseUrl) { }

        /// <summary>
        /// Constructor
        /// </summary>
        public Loader() { }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a resource (or multiple resources) to the loader queue.
        /// This function can take a wide variety of different parameters. The only thing that is always required 
        /// the url to load.
        /// </summary>
        /// <param name="url">The url for this resource, relative to the baseUrl of this loader</param>
        /// <returns></returns>
        public Loader Add(string url)
        {
            return this;
        }

        /// <summary>
        /// Adds a resource (or multiple resources) to the loader queue.
        /// This function can take a wide variety of different parameters. The only thing that is always required 
        /// the url to load.
        /// </summary>
        /// <param name="name">The name of the resource to load, if not passed the url is used.</param>
        /// <param name="url">The url for this resource, relative to the baseUrl of this loader.</param>
        /// <returns></returns>
        public Loader Add(string name, string url)
        {
            return this;
        }

        /// <summary>
        /// Adds a resource (or multiple resources) to the loader queue.
        /// This function can take a wide variety of different parameters. The only thing that is always required 
        /// the url to load.
        /// </summary>
        /// <param name="url">The url for this resource, relative to the baseUrl of this loader.</param>
        /// <param name="options">The options for the load</param>
        /// <returns></returns>
        public Loader Add(string url, Action<Resource> cb)
        {
            return this;
        }

        public Loader Add(string name, string url, Action<Resource> cb)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cb">Function to call when this specific resource completes loading.</param>
        /// <returns></returns>
        public Loader Add(AddResourceOptions options, Action<Resource> cb)
        {
            return this;
        }

        public Loader Add(AddResourceOptions options)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resources">A list of url's.</param>
        /// <returns></returns>
        public Loader Add(IEnumerable<string> urlResources)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resources"></param>
        /// <returns></returns>
        public Loader Add(IEnumerable<AddResourceOptions> resources)
        {
            return this;
        }

        /// <summary>
        /// Sets up a middleware function that will run *after* the resource is loaded.
        /// </summary>
        /// <param name="fn">The middleware function to register.</param>
        /// <returns></returns>
        public Loader After(Action<Resource, Action> fn)
        {
            return this;
        }

        /// <summary>
        /// Sets up a middleware function that will run *before* the resource is loaded.
        /// </summary>
        /// <param name="fn"></param>
        /// <returns>The middleware function to register.</returns>
        public Loader Before(Action<Resource, Action> fn)
        {
            return this;
        }

        /// <summary>
        /// Starts loading the queued resources.
        /// </summary>
        /// <param name="cb">Optional callback that will be bound to the `complete` event.</param>
        /// <returns></returns>
        public Loader Load(Action<Loader, JsDictionary<string, Resource>> cb)
        {
            return this;
        }

        /// <summary>
        /// Starts loading the queued resources.
        /// </summary>
        /// <returns></returns>
        public Loader Load()
        {
            return this;
        }

        /// <summary>
        /// Resets the queue of the loader to prepare for a new load.
        /// </summary>
        /// <returns></returns>
        public Loader Reset()
        {
            return this;
        }

        #endregion

        #region Events

        /// <summary>
        /// Sets a listener for the loader's 'complete' event. Emitted when the queued resources all load.
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        [InlineCode("{this}.on('complete', {cb})")]
        public Loader OnComplete(Action<Loader, JsDictionary<string, Resource>> cb) { return this; }

        /// <summary>
        /// Sets a listener for the loader's 'complete' event that will be fired once. Emitted when the queued resources all load.
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        [InlineCode("{this}.once('complete', {cb})")]
        public Loader OnCompleteOnce(Action<Loader, JsDictionary<string, Resource>> cb) { return this; }

        [InlineCode("{this}.removeListener('complete', {cb})")]
        public Loader RemoveOnComplete(Action<Loader, JsDictionary<string, Resource>> cb) { return this; }

        [InlineCode("{this}.removeListener('complete', {cb}, true)")]
        public Loader RemoveOnCompleteOnce(Action<Loader, JsDictionary<string, Resource>> cb) { return this; }

        /// <summary>
        /// Emitted once per errored resource.
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        [InlineCode("{this}.on('error', {cb})")]
        public Loader OnError(Action<dynamic, Loader, Resource> cb) { return this; }

        [InlineCode("{this}.once('error', {cb})")]
        public Loader OnErrorOnce(Action<dynamic, Loader, Resource> cb) { return this; }

        [InlineCode("{this}.removeListener('error', {cb})")]
        public Loader RemoveOnError(Action<dynamic, Loader, Resource> cb) { return this; }

        [InlineCode("{this}.removeListener('error', {cb}, true)")]
        public Loader RemoveOnErrorOnce(Action<dynamic, Loader, Resource> cb) { return this; }

        /// <summary>
        /// Emitted once per loaded resource.
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        [InlineCode("{this}.on('load', {cb})")]
        public Loader OnLoad(Action<Loader, Resource> cb) { return this; }

        [InlineCode("{this}.once('load', {cb})")]
        public Loader OnLoadOnce(Action<Loader, Resource> cb) { return this; }

        [InlineCode("{this}.removeListener('load', {cb})")]
        public Loader RemoveOnLoad(Action<Loader, Resource> cb) { return this; }

        [InlineCode("{this}.removeListener('load', {cb}, true)")]
        public Loader RemoveOnLoadOnce(Action<Loader, Resource> cb) { return this; }

        /// <summary>
        /// Emitted once per loaded or errored resource.
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        [InlineCode("{this}.on('progress', {cb})")]
        public Loader OnProgress(Action<Loader, Resource> cb) { return this; }

        [InlineCode("{this}.once('progress', {cb})")]
        public Loader OnProgressOnce(Action<Loader, Resource> cb) { return this; }

        [InlineCode("{this}.removeListener('progress', {cb})")]
        public Loader RemoveOnProgress(Action<Loader, Resource> cb) { return this; }

        [InlineCode("{this}.removeListener('progress', {cb}, true)")]
        public Loader RemoveOnProgressOnce(Action<Loader, Resource> cb) { return this; }

        /// <summary>
        /// Emitted when the loader begins to process the queue.
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        [InlineCode("{this}.on('start', {cb})")]
        public Loader OnStart(Action<Loader> cb) { return this; }

        [InlineCode("{this}.once('start', {cb})")]
        public Loader OnStartOnce(Action<Loader> cb) { return this; }

        [InlineCode("{this}.removeListener('start', {cb})")]
        public Loader RemoveOnStart(Action<Loader> cb) { return this; }

        [InlineCode("{this}.removeListener('start', {cb}, true)")]
        public Loader RemoveOnStartOnce(Action<Loader> cb) { return this; }

        #endregion
    }
}
