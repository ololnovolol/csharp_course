using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;

Runner();




void Runner()
{

    ScriptEngine engine = Python.CreateEngine();
    ScriptScope scope = engine.CreateScope();

    File1(engine, scope);
    Console.WriteLine();
    File2(engine, scope);
}

void File1(ScriptEngine engine, ScriptScope scope)
{
    Console.WriteLine("File 1");

    int y = 22;

    scope.SetVariable("y", y);
    engine.ExecuteFile("hello.py", scope);

    dynamic x = scope.GetVariable("x");
    dynamic z = scope.GetVariable("z");

    Console.WriteLine($"{x} + {y} = {z}");

}

void File2(ScriptEngine engine, ScriptScope scope)
{
    Console.WriteLine("File 2");

    int n = 5;

    scope.SetVariable("n", n);
    engine.ExecuteFile("hello2.py", scope);

    dynamic square = scope.GetVariable("square");
    dynamic result = square(n);

    Console.WriteLine(result);

}






