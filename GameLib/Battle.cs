public class Battle
{
    public Battle(Player player1, Player player2)
    {
        this.Player1 = player1;
        foreach (Card card in this.Player1.Cards)
            card.onStartBattle(this);

        this.Player2 = player2;
        foreach (Card card in this.Player2.Cards)
            card.onStartBattle(this);
    }
    // private static Battle curr = new Battle(null, null);
    // public static Battle Current => curr;

    public Player Player1 { get; set; }
    public Player Player2 { get; set; }
    
    // public static void New(Player player1, Player player2)
    //     => curr = new Battle(player1, player2);

    public int Figth()
    {
        if(Player1.Cards.Count() == 0 && Player2.Cards.Count() == 0)
            return 3;
        if(Player1.Cards.Count() == 0)
            return 2;
        if(Player2.Cards.Count() == 0)
            return 1;

        var card1 = Player1.Cards.First();
        var card2 = Player2.Cards.First();

        card1.onBeforeAttack();
        card2.onBeforeAttack();

        card1.AttackCard(card2);
        card2.AttackCard(card1);

        if(card1.Life < 1)
            Player1.Cards.Remove(card1);
        if(card2.Life < 1)
            Player2.Cards.Remove(card2);
        return 0;
    }
}