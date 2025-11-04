// See https://aka.ms/new-console-template for more information

using _4;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Language;

Console.WriteLine("Hello, World!");

var testInput = 
"""
abc := 123       # test       
bcd := 456          # hello world      
ttt := abc    == 123
        ttt := abc != 123
ttt :=    abc >= 123
ttt := abc >    123
   ttt := abc < 123
a := 1  +   2
a := 3 + 4 * 5

if a > b do

else
    b := a
end

if a > b do
end

a     := 0
    if    10 < 1
       do
a    :=     42      # Zuweisung des Wertes 42 an die Variable a
else do
        a :=      7
              while    10 < 1
       do
a    :=     42      # Zuweisung des Wertes 42 an die Variable a
  end
  end

""";


var lexer = new LanguageLexer(CharStreams.fromString(testInput));
var parser = new LanguageParser(new CommonTokenStream(lexer));

var tree = parser.start();
Console.WriteLine(tree.ToStringTree());

var astVisitor = new AstVisitor();
var ast = (IAstNode)astVisitor.Visit(tree);
// Console.WriteLine(ast);
Console.WriteLine(string.Join("\n", ast.BuildSource()));


// var writer = new StringWriter();
// var printer = new Parser.TraceListener(writer, parser);
// ParseTreeWalker.Default.Walk(printer, tree);
// Console.WriteLine(writer.ToString());

// var printer = new PrettyPrinterListener(Console.Out);
// ParseTreeWalker.Default.Walk(printer, tree);





