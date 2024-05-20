using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour
{
    public GameObject[] prefabList;
    public new string name;
    public int nbTrees;
    public float xMin, xMax, zMin, zMax;
    public float minScale, maxScale;
    public float inclinaisonMax;

    

    // Start is called before the first frame update
    void Start()
    {
        // Crée un game object qui contiendra toute les instances générées
        GameObject forest = new GameObject(name);
        for (int i = 0 ; i < nbTrees ; i++)
        {
            // Tirer une position aléatoire
            float posX = Random.Range(xMin, xMax);
            float posZ = Random.Range(zMin, zMax);
            // Tirer une taille aléatoire
            // Tirer un prefab aléatoire parmi ceux disponibles
            GameObject randomTree = prefabList[Random.Range(0, prefabList.Length)];
            // Créer une copie avec la position et l'orientation voulue
            GameObject myTree = Instantiate(randomTree, new Vector3(posX, 0, posZ), randomTree.transform.rotation) ;
            
            // Modifier les rotations de l'objet pour plus de diversité
            float rotationX = Random.Range(-inclinaisonMax, inclinaisonMax);
            myTree.transform.Rotate(Vector3.forward, rotationX);
            float rotationY = Random.Range(-inclinaisonMax, inclinaisonMax);
            myTree.transform.Rotate(Vector3.right, rotationY);
            float rotationZ = Random.Range(0f, 360f);
            myTree.transform.Rotate(Vector3.up, rotationZ);

            // Change le scale de l'objet
            myTree.transform.localScale = new Vector3(1, 1, 1) * Random.Range(minScale, maxScale);

            // Rattache l'objet instancié à l'objet forest
            myTree.transform.SetParent(forest.transform);
        }
    }
}
