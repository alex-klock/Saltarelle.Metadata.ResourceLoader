# Saltarelle.Metadata.ResourceLoader
Resource Loader (englercj/resource-loader) bindings for the <a href="http://www.saltarelle-compiler.com/" target="_blank">Saltarelle C# to JavaScript compiler</a>.

See https://github.com/englercj/resource-loader for official JavaScript library, a middleware-style generic resource loader built with web games in mind.

Example:

    class Program
    {
        static void Main()
        {
            LogElement = Document.GetElementById("LoadedLog");

            Loader loader = new Loader();

            loader
                // chainable `Add` to enqueue a resource
                .Add("bunny", "assets/bunny.png")
                .Add("assets/bkg.jpg")
                .Add(new AddResourceOptions { Name = "JsTest", Url = "assets/resource.js" })
                .Add("Json", "resource.json", (resource) =>
                {
                    WriteLog("Resource Completed: " + resource.Name);
                })
                .Add(new AddResourceOptions
                {
                    Url = "assets/strip123.png",
                    OnComplete = (resource) =>
                    {
                        WriteLog("Resource Completed: " + resource.Name);
                    }
                })
                
            // chainable `Before` to add a middleware that runs for each resource, *before* loading a resource.
            // this is useful to implement custom caching modules (using filesystem, indexeddb, memory, etc).
                .Before(BeforeMiddleware())

            // chainable `After` to add a middleware that runs for each resource, *after* loading a resource.
            // this is useful to implement custom parsing modules (like spritesheet parsers, spine parser, etc).
                .After(AfterMiddleware());

            // throughout the process multiple events can happen.
            loader.OnStart(l =>
            {
                // called when queue starts
                WriteLog("Loader Started!");
            }).OnProgress((l, resource) =>
            {
                // called once per loaded/errored file
                WriteLog("OnProgress: " + resource.Name);
            }).OnError((error, l, resource) =>
            {
                // called once per errored file
                WriteLog("OnError: " + resource.Name);
                Console.WriteLine("OnError:");
                ((dynamic)Window.Self).console.log(error);
            }).OnLoad((l, resource) =>
            {
                // called once per loaded file
                WriteLog("OnLoad: " + resource.Name);
            }).OnComplete((l, resources) =>
            {
                // called once when the queued resources all load.
                WriteLog("COMPLETED!!!");
            });

            // `Load` method loads the queue of resources, and calls the passed in callback called once all
            // resources have loaded.
            loader.Load((l, resources) =>
            {
                // Resources is an object where the key is the name of the resource loaded and the value is the resource object.
                // They have a couple default properties:
                // - `Url`: The URL that the resource was loaded from
                // - `Error`: The error that happened when trying to load (if any)
                // - `Data`: The raw data that was loaded
                // also may contain other properties based on the middleware that runs.

                foreach (var resource in resources)
                {
                    WriteLog(resource.Key + ": " + resource.Value.XhrType);
                }
            });
        }

        /// <summary>
        /// Gets or sets the element that messages can be written to.
        /// </summary>
        static Element LogElement
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a middleware function.
        /// </summary>
        static Func<Action<Resource, Action>> BeforeMiddleware = () =>
        {
            return (resource, next) =>
            {
                WriteLog("BeforeMiddleware: " + resource.Name);
                next();
            };
        };

        /// <summary>
        /// Returns a middleware function.
        /// </summary>
        static Func<Action<Resource, Action>> AfterMiddleware = () =>
        {
            return (resource, next) =>
            {
                WriteLog("AfterMiddleware: " + resource.Name);
                next();
            };
        };

        /// <summary>
        /// Writes a message as an appended element to #LoadedLog.
        /// </summary>
        /// <param name="message">The message to write.</param>
        static void WriteLog(string message)
        {
            var element = Document.CreateElement("div");
            element.TextContent = message;

            LogElement.AppendChild(element);
        }
    }
    
For CommonJS projects, use Saltarelle.Metadata.ResourceLoader (uses the npm package "resource-loader").

For projects using the stand alone version of resource loader, use Saltarelle.Metadata.ResourceLoader.StandAlone.
