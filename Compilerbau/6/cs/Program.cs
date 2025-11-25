// See https://aka.ms/new-console-template for more information

using Antlr4.Runtime;
using cs;
using Language;

Console.WriteLine("Hello, World!");

var lexer = new MiniCLexer(CharStreams.fromPath("Examples/a-f.c"));
var parser = new MiniCParser(new CommonTokenStream(lexer));
var tree = parser.program();

var program = tree?.ParseProgram();

var table = SymbolTable.GenerateScope(program!, null);

Console.WriteLine(table);
// Console.WriteLine(program);

