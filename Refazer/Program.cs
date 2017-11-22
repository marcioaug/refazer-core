using System;
using System.Collections.Generic;
using Refazer.Core;
using Tutor;
using Microsoft.ProgramSynthesis;

namespace Refezer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var input =
            @"def product(n, term):
            return term(n)*product(n-1)";
            var output =
            @"def product(n, term):
            if n == 1: 
                return term(1)
            return term(n)*product(n-1)";

            var examples = new List<Tuple<string, string>>() { Tuple.Create(input, output) };
            var refazer = new Refazer4Python();
            var transformations = refazer.LearnTransformations(examples);

            foreach (Transformation transformation in transformations)
            {
                var program = transformation.GetSynthesizedProgram();
                var ast = NodeWrapper.Wrap(ASTHelper.ParseContent(input));
                var inputState = State.CreateForExecution(program.Grammar.InputSymbol, ast);
                var result = program.Invoke(inputState);
                Console.WriteLine(result);
            }
            
            Console.ReadKey();
        }
    }
}
