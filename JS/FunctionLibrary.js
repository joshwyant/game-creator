exports.FunctionLibrary = (function() {
    function FunctionLibraryFactory() {
        var self = this;

        this.List = {};
        this.Register = function(name) {
            var lib = new FunctionLibrary(name);
            self.List[name] = lib;
            self[name] = lib;
        }
    }

    function FunctionLibrary(name) {
        this.Enabled = true;
        this.Name = name;
        this.Functions = {};
        this.Constants = {};
        this.BuiltInVariables = [];
        this.InstanceVariables = [];
    }

    return new FunctionLibraryFactory();
})();