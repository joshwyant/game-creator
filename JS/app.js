var lex = require ('./Lexer.js');

var tr = new lex.TextReader("globalvar t, u; x /= 3.14159; /*comment*/ t = \"Hello, world!\"");

console.log(tr.text);

var lexer = new lex.Lexer(tr);

var tok = lexer.Scan();
while (tok.t != lex.Token.Eof.t) {
    console.log(tok);

    tok = lexer.Scan();
}