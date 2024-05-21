using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTestScene : MonoBehaviour
{
    public GameObject environment;
    public GameObject basicSnail2;
    public GameObject ennemy;
    public GameObject scene;
    public GameObject flower;
    public GameObject grass;
    private int m_nbAllies=25;
    private int m_nbEnnemy=20;

    private static GameObject[] ennemies;
    private static GameObject[] allies;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(environment, new Vector3(0, 0, 0), environment.transform.rotation) ;

        // Génération aléatoire des fleurs et de l'herbe
        ForestSpawner.generate(flower, "Flowers", 30,
                                10, 30, 10, 30,
                                1.7f, 2.3f, 10);
        ForestSpawner.generate(grass, "Grass", 200,
                                -50, 50, -50, 50,
                                0.7f, 1.3f, 10);

        // Génération des escargots alliés et ennemis
        allies = ForestSpawner.generate(basicSnail2, "Allies", m_nbAllies, -10, 10, -10, 10);
        ennemies = new GameObject[2*m_nbEnnemy];

        GameObject[] tempEnnemies1 = ForestSpawner.generate(ennemy, "Ennemies", m_nbEnnemy, 30, 50, 30, 50);
        GameObject[] tempEnnemies2 = ForestSpawner.generate(ennemy, "Ennemies", m_nbEnnemy, -50, -30, -50, -30);
        for (int i = 0 ; i < m_nbEnnemy ; i++)
        {
            ennemies[2*i] = tempEnnemies1[i];
            ennemies[2*i+1] = tempEnnemies2[i];
        }

    }

    public static GameObject getEnnemy(int i)
    {
        if(i >= 0 && i < ennemies.Length)
            return ennemies[i];
        return null;
    }

    // Obtenir l'escargot situé le plus proche dans le camp ennemi
    public static GameObject getNearestEnnemy(GameObject snail, float maxDist)
    {
        GameObject[] tab;
        if(snail.tag == "Snail")
            tab = ennemies;
        else
            tab = allies;

        GameObject ret = null;
        float d = maxDist;
        foreach (GameObject e in tab)
        {
            if(e == null) continue;
            float d2 = Vector3.Distance(snail.transform.position,
                                        e.transform.position);
            if(d2 < d)
            {
                d = d2;
                ret = e;
            }
        }
        return ret;
    }

    public static GameObject getNearestAlly(GameObject snail, float maxDist)
    {
        GameObject[] tab;
        if(snail.tag == "Snail")
            tab = allies;
        else
            tab = ennemies;

        GameObject ret = null;
        float d = maxDist;
        foreach (GameObject e in tab)
        {
            if(e == null || e == snail) continue;
            float d2 = Vector3.Distance(snail.transform.position,
                                        e.transform.position);
            if(d2 < d)
            {
                d = d2;
                ret = e;
            }
        }
        return ret;
    }
}
