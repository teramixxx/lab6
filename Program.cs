﻿class MainApp
{
    static void Main()
    {
        string roman = "MMXVIII";
        Context context = new Context(roman);

        List<Expression> tree = new List<Expression>
            {
                new ThousandExpression(),
                new HundredExpression(),
                new TenExpression(),
                new OneExpression()
            };

 

        foreach (Expression exp in tree)
        {
            exp.Interpret(context);
        }
        Console.WriteLine("{0} = {1}",
            roman, context.Output);

        Console.ReadKey();
    }
}

class Context
{
    public Context(string input)
    {
        Input = input;
    }

    public string Input { get; set; }
    public int Output { get; set; }
}


abstract class Expression
{
    public void Interpret(Context context)
    {
        if (context.Input.Length == 0)
            return;

        if (context.Input.StartsWith(Nine()))
        {
            context.Output += 9 * Multiplier();
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith(Four()))
        {
            context.Output += 4 * Multiplier();
            context.Input = context.Input.Substring(2);
        }
        else if (context.Input.StartsWith(Five()))
        {
            context.Output += 5 * Multiplier();
            context.Input = context.Input.Substring(1);
        }

        while (context.Input.StartsWith(One()))
        {
            context.Output += 1 * Multiplier();
            context.Input = context.Input.Substring(1);
        }
    }

    public abstract string One();
    public abstract string Four();
    public abstract string Five();
    public abstract string Nine();
    public abstract int Multiplier();
}


class ThousandExpression : Expression
{
    public override string One() { return "M"; }
    public override string Four() { return " "; }
    public override string Five() { return " "; }
    public override string Nine() { return " "; }
    public override int Multiplier() { return 1000; }
}


class HundredExpression : Expression
{
    public override string One() { return "C"; }
    public override string Four() { return "CD"; }
    public override string Five() { return "D"; }
    public override string Nine() { return "CM"; }
    public override int Multiplier() { return 100; }
}


class TenExpression : Expression
{
    public override string One() { return "X"; }
    public override string Four() { return "XL"; }
    public override string Five() { return "L"; }
    public override string Nine() { return "XC"; }
    public override int Multiplier() { return 10; }
}


class OneExpression : Expression
{
    public override string One() { return "I"; }
    public override string Four() { return "IV"; }
    public override string Five() { return "V"; }
    public override string Nine() { return "IX"; }
    public override int Multiplier() { return 1; }
}