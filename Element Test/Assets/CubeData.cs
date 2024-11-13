using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeData : MonoBehaviour
{
    Attack m_attack;
    Damageable m_damageable;

    // Start is called before the first frame update
    void Start()
    {
        m_attack = GetComponent<AttackHolder>().attack;
        m_damageable = GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_damageable.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
