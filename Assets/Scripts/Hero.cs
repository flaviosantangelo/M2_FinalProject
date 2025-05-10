using System;
using UnityEngine;

[Serializable]
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    public Hero(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;
    }

    public string GetName() => name;
    public void SetName(string name) => this.name = name;
    
    public int GetHp() => hp;
    public void SetHp(int hp) => this.hp = hp < 0 ? 0 : hp;

    public Stats GetBaseStats() => baseStats;
    public void SetBaseStats(Stats baseStats) => this.baseStats = baseStats;
 
    public ELEMENT GetResistance() => resistance;
    public void SetResistance(ELEMENT resistence) => this.resistance = resistence;
  
    public ELEMENT GetWeakness() => weakness;
    public void SetWeakness(ELEMENT weakness) => this.weakness = weakness;
    
    public Weapon GetWeapon() => weapon;
    public void SetWeapon(Weapon weapon) => this.weapon = weapon;
   
    public void AddHp(int amount)
    {
        SetHp(this.hp += amount);
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }
    public bool IsAlive()
    {
        return hp > 0;
    }
}
