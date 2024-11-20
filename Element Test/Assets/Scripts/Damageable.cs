using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float health, defense;

    public float effectHitResistance;

    public List<Element> effectsOnObject;

    [Space]
    public DamageOutputDisplay outputDisplay;

    private void Start()
    {
        outputDisplay = FindObjectOfType<DamageOutputDisplay>();
    }

    private void Update()
    {
        if (effectsOnObject.Count > 0)
        {
            EffectDamage();
        }
    }

    public void EffectDamage()
    {
        for (int i = 0; i < effectsOnObject.Count; i++)
        {
            Instantiate(effectsOnObject[i].effectVFX, transform);

            if (effectsOnObject[i].DamageOverTime != true)
            {
                TakeDamage(effectsOnObject[i].effectDamage);
                outputDisplay.DisplayEffectDamage(effectsOnObject[i]);
                effectsOnObject.Remove(effectsOnObject[i]);
                return;
            }
            TakeDamage(effectsOnObject[i].effectDamage * Time.deltaTime);
            outputDisplay.DisplayEffectDamage(effectsOnObject[i]);
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;
    }
}
