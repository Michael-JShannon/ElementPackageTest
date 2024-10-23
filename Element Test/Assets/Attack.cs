using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack")]
[Serializable]
public class Attack : ScriptableObject
{
    //The amount of damage an attack outputs without modifiers
    [Tooltip("The amount of damage an attack outputs without modifiers")]
    public float damage;

    [Tooltip("The % chance that an attack will critically strike")]
    public float criticalHitRate;
    [Tooltip("How much the damage of a critical strike is multiplied by")]
    public float criticalHitDamageMultiplier;

    [Tooltip("Additional chance that an effect hits the target")]
    public float effectHitRateBonus;

}
