using UnityEngine;

public class ElementManager : MonoBehaviour
{
    [SerializeField]
    Element[] elementsInPlay;

    public float CalculateDamage(Element offense, Element defense, float attackDamage)
    {
        float damageMod = 1.0f;
        foreach (Element ele in defense.weaknesses)
        {
            if (ele == offense)
            {
                Debug.Log("Super Effective Damage");
                damageMod += defense.weaknessBonus;
            }
        }

        foreach (Element ele in defense.resistances)
        {
            if (ele == offense)
            {
                Debug.Log("Not Very Effective Damage");
                damageMod -= defense.defensiveRes;
            }
        }
        return (attackDamage * damageMod);
    }

    public bool DoesEffectHit(Element effectElement, Element defenseElement, Attack incomingAttack, Damageable defender)
    {
        float rand = UnityEngine.Random.Range(0.0f, 100.0f);

        float effectHit = effectElement.effectChance * (1.0f - defenseElement.effectRes) * (1.0f + incomingAttack.effectHitRateBonus) * (1.0f - defender.effectHitResistance);

        return effectHit < rand;
    }

    public void ApplyEffect(AttackableObject affectedChar, Element affectingElement)
    {
        for (int i = 0; i < affectedChar.effectsOnObject.Length + 1; i++)
        {
            if (affectedChar.effectsOnObject[i] != null)
            {
                affectedChar.effectsOnObject[i] = affectingElement;
            }
        }
        
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
