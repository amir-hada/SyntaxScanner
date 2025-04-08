using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
class Program
{
    static void Main()
    {
        var code = @"
        public class MyService {
            public void SayHello() {
                Console.WriteLine(""Hello, world!"");
            }
        }";

        var tree = CSharpSyntaxTree.ParseText(code);
        var root = tree.GetRoot();

        var method = root.DescendantNodes()
            .OfType<MethodDeclarationSyntax>()
            .FirstOrDefault();

        if (method != null)
        {
            Console.WriteLine("Method found: " + method.Identifier);
        }
        else
        {
            Console.WriteLine("No method found.");
        }
    }
}