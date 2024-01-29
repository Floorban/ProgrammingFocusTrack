using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject
{
    public string abilityName;
    public float activeTime;
    public float cooldownTime;
    public virtual void Activate(GameObject player)
    {

    }
}
