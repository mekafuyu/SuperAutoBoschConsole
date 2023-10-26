List<List<Card>> tiers = new()
{
    new()
    {
        new Cards.Tier1.Martelo(),
        new Cards.Tier1.ChaveFenda(),
        new Cards.Tier1.Esteira(),
    },
    new()
    {
        new Cards.Tier2.FornoIndustrialGas(),
        new Cards.Tier2.FuradeiraColuna(),
        new Cards.Tier2.RetificadaPlana(),
    },
    new()
    {
        new Cards.Tier3.FornoIndustrialEletrico(),
        new Cards.Tier3.FuradeiraCoordenada(),
        new Cards.Tier3.RetificadaCilindrica(),
    },
    new()
    {
        new Cards.Tier4.Fresa(),
        new Cards.Tier4.Torno(),
    },
    new()
    {
        new Cards.Tier5.FresaCNC(),
        new Cards.Tier5.TornoCNC(),
    },
    new()
    {
        new Cards.Tier6.CortePlamasCNC(),
    }
};

bool running = true;
App app = new(tiers);

while (running)
{
    app.Run();
}
