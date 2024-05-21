using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTestScene : MonoBehaviour
{
    public GameObject environment;
    public GameObject basicSnail;
    public GameObject basicSnail2;
    public GameObject ennemy;
    public GameObject scene;
    public GameObject flower;
    public GameObject grass;
    public int m_nbAllies=5;
    public int m_nbEnnemy=20;

    private static GameObject[] ennemies;
    private static GameObject[] allies;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(environment, new Vector3(0, 0, 0), environment.transform.rotation) ;
//        Instantiate(basicSnail, new Vector3(0, 0, 0), basicSnail.transform.rotation) ;
//        Instantiate(basicSnail2, new Vector3(0, 0, 1), basicSnail.transform.rotation) ;

        ForestSpawner.generate(flower, "Flowers", 50,
                                10, 30, 10, 30,
                                0.7f, 1.3f, 10);

        ForestSpawner.generate(grass, "Grass", 200,
                                -50, 50, -50, 50,
                                0.7f, 1.3f, 10);


        allies = ForestSpawner.generate(basicSnail2, "Allies", m_nbAllies, -10, 10, -10, 10);
        ennemies = ForestSpawner.generate(ennemy, "Ennemies", m_nbEnnemy, -50, 50, -50, 50);


    }

    public static GameObject getEnnemy(int i)
    {
        if(i >= 0 && i < ennemies.Length)
            return ennemies[i];
        return null;
    }

    public static GameObject getClosestEnnemyfrom(Vector3 v)
    {
        GameObject ret = null;
        float d = 10000000;
        foreach (GameObject e in ennemies)
        {
            if(e == null) continue;
            float d2 = Vector3.Distance(v, e.transform.position);
            if(d2 < d)
            {
                d = d2;
                ret = e;
            }
        }
        return ret;
    }

        public static GameObject getClosestAllyfrom(Vector3 v)
    {
        GameObject ret = null;
        float d = 10000000;
        foreach (GameObject e in allies)
        {
            if(e == null) continue;
            float d2 = Vector3.Distance(v, e.transform.position);
            if(d2 < d)
            {
                d = d2;
                ret = e;
            }
        }
        return ret;
    }
}
