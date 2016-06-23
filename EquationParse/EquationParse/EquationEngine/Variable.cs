namespace EquationParse.EquationEngine
{
	class Variable
	{
		private char _symbol;

		public virtual char symbol { get; set; }

		public override string ToString()
		{
			return symbol.ToString();
		}
	}
}
