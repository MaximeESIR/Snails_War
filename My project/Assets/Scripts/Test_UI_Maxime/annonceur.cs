using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;

//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class annonceur : MonoBehaviour
{
    //CAPTURE de points
    private float currentProgression=0.0f;
    private float maxProgression=100f;
    public Image barProgress;
    //les endroits pour écrire
    public TextMeshProUGUI quete;
    public TextMeshProUGUI conseils;
    public TextMeshProUGUI quete_grande;
    //Actuellement dans une quête?
    public bool currently_in_quest=false;
    //La liste des quêtes dans le tuto
    public List<string> quest_list= new List<string>();
    
    public int index_quest=0;
    public bool can_skip;
    //Script mouvement
    public movement movementScript;//Savoir si on a une collision avec le bon tag
    public MouseController mouseScript;




    // Start is called before the first frame update
    void Start()
    {
        quest_list.Add("mouvements1");//Mouvement cam
        quest_list.Add("select_escargot");//select escargot
        quest_list.Add("mouvement2");//move un escargot
        can_skip=true;
        //On initialise la barre à 0
        barProgress.fillAmount=currentProgression/maxProgression;

        //movementScript=GetComponent<movement>();
        //On initialise la quête:
        quete_grande.text="Bonjour, jeune coquille! Souviens toi: 4:left ; 6:right ; 5:forward, 2: bottom,8:up";
        conseils.text="enter";
    }
    void Update(){
        //Test capture point
        if(Input.GetKeyDown(KeyCode.K)){
                Capture();
        }

        if(currently_in_quest){
           // bool is_CoquillePoint=movementScript.is_CoquillePoint;
            //if(is_CoquillePoint==true){
              //  movementScript.is_CoquillePoint=false;
            if(quest_list[index_quest]=="select_escargot" && mouseScript.is_SnailSelected){
                quete_grande.text="Vous avez selectionné un escargot. Cliquez quelque part! ";
                conseils.text="";
                can_skip=false;
                index_quest+=1;
            }
            if(quest_list[index_quest]=="mouvement2" && !mouseScript.is_SnailSelected){
                quete_grande.text="Oh, l'escargot bouge! lentement... mais il bouge! C'est tout pour le moment jeune coquille. Reviens me voir à la prochaine update: click sur echap";
                conseils.text="";
                can_skip=false;
                index_quest+=1;
            }
        
        }
        else{

        }
        if(can_skip){
            
            if(Input.GetKeyDown(KeyCode.KeypadEnter)){
                can_skip=false;
                conseils.text="";
                if(quest_list[index_quest]=="mouvements1"){
                    quete_grande.text=" Tu as compris comment bouger, bien. Maintenant, fais un click gauche sur l'escargot devant toi";
                    can_skip=false;
                    index_quest+=1;
                    currently_in_quest=true;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
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
