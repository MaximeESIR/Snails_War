using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A class for everything that can do dmg to an ennemy
public class KillerSnail : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//We do dmg to the ennemy. We coudl improve that..
     private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Snail")
        {
            Snail  ennemyScript=collision.gameObject.GetComponent<Snail>();
            if(ennemyScript!=null){
                ennemyScript.takeDamage(5);
            }
        }
    }
     private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Snail")
        {
            Snail ennemyScript=collision.gameObject.GetComponent<Snail>();
            if(ennemyScript!=null){
                ennemyScript.takeDamage(5);
            }
        }
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Snail")
        {
            Snail ennemyScript=collision.gameObject.GetComponent<Snail>();
            if(ennemyScript!=null){
                ennemyScript.takeDamage(5);
            }
        }
    }
}
