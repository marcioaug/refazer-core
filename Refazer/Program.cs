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
            @"def product(n):
                return n * 2";
            var output =
            @"def product(n):
                return n / 2";

            var input2 =
            @"def product(n):
                a = b * 43";
            var output2 =
            @"def product(n):
                a = b / 43";

            var input3 =
            @"def product(n):
                return n * 1";
            var output3 =
            @"def product(n):
                return n * 1";

            var examples = new List<Tuple<string, string>>() {
                Tuple.Create(input, output),
                Tuple.Create(input2, output2),
                Tuple.Create(input3, output3)
            };
            var refazer = new Refazer4Python();
            var transformations = refazer.LearnTransformations(examples);

            foreach (Transformation transformation in transformations)
            {
                var program = transformation.GetSynthesizedProgram();
                var ast = NodeWrapper.Wrap(ASTHelper.ParseContent(
                    @"def production(n):
                        return total * 8"
                ));
                var ast2 = NodeWrapper.Wrap(ASTHelper.ParseContent(
                    @"def production(n):
                        total = parcial * 8"
                ));
                var ast3 = NodeWrapper.Wrap(ASTHelper.ParseContent(
                    @"def production(n):
                        total = parcial * 8"
                ));
                var inputState = State.CreateForExecution(program.Grammar.InputSymbol, ast);
                var inputState2 = State.CreateForExecution(program.Grammar.InputSymbol, ast2);
                var inputState3 = State.CreateForExecution(program.Grammar.InputSymbol, ast3);

                PythonNode result = ((List<PythonNode>) program.Invoke(inputState))[0];
                Console.WriteLine(new Unparser().Unparse(result));

                result = ((List<PythonNode>)program.Invoke(inputState2))[0];
                Console.WriteLine(new Unparser().Unparse(result));

                result = ((List<PythonNode>)program.Invoke(inputState3))[0];
                Console.WriteLine(new Unparser().Unparse(result));
            }
            
            Console.ReadKey();
        }
    }
}
