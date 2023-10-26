class App
{
    public App(List<List<Card>> tiers)
    {
        this.game = new(tiers);
        this.game.AvailableCards.AddCards(this.game.Tiers[0]);
        this.game.RefreshPlayerStore(true);
        this.enemy = new(this.game);
    }

    public int Screen = 0;
    public int SellPos = 0;
    private Game game;
    private Player tempPlayer;
    private RandomPlayer enemy;
    private Battle battle;
    private bool upgrading = false;
    private Card selected = null;

    private void buyOrUpgrade(int i)
    {
        if(this.upgrading)
        {
            if(i > this.game.Player.Cards.Count() - 1)
                return;

            if(selected is null)
            {
                selected = this.game.Player.Cards[i];
                return;
            }
            if(this.game.Player.Cards[i].Upgrade(selected))
                this.game.Player.Cards.Remove(selected);

            selected = null;
            return;
        }
        if(i < this.game.Player.Store.MaxCards)
            this.game.Player.Buy(i);
    }

    public void Sell(int i)
    {
        if(i > this.game.Player.Cards.Count() - 1)
            return;

        this.game.Player.Sell(i);
    }

    public void Run()
    {
        switch (Screen)
        {
            case 0:
                DrawConsole.DrawStore(this.game, this.upgrading, this.selected);
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        this.game.RefreshPlayerStore(false);
                        break;

                    case ConsoleKey.D1:
                        this.buyOrUpgrade(0);
                        break;
                    case ConsoleKey.D2:
                        this.buyOrUpgrade(1);
                        break;
                    case ConsoleKey.D3:
                        this.buyOrUpgrade(2);
                        break;
                    case ConsoleKey.D4:
                        this.buyOrUpgrade(3);
                        break;
                    case ConsoleKey.D5:
                        this.buyOrUpgrade(4);
                        break;
                    case ConsoleKey.D6:
                        this.buyOrUpgrade(5);
                        break;
                    case ConsoleKey.S:
                        this.Screen = 1;
                        break;

                    case ConsoleKey.U:
                        this.upgrading = !this.upgrading;
                        break;

                    case ConsoleKey.Enter:
                        if(this.game.Player.Cards.Count() < 1)
                            return;

                        foreach (Card card in this.game.Player.Cards)
                            card.onEndTurn();
                        
                        this.tempPlayer = this.game.Player.Clone() as Player;
                        this.enemy = new( this.game);
                        this.battle = new(this.tempPlayer, this.enemy);

                        this.Screen = 2;
                        break;

                    default:
                        break;
                }
                break;
            case 1:
                DrawConsole.DrawSell(this.game, this.SellPos);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        if(this.SellPos < this.game.Player.Cards.Count() - 1)
                            this.SellPos++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if(this.SellPos > 0)
                            this.SellPos--;
                        break;
                    case ConsoleKey.Enter:
                        this.game.Player.Sell(this.game.Player.Cards.Count() - SellPos - 1);
                        this.SellPos = 0;
                        break;
                    case ConsoleKey.S:
                        this.Screen = 0;
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                DrawConsole.DrawBattle(this.game, this.battle);
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        int victory = this.battle.Figth();

                        if(victory != 0)
                        {
                            this.Screen = 0;
                            this.game.turn += 1;
                            this.game.AdvanceTier();
                            this.game.RefreshPlayerStore(true);
                            this.game.ResetPlayerGold();
                            this.upgrading =  false;
                            foreach (Card card in this.game.Player.Cards)
                            {
                                card.onStartTurn();
                            }
                        }
                        if(victory == 1)
                            this.game.Player.trophies += 1;
                        if(victory == 2)
                            this.game.Player.life -= 1;
                        break;
                    default:
                        break;
                }
                break;
            default:
                this.Screen = 0;
                break;
        }


    }
}