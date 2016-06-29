using System;

namespace EquationParse.EquationEngine
{
	class Constant
	{
		private double _val;

		public double val { get { return _val; } set { _val = value; } }

		public override string ToString()
		{
			return  Convert.ToString(_val);
		}
	}
}
