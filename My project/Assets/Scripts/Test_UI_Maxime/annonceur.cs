using System.Collections;
using System.Collections.Generic;
using TMPro;

//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class annonceur : MonoBehaviour
{
    private float currentProgression=0.0f;
    private float maxProgression=100f;
    public Image barProgress;
    //les endroits pour écrire
    public TextMeshProUGUI quete;
    public TextMeshProUGUI conseils;
    public TextMeshProUGUI quete_grande;
    //Actuellement dans une quête?
    public bool currently_in_quest=true;
    //La liste des quêtes dans le tuto
    public List<string> quest_list= new List<string>();
    
    public int index_quest=0;
    public bool can_skip;
    //Script mouvement
    public movement movementScript;




    // Start is called before the first frame update
    void Start()
    {
        quest_list.Add("intro");
        can_skip=false;
        //On initialise la barre à 0
        barProgress.fillAmount=currentProgression/maxProgression;

        //movementScript=GetComponent<movement>();
        //On initialise la quête:
        quete_grande.text="Bonjour, jeune coquille! Trouve la CoquillePoint pour débuter!";
        conseils.text="";
    }
    void Update(){
        //Test capture point
        if(Input.GetKeyDown(KeyCode.K)){
                Capture();
        }

        if(currently_in_quest){
            bool is_CoquillePoint=movementScript.is_CoquillePoint;
            if(is_CoquillePoint==true){
                movementScript.is_CoquillePoint=false;
                if(quest_list[index_quest]=="intro"){
                    quete_grande.text="vous avez trouvé la Coquille Point! génial. ";
                    conseils.text=" appuyez sur entrer";
                    can_skip=true;
                }
            }
        }
        else{

        }

        if(can_skip){
            
            if(Input.GetKeyDown(KeyCode.KeypadEnter)){
                can_skip=false;

                conseils.text="";
                if(quest_list[index_quest+1]=="intro"){
                    quete_grande.text=" Maintenant nous allons faire une quête";
                }
            }
        }
        
    }

void Capture(){
    currentProgression +=5f;
    updateProgression();

}

void updateProgression(){
 barProgress.fillAmount=currentProgression/maxProgression;
}

}
