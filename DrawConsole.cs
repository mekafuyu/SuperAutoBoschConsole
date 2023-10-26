using System;
public static class DrawConsole
{
    public static void DrawStore(Game game, bool upgrading, Card selected)
    {
        Console.Clear();
        Console.WriteLine("Press\n  U: on/off Upgrade Mode\tS: on/off Sell Mode\tEnter: Enter Battle");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Gold: {game.Player.gold} | Life: {game.Player.life} | Trophies: {game.Player.trophies} | Turn: {game.turn}\n");
        if(upgrading)
            Console.WriteLine("-------------UPGRADE-----------");
        else
            Console.WriteLine("--------------LOJA-------------");

        foreach (Card card in game.Player.Store.Cards)
        {
            if(card is not null)
                Console.Write(card.Name.Substring(0,5));
            Console.Write("\t");
        }
        Console.WriteLine("");
        foreach (Card card in game.Player.Store.Cards)
        {
            if(card is not null)
                Console.Write($"{card.Level}   {card.Experience}");
            Console.Write("\t");
        }
        Console.WriteLine("");
        foreach (Card card in game.Player.Store.Cards)
        {
            if(card is not null)
                Console.Write(card.Attack + " " + card.Life + " " + card.Tier);
            Console.Write("\t");
        }

        Console.WriteLine("\n");

        if(upgrading)
            foreach (Card card in game.Player.Cards.Reverse<Card>())
            {
                if(card is not null && card == selected)
                    Console.Write($"  V");
                Console.Write("\t");
            }
        Console.WriteLine();

        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Name.Substring(0,5));
            Console.Write("\t");
        }
        Console.WriteLine();
        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write($"{card.Level}   {card.Experience}");
            Console.Write("\t");
        }
        Console.WriteLine();
        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Attack + " " + card.Life + " " + card.Tier);
            Console.Write("\t");
        }
        Console.WriteLine();
    }

    public static void DrawBattle(Game game, Battle battle)
    {
        Console.Clear();
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Life: {game.Player.life}");
        Console.WriteLine("------------BATALHA!-----------");

        foreach (Card card in battle.Player1.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Name.Substring(0,5));
            Console.Write("\t");
        }
        Console.Write("\t\t");
        foreach (Card card in battle.Player2.Cards)
        {
            if(card is not null)
                Console.Write(card.Name.Substring(0,5));
            Console.Write("\t");
        }

        Console.WriteLine();
        foreach (Card card in battle.Player1.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write($"{card.Level}   {card.Experience}");
            Console.Write("\t");
        }
        Console.Write("\t\t");
        foreach (Card card in battle.Player2.Cards)
        {
            if(card is not null)
                Console.Write($"{card.Level}   {card.Experience}");
            Console.Write("\t");
        }
        Console.WriteLine();

        foreach (Card card in battle.Player1.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Attack + " " + card.Life + " " + card.Tier);
            Console.Write("\t");
        }
        Console.Write("\t\t");
        foreach (Card card in battle.Player2.Cards)
        {
            if(card is not null)
                Console.Write(card.Attack + " " + card.Life + " " + card.Tier);
            Console.Write("\t");
        }
        Console.WriteLine();
    }

    public static void DrawSell(Game game, int pos)
    {
        Console.Clear();
        Console.WriteLine("Press\n  S: on/off Sell Mode");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Gold: {game.Player.gold} | Life: {game.Player.life} | Trophies: {game.Player.trophies} | Turn: {game.turn}\n");
        Console.WriteLine("------------VENDENDO-----------");

        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Name.Substring(0,5));
            Console.Write("\t");
        }
        Console.WriteLine();
        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write($"{card.Level}   {card.Experience}");
            Console.Write("\t");
        }
        Console.WriteLine();
        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Attack + " " + card.Life + " " + card.Tier);
            Console.Write("\t");
        }

        Console.WriteLine();

        for (int i = 0; i < pos; i++)
            Console.Write("\t");
        Console.Write("  ^");
        Console.WriteLine();
    }
}