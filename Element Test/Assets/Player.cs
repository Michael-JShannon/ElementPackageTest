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
            Debug.Log("Mouse Clicked");
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100f, mask))
            {
                Debug.Log("Hit");
                GameObject defender = hit.collider.gameObject;
                AttackableObject attacker = GetComponentInParent<AttackHolder>().attackable;
                float damage = attackManager.Attack(attacker, defender.GetComponent<AttackHolder>().attackable, GetComponentInParent<ElementHolder>().element, defender.GetComponent<ElementHolder>().element);
                defender.GetComponent<AttackHolder>().attackable.TakeDamage(damage);
                Debug.Log("Damage dealt = " + damage);
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
