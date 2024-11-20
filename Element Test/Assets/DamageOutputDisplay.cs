using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageOutputDisplay : MonoBehaviour
{
    [SerializeField]
    Player player;

    TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(text.text != null)
        {
            ClearDisplay();
        }
    }

    public void DisplayDamage(float damage)
    {
        text.text += " " + damage.ToString() + " damage dealt!";
    }

    public void DisplaySuperEffectiveHit(bool isSuperEffective, Element element)
    {
        if(isSuperEffective)
        {
            text.text += " Attack was Super Effective against " + element.name + ".";
        }
        else if (!isSuperEffective)
        {
            text.text += " Attack was not very effective against " + element.name + ".";
        }
    }

    public void DisplayEffectDamage(Element element)
    {
        text.text += "Took " + element.effectDamage + " effect damage from " + element.effectName;
    }

    public void ClearDisplay()
    {
        text.text = "";
    }
}
