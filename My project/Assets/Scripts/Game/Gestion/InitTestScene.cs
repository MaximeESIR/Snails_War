using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTestScene : MonoBehaviour
{
    public GameObject environment;
    public GameObject basicSnail;
    public GameObject ennemy;
    public GameObject scene;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(environment, new Vector3(0, 0, 0), basicSnail.transform.rotation) ;
        Instantiate(basicSnail, new Vector3(0, 0, 0), basicSnail.transform.rotation) ;
        Instantiate(ennemy, new Vector3(0, 0.5f, 0), basicSnail.transform.rotation) ;
        //Instantiate(basicSlug, new Vector3(0, 1, 1), basicSnail.transform.rotation) ;

        int nbEnnemy=20;
        for (int i = 0 ; i < nbEnnemy ; i++)
        {
            // Tirer une position aléatoire
            float posX = Random.Range(-50, 50);
            float posZ = Random.Range(-50, 50);
            // Créer une copie avec la position et l'orientation voulue
            GameObject en = Instantiate(ennemy, new Vector3(posX, 0, posZ), ennemy.transform.rotation) ;

            // Rattache l'objet instancié à l'objet forest
            en.transform.SetParent(scene.transform);
        }
    }
}
