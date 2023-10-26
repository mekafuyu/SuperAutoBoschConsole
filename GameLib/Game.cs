using System.Collections.Generic;

public class Game
{
    public Game(List<List<Card>> tiers)
        => this.Tiers = tiers;

    public int turn = 0;
    public List<List<Card>> Tiers;
    public AvailableCards AvailableCards = new();
    public Player Player = new();
    public List<Card> RefreshPlayerStore(bool free) 
        => this.Player.RefreshStore(this.Player, this.AvailableCards, free);

    public void ResetPlayerGold()
        => this.Player.gold = 10;

    public void AdvanceTier()
    {
        if(this.turn % 3 == 0)
            this.AvailableCards.AddCards(Tiers[this.turn / 3]);
    }
}