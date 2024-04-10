using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HeandlerHealth
{
    protected override void Death()
    {
        Destroy(this.gameObject);
    }
}
