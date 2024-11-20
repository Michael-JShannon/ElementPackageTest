using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    public GameObject rayFireLocation;
    public AttackManager attackManager;
    public ElementManager elementManager;
    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Cube");

        AssignRandElement();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f, mask))
            {
                GameObject defender = hit.collider.gameObject;
                Attack incomingAttack = GetComponentInParent<AttackHolder>().attack;
                float damage = attackManager.Attack(incomingAttack, defender.GetComponent<Damageable>(), GetComponentInParent<ElementHolder>().element, defender.GetComponent<ElementHolder>().element);
                defender.GetComponent<Damageable>().TakeDamage(damage);
                if(elementManager.DoesEffectHit(GetComponentInParent<ElementHolder>().element, defender.GetComponent<ElementHolder>().element, incomingAttack, defender.GetComponent<Damageable>()))
                {
                    Debug.Log("Effect Applied");
                    elementManager.ApplyEffect(defender.GetComponent<Damageable>(), GetComponentInParent<ElementHolder>().element);
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            AssignRandElement();
        }
    }

    void AssignRandElement()
    {
        GameObject temp = new GameObject();
        temp.AddComponent<ElementHolder>();
        elementManager.AssignRandomElementToObject(temp);
        GetComponentInParent<ElementHolder>().element = temp.GetComponent<ElementHolder>().element;
        Destroy(temp);
    }
}
