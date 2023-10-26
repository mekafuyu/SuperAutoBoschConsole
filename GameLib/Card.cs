using System;

public class Card : ICloneable
{

    public virtual string Name { get; set; }
    public virtual Player Player { get; set; }
    public virtual int Life { get; set; }
    public virtual int Attack { get; set; }
    public virtual int Experience { get; set; } = 1;
    public virtual int Level => (int)(this.Experience/3) + 1;
    public virtual int Tier { get; set; }

    public virtual bool Upgrade(Card cardToUpgrade)
    {
        if(cardToUpgrade.Name != this.Name || cardToUpgrade == this)
            return false;
        
        
        this.Attack = this.Attack > cardToUpgrade.Attack ? this.Attack + 1 : cardToUpgrade.Attack + 1;
        this.Life = this.Life > cardToUpgrade.Life ? this.Life + 1 : cardToUpgrade.Life + 1;
        this.Experience += cardToUpgrade.Experience;
        return true;
    }

    public virtual void AttackCard(Card enemy)
    {
        enemy.Life -= this.Attack;
        if(enemy.Life > 0)
            enemy.onReceiveDamage();
    }
    public virtual void onBuy(){}
    public virtual void onSell(){}
    public virtual void onBeforeAttack(){}
    public virtual void onAttack(){}
    public virtual void onReceiveDamage(){}
    public virtual void onLevelUp(){}
    public virtual void onStartTurn(){}
    public virtual void onEndTurn(){}
    public virtual void onStartBattle(Battle battle){}
    public virtual void onEndBattle(Battle battle){}

    public virtual object Clone() {return new Card();}
    // {
    //     return new Card(){};
    // }
}