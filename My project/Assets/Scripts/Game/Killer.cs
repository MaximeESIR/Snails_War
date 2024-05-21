using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A class for everything that can do dmg to an ennemy
public class Killer : MonoBehaviour
{
    public string m_owner;

//We do dmg to the ennemy. We coudl improve that..
     private void OnCollisionStay(Collision collision)
    {
        if ((m_owner == "Snail" && collision.gameObject.tag == "Ennemy")
        || m_owner == "Ennemy" && collision.gameObject.tag == "Snail")
        {
            Snail_2 ennemyScript=collision.gameObject.GetComponent<Snail_2>();
            if(ennemyScript!=null){
                ennemyScript.takeDamage(5);
            }
        }
    }
}
