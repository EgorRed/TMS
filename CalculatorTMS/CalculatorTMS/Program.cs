using CalculatorTMS;



static double Calculate(in string expression)
{
    Tokenizer tokenizer = new Tokenizer();
    ShuntingYardAlgorithm shuntingYardAlgorithm = new ShuntingYardAlgorithm();
    PostfixNotationCalculator postfixNotationCalculator = new PostfixNotationCalculator();
    return postfixNotationCalculator.Calculate(shuntingYardAlgorithm.Apply(tokenizer.Parse(expression))).Value;
}


static void start()
{
    while (true)
    {
        var expression = Console.ReadLine();
        Console.WriteLine(Calculate(expression));
        
        Console.WriteLine("Want to try again? (y/n)");
        var mass = Console.ReadLine();
        if (mass == "n")
            return;      
    }
}

start();