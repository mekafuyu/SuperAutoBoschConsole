public static class DrawConsole
{
    public static void DrawStore(Game game)
    {
        Console.Clear();
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"Gold: {game.Player.gold} | Life: {game.Player.life} | Trophies: {game.Player.trophies} | Turn: {game.turn}\n");
        Console.WriteLine("--------------LOJA-------------");

        foreach (Card card in game.Player.Store.Cards)
        {
            if(card is not null)
                Console.Write(card.Name.Substring(0,5));
            Console.Write("\t");
        }
        Console.WriteLine("\n");

        foreach (Card card in game.Player.Store.Cards)
        {
            if(card is not null)
                Console.Write(card.Attack + " " + card.Life + " " + card.Tier);
            Console.Write("\t");
        }
        Console.WriteLine("\n");

        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Name.Substring(0,5));
            Console.Write("\t");
        }
        Console.WriteLine("\n");
        foreach (Card card in game.Player.Cards.Reverse<Card>())
        {
            if(card is not null)
                Console.Write(card.Attack + " " + card.Life + " " + card.Tier);
            Console.Write("\t");
        }
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

        Console.WriteLine("\n");

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
    }
}