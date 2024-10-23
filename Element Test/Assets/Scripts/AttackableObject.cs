using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AttackableObject")]
[Serializable]
public class AttackableObject : ScriptableObject
{
    public float health, defense, attack;

    public float criticalHitRate;
    public float criticalHitDamageMultiplier;

    public float effectHitRateBonus;
    public float effectHitResistance;

    public Element[] effectsOnObject;

    public void EffectDamage()
    {
        for(int i = 0; i < effectsOnObject.Length; i++)
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
