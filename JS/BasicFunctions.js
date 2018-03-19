var flib = require('./FunctionLibrary.js');

flib.FunctionLibrary.Register("BasicFunctions");

flib.FunctionLibrary.BasicFunctions.Functions = {
    show_message: function(msg) {
        alert(msg);
    }
};

flib.FunctionLibrary.BasicFunctions.Constants = {
    c_red: 0x0000FF
};