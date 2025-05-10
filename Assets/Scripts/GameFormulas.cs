using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {
        return attackElement == defender.GetWeakness();
    }
    public static bool HasElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        return attackElement == defender.GetResistance();
    }
    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender))
        {
            return 1.5f;
        }
        else if (HasElementDisadvantage(attackElement, defender))
        {
            return 0.5f;
        }
        else
        {
            return 1f;
        }
    }
    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = attacker.Aim - defender.Eva;
        int prob = Random.Range(0, 99);

        if (prob > hitChance)
        {
            Debug.Log("MISS");
            return false;
        }
        else
        { 
            return true;
        }
    }
    public static bool IsCrit(int critValue)
    {
        int randomNum = Random.Range(0, 99);

        if (randomNum < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        else
        { 
            return false;
        }
    }
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats attackerStats = GetTotalSpd(attacker);
        Stats defenderStats = GetTotalSpd(defender);

        int defense = attacker.GetWeapon().GetDmgType() == Weapon.DAMAGE_TYPE.PHYSICAL ? defenderStats.Def : defenderStats.Res;
        int baseDamage = attackerStats.Atk - defense;
        baseDamage = Mathf.Max(baseDamage, 0);

        
        float elementalModifier = EvaluateElementalModifier(attacker.GetWeapon().GetElem(), defender);
        int finalDamage = Mathf.RoundToInt(baseDamage * elementalModifier);

        if (IsCrit(attackerStats.Crt))
            finalDamage *= 2;

        return finalDamage = Mathf.Max(0, finalDamage);
    }

    public static Stats GetTotalSpd(Hero hero)
    { 
        return Stats.Sum(hero.GetBaseStats(), hero.GetWeapon().GetBonusStats());    
    }
}










