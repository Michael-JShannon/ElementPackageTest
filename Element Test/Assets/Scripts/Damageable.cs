using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float health, defense;

    public float effectHitResistance;

    public Element[] effectsOnObject;

    public void EffectDamage()
    {
        for (int i = 0; i < effectsOnObject.Length; i++)
        {
            TakeDamage(effectsOnObject[i].effectDamage);
            if (effectsOnObject[i].DamageOverTime != true)
            {
                effectsOnObject[i] = null;
            }
        }
    }

    public void TakeDamage(float damageToTake)
    {
        Debug.Log("Damage taken = " + damageToTake);
        health -= damageToTake;
    }
}
