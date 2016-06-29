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
		private ArrayList _x = new ArrayList();
		private ArrayList _y = new ArrayList();
		private const int STEP_DEFAULT = 1;
		private const int START_DEFAULT = -10;
		private const int END_DEFAULT = 10;

		// Constructors

		public Equation() { }

		public Equation(string equ)
		{
			parseEquation(equ);
		}

		// Property mutators and acessors 
		public double startVal { get { return _startVal; } }
		public double endVal { get { return _endVal; } }
		public string rawEquation {	get { return _rawEquation; } set { _rawEquation = rawEquation; } }
		public ArrayList x { get { return _x; } set { _x = x; } } 
		public ArrayList y { get { return _y; } }

		//public ArrayList equation
		//{
		//	get { return _equation; }
		//}

		private void parseEquation(string rawEquation)
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
				// if variable x (and in the future y)
				else if (eq[i] == 'x')
				{
					Variable v = new Variable();
					v.symbol = eq[i];
					_equation.Add(v);
				}
				// Skip white spaces
				else if (eq[i] == ' ') { continue; }
				// If is number
				else
				{
					Constant c = new Constant();
					c.val = double.Parse(Convert.ToString(eq[i]));
					_equation.Add(c);
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

			// For each element in the x list, run it through the equation
			for(int k = 0; k < xList.Count; k++)
			{
				double yElement = 0;
				//if (xList[k].GetType() == typeof(Constant))
				//{
				//}

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
				{
					//Console.WriteLine(_equation[i]);
					str.Append(" " + _equation[i].ToString() + " ");
				}
				else
				{
					//Console.WriteLine(_equation[i]);
					str.Append(_equation[i].ToString());
				}
					
			}

			return str.ToString();
		}

	}
}
