using EquationParse.EquationEngine;
using System;

namespace EquationParse
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.Write("f(x) = ");
			string e = Console.ReadLine();

			Equation eq = new Equation(e);
			//eq.solveEquation(0.0, 1.0, 1);

			Console.Write(eq.ToString());
			Console.Read();
		}
	}
}
