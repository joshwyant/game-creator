var lib = require('./LibraryContext.js');
var flib = require('./FunctionLibrary.js');

exports.Runtime = (function() {
    var initialized = false;

    function Runtime(context) {
        if (!initialized) static();
        var self = this;

        Runtime.Current = self;

        this.Context = context;
        this.AllDelegates = {};
        this.CurrentInstance = null;
        this.Env = [];
        this.Arguments = [];

        this.Initialize = function() {
            for (var lib in flib.FunctionLibrary.List)
                for (var name in flib.FunctionLibrary.List[lib].Functions)
                    self.AllFunctions[name] = flib.FunctionLibrary.List[lib].Functions[name];
                
            for (var name in context.Scripts)
                self.AllFunctions[name] = context.Scripts[name];
        };

        this.requireNumber = function(arg) {

        };

        this.pushEnv = function(instance) {
            var env = {
                OtherInstance: self.CurrentInstance,
            };

            if (instance)
                CurrentInstance = instance;

            self.Env.push(env);
        };

        this.Current = function() {
            return self.Env[self.Env.length -1];
        }

        this.popEnv = function() {
            var env = self.Env.pop();

            this.CurrentInstance = env.OtherInstance;
        };

        this.getInstance = function(i) {

        };
    }

    function static () {
        Runtime.Current = null;
    }

    return Runtime;
})();