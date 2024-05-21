using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Actions pour de l'activation de menu pauses
public class Actions : MonoBehaviour
{
    public GameObject scene;
    public GameObject menu;
    public GameObject options;
    public GameObject victory; //ecran victory
    public GameObject defeat; //ecran defaite
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
                options.SetActive(true);
                defeat.SetActive(false);
                victory.SetActive(false);
            }
        }
        //Si plus d'alliés menu defeat
        if(GameObject.Find("Allies").transform.childCount==0){
            menu.SetActive(true);
            options.SetActive(false);
            victory.SetActive(false);
            defeat.SetActive(true);
        }
        //Si plus d'ennemis menu victory
        if(GameObject.Find("Ennemies1").transform.childCount+GameObject.Find("Ennemies2").transform.childCount==0){ //Verif du nbre d'ennemis
            menu.SetActive(true);
            options.SetActive(false);
            defeat.SetActive(false);
            victory.SetActive(true);
        }
    }
    //Fonction retour au menu
    public void ReturnMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}
