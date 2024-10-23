using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHolder : MonoBehaviour
{
    [SerializeField]
    private Attack typeRef;
    public Attack attack;

    private void Start()
    {
        attack = Instantiate<Attack>(typeRef);
    }
}
