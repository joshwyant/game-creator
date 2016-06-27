var lex = require ('./Lexer.js');
var parse = require('./Parser.js');
var libs = require('./LibraryContext.js');
var visit = require('./NodeVisitor.js');

var tr = new lex.TextReader("globalvar t, u; x /= 3.14159; /*comment*/ t = \"Hello, world!\"");

console.log(tr.text);

var lexer = new lex.Lexer(tr);

var parser = new parse.Parser(new libs.LibraryContext(), lexer);

var tree = parser.Parse();

var visitor = new visit.NodeVisitor();

visitor.VisitNode(tree);

console.log(tree);