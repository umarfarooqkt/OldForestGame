using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is the enumerator 
public enum proType{
 rock, arrow, fireball 
};

public class Projectiles : MonoBehaviour {

	[SerializeField]
    private int attackStrength;
    [SerializeField]
    private proType projectiletype;

    /// getter fo rthe attack strength 
    public int AttackStrength{
     get{
         return attackStrength;
     }
    }

    public proType Projectiletype{
        get{
            return projectiletype;
        }
    }
}
