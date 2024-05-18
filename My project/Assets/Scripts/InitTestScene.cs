using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTestScene : MonoBehaviour
{
    public GameObject environment;
    public GameObject basicSnail;
    public GameObject snailGeneral;
    public GameObject basicSlug;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(environment, new Vector3(0, 0, 0), basicSnail.transform.rotation) ;
        //Instantiate(basicSnail, new Vector3(0, 1, 2), snailGeneral.transform.rotation) ;
        //Instantiate(snailGeneral, new Vector3(0, 1, 0), basicSnail.transform.rotation) ;
        //Instantiate(basicSlug, new Vector3(0, 1, 1), basicSnail.transform.rotation) ;
        
    }
}
