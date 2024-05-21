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


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(environment, new Vector3(0, 0, 0), environment.transform.rotation) ;

        // Génération aléatoire des fleurs et de l'herbe
        ForestSpawner.generate(flower, "Flowers", 20,
                                10, 30, 10, 30,
                                1.7f, 2.3f, 10);
        ForestSpawner.generate(grass, "Grass", 200,
                                -50, 50, -50, 50,
                                0.7f, 1.3f, 10);

        // Génération des escargots alliés et ennemis
        GameObject[] allies = ForestSpawner.generate(basicSnail2, "Allies", m_nbAllies, -10, 10, -10, 10);
        GameObject[] ennemies = new GameObject[2*m_nbEnnemy];

        GameObject[] tempEnnemies1 = ForestSpawner.generate(ennemy, "Ennemies", m_nbEnnemy, 30, 50, 30, 50);
        GameObject[] tempEnnemies2 = ForestSpawner.generate(ennemy, "Ennemies", m_nbEnnemy, -50, -30, -50, -30);
        for (int i = 0 ; i < m_nbEnnemy ; i++)
        {
            ennemies[2*i] = tempEnnemies1[i];
            ennemies[2*i+1] = tempEnnemies2[i];
        }
        SnailsManager.setAllies(allies);
        SnailsManager.setEnnemies(ennemies);
    }
}
