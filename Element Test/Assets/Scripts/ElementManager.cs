using Unity.VisualScripting;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
    [SerializeField]
    Element[] elementsInPlay;

    [SerializeField]
    DamageOutputDisplay outputDisplay;

    public float CalculateDamage(Element offense, Element defense, float attackDamage)
    {
        float damageMod = 1.0f;
        foreach (Element ele in defense.weaknesses)
        {
            if (ele == offense)
            {
                outputDisplay.DisplaySuperEffectiveHit(true, defense);
                damageMod += defense.weaknessBonus;
            }
        }

        foreach (Element ele in defense.resistances)
        {
            if (ele == offense)
            {
                outputDisplay.DisplaySuperEffectiveHit(false, defense);
                damageMod -= defense.defensiveRes;
            }
        }
        return (attackDamage * damageMod);
    }

    public bool DoesEffectHit(Element effectElement, Element defenseElement, Attack incomingAttack, Damageable defender)
    {
        float rand = UnityEngine.Random.Range(0.0f, 100.0f);

        float effectHit = effectElement.effectChance * (1.0f - (defenseElement.effectRes / 100)) * (1.0f + (incomingAttack.effectHitRateBonus / 100)) * (1.0f - (defender.effectHitResistance / 100));
        Debug.Log(effectHit < rand);
        return effectHit < rand;
    }

    public void ApplyEffect(Damageable affectedChar, Element affectingElement)
    {
        affectedChar.effectsOnObject.Add(affectingElement);
        //for (int i = 0; i < affectedChar.effectsOnObject.Length; i++)
        //{
        //    if (affectedChar.effectsOnObject[i] != null)
        //    {
        //        affectedChar.effectsOnObject.SetValue(affectingElement, i);
        //    }
        //}
    }

    public void AssignRandomElementToObject(GameObject target)
    {
        float rand = UnityEngine.Random.Range(0, elementsInPlay.Length);
        for (int i = 0; i <= rand; i++)
        {
            if (i == rand)
            {
                if(target.GetComponent<ElementHolder>() != null && target.GetComponent<ElementHolder>().element != elementsInPlay[i])
                {
                    target.GetComponent<ElementHolder>().element = elementsInPlay[i];
                }
                else if (target.GetComponent<ElementHolder>() == null)
                {
                    target.AddComponent<ElementHolder>().element = elementsInPlay[i];
                }
            }
        }
    }
}
