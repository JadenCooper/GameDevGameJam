using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : KnockBack
{
    public void HitPlayer(GameObject hitTarget)
    {
        base.Knock(hitTarget.transform.position);
        Debug.Log("Hit player");
    }
}
