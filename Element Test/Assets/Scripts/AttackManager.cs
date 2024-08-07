using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    public float Attack(AttackableObject attacker, AttackableObject defender)
    {
        if (attacker.attack > defender.defense)
        {
            float damage = attacker.attack - defender.defense;
            if (DoesCritHit(attacker.criticalHitRate))
            {
                damage *= attacker.criticalHitDamageMultiplier;
            }
            return damage;
        }

        return 0.0f;
    }

    public float Attack(AttackableObject attacker, AttackableObject defender, Element elementOffensive, Element elementDefensive)
    {
        Debug.Log("Attack Started");
        if (attacker.attack > defender.defense)
        {
            float damage = attacker.attack - defender.defense;
            GameObject elementManager = GameObject.Find("ElementManager");
            damage = elementManager.GetComponent<ElementManager>().CalculateDamage(elementOffensive, elementDefensive, damage);
            if (DoesCritHit(attacker.criticalHitRate))
            {
                Debug.Log("Critical Hit");
                damage *= attacker.criticalHitDamageMultiplier;
            }
            Debug.Log(damage);
            return damage;
        }
        return 0.0f;
    }

    public bool DoesCritHit(float critHitRate)
    {
        float rand = UnityEngine.Random.Range(0.0f, 100.0f);

        return critHitRate > rand;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
