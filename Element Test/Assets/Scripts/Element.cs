using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Element")]
[Serializable]
public class Element : ScriptableObject
{
    public Element[] weaknesses;
    public Element[] resistances;
    public Element[] strengths;

    [Tooltip("Damage Multiplier if hit by a type in this type's weakness list with 1 being a 2x multiplier")]
    public float weaknessBonus;
    [Tooltip("Damage Multiplier if hit by a type in this type's resistances list with 1 being a 2x multiplier")]
    public float defensiveRes;

    public string effectName;
    [Tooltip("Chance of effect hitting in %")]
    public float effectChance;
    [Tooltip("Chance of resisting effects from other elements in %")]
    public float effectRes;
    [Tooltip("Whether the effect is a Damage over Time effect or a single instance")]
    public bool DamageOverTime;
    [Tooltip("Damage done by effect")]
    public float effectDamage;
}
