flib = require('./FunctionLibrary.js');

exports.LibraryContext = (function() {
    function LibraryContext() {
        var self = this;

        this.Scripts = {};
        this.Constants = {};

        this.RegisterScript = function(name, f) {
            self.Scripts[name] = f;
        }

        this.RegisterAllConstants = function(x) {
            for (var n in x)
                self.Constants[n] = x[n];
        }

        this.FunctionExists = function(x) {
            for (var libName in flib.FunctionLibrary.List) {
                var lib = flib.FunctionLibrary.List[libName];
                if (lib.Enabled && lib.Functions.hasOwnProperty(x))
                    return true;
            }
            return self.Scripts.hasOwnProperty(x);
        }

        this.IsBuiltIn = function(x) {
            for (var libName in flib.FunctionLibrary.List) {
                var lib = flib.FunctionLibrary.List[libName];
                if (lib.Enabled && ((lib.BuiltInVariables.indexOf(x) !== -1) || (lib.InstanceVariables.indexOf(x) !== -1)))
                    return true;
            }
            return false;
        }
    }
 
    return LibraryContext;
})();