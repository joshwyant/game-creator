exports.Enum = function(names) {
    function NamedNumber(num, name) {
        this.name = name;
        this.value = num;
    }

    NamedNumber.prototype.valueOf = function () {
        return this.value;
    }
    NamedNumber.prototype.toString = function() {
        return this.name;
    }

    for (var i = 0; i < names.length; i++) {
        var name = names[i];
        this[name] = new NamedNumber(i, name);
    }
}
