using CalculatorTMS;



static double Calculate(in string expression)
{
    Tokenizer tokenizer = new Tokenizer();
    ShuntingYardAlgorithm shuntingYardAlgorithm = new ShuntingYardAlgorithm();
    PostfixNotationCalculator postfixNotationCalculator = new PostfixNotationCalculator();
    return postfixNotationCalculator.Calculate(shuntingYardAlgorithm.Apply(tokenizer.Parse(expression))).Value;
}

Console.WriteLine(Calculate("2 + 8 * 23 * 5 / 2 + (2 * 5)"));

