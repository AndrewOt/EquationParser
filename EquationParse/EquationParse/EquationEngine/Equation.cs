using System;
using System.Collections;
using System.Text;

namespace EquationParse.EquationEngine
{
	class Equation
	{

		private ArrayList _equation = new ArrayList();
		private string _rawEquation;
		private double _startVal;
		private double _endVal;
		private ArrayList x = new ArrayList();
		private ArrayList y = new ArrayList();

		// Constructors

		public Equation() { }

		public Equation(string equ)
		{
			parseEquation(equ);
		}

		public double startVal
		{
			get { return _startVal; }
		}

		public double endVal
		{
			get { return _endVal; }
		}

		public string rawEquation
		{
			get { return _rawEquation; }
			set { _rawEquation = rawEquation; }
		}

		//public ArrayList equation
		//{
		//	get { return _equation; }
		//}

		public void parseEquation(string rawEquation)
		{
			_rawEquation = rawEquation;
			char[] eq = rawEquation.ToCharArray();
			// Parsing code here...
			for (int i = 0; i < eq.Length; i++)
			{
				if (isOperator(eq[i]))
				{
					_equation.Add(getOperator(eq[i]));
				}
				else if (eq[i] == 'x')
				{
					Variable v = new Variable();
					v.symbol = eq[i];
					_equation.Add(v);
				}
				// Skip white spaces
				else if (eq[i] == ' ') { continue; }
				else
				{
					_equation.Add(eq[i]);
				}
			}
		}

		public void solveEquation(double start, double stop, float step)
		{
			//error checking here, i.e. ensure start <= stop always
			_startVal = start;
			_endVal = stop;
			// Solving code
			ArrayList xList = getRange(start, stop, step);
			ArrayList yList = new ArrayList();

			for(int k = 0; k < xList.Count; k++)
			{

			}
		}

		// Generates the x list
		private ArrayList getRange(double start, double stop, float step)
		{
			ArrayList x = new ArrayList();

			double j = start;
			while(j <= stop)
			{
				x.Add(j);
				j += step;
			}

			return x;
		}

		private bool isOperator(char sym)
		{
			if (sym == Operators.ADDITION || sym == Operators.SUBTRACT || sym == Operators.DIVIDE ||
				sym == Operators.MULTIPLY || sym == Operators.EXPONENTIAL || sym == Operators.ROOT)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		// Assumes the parameter is already an equation symbol
		private char getOperator(char sym)
		{
			if (sym == Operators.ADDITION)
			{
				return Operators.ADDITION;
			}
			else if (sym == Operators.SUBTRACT)
			{
				return Operators.SUBTRACT;
			}
			else if (sym == Operators.DIVIDE)
			{
				return Operators.DIVIDE;
			}
			else if (sym == Operators.EXPONENTIAL)
			{
				return Operators.EXPONENTIAL;
			}
			else if (sym == Operators.MULTIPLY)
			{
				return Operators.MULTIPLY;
			}
			else
			{
				return Operators.ROOT;
			}
		}

		public void Add(string sym)
		{
			_rawEquation += sym;
		}

		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			for(int i = 0; i < _equation.Count; i++)
			{
				if(isOperator(char.Parse(_equation[i].ToString())))
					str.Append(" " + _equation[i].ToString() + " ");
				else
					str.Append(_equation[i].ToString());
			}

			return str.ToString();
		}

	}
}
