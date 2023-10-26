namespace Cards.Tier1;

public class Martelo : Card
{
    public override string Name { get; set; } = "Martelo";
    public override int Attack { get; set; } = 2;
    public override int Life { get; set; } = 3;
    public override int Tier { get; set; } = 1;


    public override void onSell()
    {
        foreach (Card card in this.Player.Store.Cards)
        {
            if (card is not null)
                card.Life += 1;
        }
    }

    public override object Clone()
    {
        return new Martelo()
        {
            Name = this.Name,
            Attack = this.Attack,
            Life = this.Life,
            Experience = this.Experience,
            Tier = this.Tier
        };
    }
}

public class ChaveFenda : Card
{
    public override string Name { get; set; } = "Chave de Fenda";
    public override int Attack { get; set; } = 2;
    public override int Life { get; set; } = 3;
    public override int Tier { get; set; } = 1; 

    public override void onSell()
    {
        if(this.Player.Cards.Count() < 1)
            return;
        Random rnd = new Random();
        var i = rnd.Next(0, this.Player.Cards.Count());
        this.Player.Cards[i].Life += 1;
    }
    public override object Clone()
    {
        return new ChaveFenda()
        {
            Name = this.Name,
            Attack = this.Attack,
            Life = this.Life,
            Experience = this.Experience,
            Tier = this.Tier
        };
    }
}

public class Esteira : Card
{
    public override string Name { get; set; } = "Esteira";
    public override int Attack { get; set; } = 3;
    public override int Life { get; set; } = 1;
    public override int Tier { get; set; } = 1; 

    public override void onSell()
    {
        this.Player.GiveGold(1);
    }

    public override object Clone()
    {
        return new Esteira()
        {
            Name = this.Name,
            Attack = this.Attack,
            Life = this.Life,
            Experience = this.Experience,
            Tier = this.Tier
        };
    }
}

public class Furadeira : Card
{
    public override string Name { get; set; } = "Furadeira";
    public override int Attack { get; set; } = 2;
    public override int Life { get; set; } = 1;
    public override int Tier { get; set; } = 1; 

    public override void onDie(Battle battle)
    {
        if(this.Player.Cards.Count() < 1)
            return;
        Random rnd = new Random();
        var i = rnd.Next(0, this.Player.Cards.Count());
        this.Player.Cards[i].Attack += 2;
        this.Player.Cards[i].Life += 1;
    }

    public override object Clone()
    {
        return new Furadeira()
        {
            Name = this.Name,
            Attack = this.Attack,
            Life = this.Life,
            Experience = this.Experience,
            Tier = this.Tier
        };
    }


}
