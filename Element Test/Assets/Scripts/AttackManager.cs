using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    [SerializeField]
    private ElementManager elementManager;
    public float Attack(Attack incomingAttack, Damageable target)
    {
        if (incomingAttack.damage > target.defense)
        {
            float damage = incomingAttack.damage - target.defense;
            if (DoesCritHit(incomingAttack.criticalHitRate))
            {
                damage *= incomingAttack.criticalHitDamageMultiplier;
            }
            return damage;
        }

        return 0.0f;
    }

    public float Attack(Attack incomingAttack, Damageable target, Element elementOffensive, Element elementDefensive)
    {
        Debug.Log("Attack Started");
        if (incomingAttack.damage > target.defense)
        {
            float damage = incomingAttack.damage - target.defense;
            damage = elementManager.GetComponent<ElementManager>().CalculateDamage(elementOffensive, elementDefensive, damage);
            if (DoesCritHit(incomingAttack.criticalHitRate))
            {
                Debug.Log("Critical Hit");
                damage *= incomingAttack.criticalHitDamageMultiplier;
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
