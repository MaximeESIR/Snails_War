using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSpawner : MonoBehaviour
{
    
    public static GameObject[] generate(
    GameObject prefab,
    string groupName,
    int nb,
    float xMin, float xMax, float zMin, float zMax)
    {
        return generate(prefab, groupName, nb, xMin, xMax, zMin, zMax, 1, 1, 0);
    }


    public static GameObject[] generate(
    GameObject prefab,
    string groupName,
    int nb,
    float xMin, float xMax, float zMin, float zMax,
    float minScale, float maxScale,
    float inclinaisonMax)
    {
        // Crée un game object qui contiendra toute les instances générées
        GameObject forest = new GameObject(groupName);
        GameObject[] elements = new GameObject[nb];
        for (int i = 0 ; i < nb ; i++)
        {
            // Tirer une position aléatoire
            float posX = Random.Range(xMin, xMax);
            float posZ = Random.Range(zMin, zMax);
            // Tirer une taille aléatoire
            // Créer une copie avec la position et l'orientation voulue
            GameObject myTree = Instantiate(prefab, new Vector3(posX, 0, posZ), prefab.transform.rotation) ;
            
            // Modifier les rotations de l'objet pour plus de diversité
            float rotationX = Random.Range(-inclinaisonMax, inclinaisonMax);
            myTree.transform.Rotate(Vector3.forward, rotationX);
            float rotationY = Random.Range(-inclinaisonMax, inclinaisonMax);
            myTree.transform.Rotate(Vector3.right, rotationY);
            float rotationZ = Random.Range(0f, 360f);
            myTree.transform.Rotate(Vector3.up, rotationZ);

            // Change le scale de l'objet
            myTree.transform.localScale = new Vector3(1, 1, 1) * Random.Range(minScale, maxScale);

            // Rattache l'objet instancié à l'objet parent
            myTree.transform.SetParent(forest.transform);

            // Ajout de l'objet au tableau
            elements[i] = myTree;
        }

        return elements;
    }
}
