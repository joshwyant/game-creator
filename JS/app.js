var libs = require('./LibraryContext.js');
var runtime = require('./Runtime.js');
var compiler = require('./Compiler.js');

var code = "globalvar t, u; x /= 3.14159; /*comment*/ t = \"Hello, world!\"";

console.log(code);

var context = new libs.LibraryContext();
var runtime = new runtime.Runtime(context);

var compiler = new compiler.Compiler(runtime);

var delegate = compiler.Compile(code);
