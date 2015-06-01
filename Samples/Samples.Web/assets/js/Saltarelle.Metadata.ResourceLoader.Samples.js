(function() {
	'use strict';
	var $asm = {};
	ss.initAssembly($asm, 'Saltarelle.Metadata.ResourceLoader.Samples');
	////////////////////////////////////////////////////////////////////////////////
	// Saltarelle.Metadata.ResourceLoader.Samples.Program
	var $Saltarelle_Metadata_ResourceLoader_Samples_$Program = function() {
	};
	$Saltarelle_Metadata_ResourceLoader_Samples_$Program.__typeName = 'Saltarelle.Metadata.ResourceLoader.Samples.$Program';
	$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$main = function() {
		$Saltarelle_Metadata_ResourceLoader_Samples_$Program.set_$logElement(document.getElementById('LoadedLog'));
		var loader = new Loader();
		loader.add('bunny', 'assets/bunny.png').add('assets/bkg.jpg').add({ name: 'JsTest', url: 'assets/resource.js' }).add('Json', 'resource.json', function(resource) {
			$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('Resource Completed: ' + resource.name);
		}).add({
			url: 'assets/strip123.png',
			onComplete: function(resource1) {
				$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('Resource Completed: ' + resource1.name);
			}
		}).before($Saltarelle_Metadata_ResourceLoader_Samples_$Program.$beforeMiddleware()).after($Saltarelle_Metadata_ResourceLoader_Samples_$Program.$afterMiddleware());
		// throughout the process multiple events can happen.
		loader.on('start', function(l) {
			// called when queue starts
			$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('Loader Started!');
		}).on('progress', function(l1, resource2) {
			// called once per loaded/errored file
			$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('OnProgress: ' + resource2.name);
		}).on('error', function(error, l2, resource3) {
			// called once per errored file
			$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('OnError: ' + resource3.name);
			console.log('OnError:');
			window.self.console.log(error);
		}).on('load', function(l3, resource4) {
			// called once per loaded file
			$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('OnLoad: ' + resource4.name);
		}).on('complete', function(l4, resources) {
			// called once when the queued resources all load.
			$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('COMPLETED!!!');
		});
		// `Load` method loads the queue of resources, and calls the passed in callback called once all
		// resources have loaded.
		loader.load(function(l5, resources1) {
			// Resources is an object where the key is the name of the resource loaded and the value is the resource object.
			// They have a couple default properties:
			// - `Url`: The URL that the resource was loaded from
			// - `Error`: The error that happened when trying to load (if any)
			// - `Data`: The raw data that was loaded
			// also may contain other properties based on the middleware that runs.
			var $t1 = new ss.ObjectEnumerator(resources1);
			try {
				while ($t1.moveNext()) {
					var resource5 = $t1.current();
					$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog(resource5.key + ': ' + resource5.value.xhrType);
				}
			}
			finally {
				$t1.dispose();
			}
		});
	};
	$Saltarelle_Metadata_ResourceLoader_Samples_$Program.get_$logElement = function() {
		return $Saltarelle_Metadata_ResourceLoader_Samples_$Program.$1$LogElementField;
	};
	$Saltarelle_Metadata_ResourceLoader_Samples_$Program.set_$logElement = function(value) {
		$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$1$LogElementField = value;
	};
	$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog = function(message) {
		var element = document.createElement('div');
		element.textContent = message;
		$Saltarelle_Metadata_ResourceLoader_Samples_$Program.get_$logElement().appendChild(element);
	};
	ss.initClass($Saltarelle_Metadata_ResourceLoader_Samples_$Program, $asm, {});
	(function() {
		$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$1$LogElementField = null;
		$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$beforeMiddleware = function() {
			console.log("Not sure what's going on...");
			return function(resource, next) {
				$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('BeforeMiddleware: ' + resource.name);
				next();
			};
		};
		$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$afterMiddleware = function() {
			return function(resource, next) {
				$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$writeLog('AfterMiddleware: ' + resource.name);
				next();
			};
		};
	})();
	$Saltarelle_Metadata_ResourceLoader_Samples_$Program.$main();
})();
