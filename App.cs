class App
{
    public App(List<List<Card>> tiers)
    {
        this.game = new(tiers);
        this.game.AvailableCards.AddCards(this.game.Tiers[0]);
        this.game.RefreshPlayerStore(true);
        this.enemy = new(this.game.AvailableCards);
    }

    public int Screen = 0;
    private Game game;
    private Player tempPlayer;
    private RandomPlayer enemy;
    private Battle battle;

    public void Run()
    {
        switch (Screen)
        {
            case 0:
                DrawConsole.DrawStore(this.game);
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        this.game.RefreshPlayerStore(false);
                        break;

                    case ConsoleKey.D1:
                        this.game.Player.Buy(0);
                        break;

                    case ConsoleKey.D2:
                        this.game.Player.Buy(1);
                        break;

                    case ConsoleKey.D3:
                        this.game.Player.Buy(2);
                        break;

                    case ConsoleKey.Enter:
                        if(this.game.Player.Cards.Count() < 1)
                            return;

                        foreach (Card card in this.game.Player.Cards)
                            card.onEndTurn();
                        
                        this.tempPlayer = this.game.Player.Clone() as Player;
                        this.enemy = new(this.game.AvailableCards);
                        this.battle = new(this.tempPlayer, this.enemy);

                        this.Screen = 1;
                        break;

                    default:
                        break;
                }
                break;
            case 1:
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