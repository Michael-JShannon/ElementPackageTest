using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritVFX : MonoBehaviour
{
    [SerializeField]
    private float destroyCountdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroyCountdown -= Time.deltaTime;
        if(destroyCountdown < 0)
        {
            Destroy(gameObject);
        }
    }
}
