using System.IO;
using System.Text;
using cs;
using OneOf;

Console.WriteLine("Hello world");

var inputFile = args[0];


using var fs = File.OpenRead(inputFile);
using var sr = new StreamReader(fs); 
var lexer = new Lexer(sr);
var parser = new Parser(lexer);


// Console.WriteLine(parser.Program());

PrettyPrint.Write(Console.Out, parser.Program());

// while (lexer.NextToken() is {} token and not Token.EOF)
// {
//     Console.WriteLine(token);
// } 
    
Console.WriteLine("Done!");






