using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] private Hero a;
    [SerializeField] private Hero b;

    void Update()
    {
        if (!a.IsAlive() || !b.IsAlive())
        {
            return;
        }

        Hero primoAttaccante;
        Hero secondoAttaccante;

        if (GameFormulas.GetTotalSpd(a).Spd > GameFormulas.GetTotalSpd(b).Spd)
        {
            primoAttaccante = a;
            secondoAttaccante = b;
        }
        else
        {
            primoAttaccante = b;
            secondoAttaccante = a;
        }

        Attacco(primoAttaccante, secondoAttaccante);

        if (secondoAttaccante.IsAlive())
        {
            Attacco(secondoAttaccante, primoAttaccante);
        }
        else
        {
            Debug.Log($"GLI HP DI {secondoAttaccante.GetName()} SONO ESAURITI, IL VINCITORE E' {primoAttaccante.GetName()}");
        }
    }

    public void Attacco(Hero attacker, Hero defender)
    {
        Debug.Log($"E' il turno di attacco di {attacker.GetName()} , il difensore sarà {defender.GetName()}");

        if (GameFormulas.HasHit(GameFormulas.GetTotalSpd(attacker), GameFormulas.GetTotalSpd(defender)))
        {

            if (GameFormulas.HasElementAdvantage(attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log("WEAKNESS!");
            }
            else if (GameFormulas.HasElementDisadvantage(attacker.GetWeapon().GetElem(), defender))
            {
                Debug.Log("RESIST!");
            }

            int damage = GameFormulas.CalculateDamage(attacker, defender);
            Debug.Log($"Verranno inflitti {damage} danni");
            defender.TakeDamage(damage);

            if (!defender.IsAlive())
            {
                Debug.Log($"IL VINCITORE E' {attacker.GetName()}");
            }

        }
    }
}

    
    
      
