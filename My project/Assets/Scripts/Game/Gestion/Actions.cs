using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public GameObject scene;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //On désactive la scéne
         if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Active l'objet stocké s'il existe
            if (scene != null)
            {
                scene.SetActive(false);
            }
            if (menu != null)
            {
                menu.SetActive(true);
            }
        }
    }
}
