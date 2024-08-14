using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHolder : MonoBehaviour
{
    [SerializeField]
    private AttackableObject typeRef;
    public AttackableObject attackable;

    private void Start()
    {
        attackable = Instantiate<AttackableObject>(typeRef);
    }
}
