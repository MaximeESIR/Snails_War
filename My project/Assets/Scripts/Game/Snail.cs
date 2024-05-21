using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
//Structure Etat de l'escargot, peut servir de machine à état..
public enum SnailState{
    inactif, //Il n'est pas contraint de se diriger vers une position X
    hasToMove //Obligation pour l'escargot d'avancer jusqu'à une certaine position
}

public class Snail : MonoBehaviour
{
    private int Hp=1000; //La vie de l'escargot 
    public GameObject deadPrefab; //La coquille quand on meurt
    public Material targetMaterial;
    public SnailState state=SnailState.inactif; //Au départ il est inactif
    public UnityEngine.Vector3 m_target;
    public UnityEngine.Vector3 m_newTarget; //Zone à atteindre
    public float speed=2f;
    //hp : 
 

    void Start()
    {
        // L'escargot obient le tag "Snail" qui lui permet d'être
        // Reconnu par d'autres scripts
        gameObject.tag  = "Snail";
        targetMaterial.color = Color.white;  
    }

    // Update is called once per frame
    void Update()
    {
                //il faurait ajouter un etat où si l'escargot est coincé il tente de se décoincer
        if(state==SnailState.hasToMove){
            //Deplacement de l'escargot dans la direction de la targer
            transform.position=UnityEngine.Vector3.MoveTowards(transform.position,m_newTarget,speed*Time.deltaTime);
       
            UnityEngine.Vector3 direction=m_newTarget-transform.position;
            direction.y=0; //sinon ca va pas être beau à voir! 
            UnityEngine.Quaternion rotation=UnityEngine.Quaternion.LookRotation(direction);//Utilisation d'un quaternion pour l'interpolation
            transform.rotation=UnityEngine.Quaternion.Lerp(transform.rotation,rotation,2f*Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, m_newTarget) < 0.1){
            state=SnailState.inactif;
        }
        if(state==SnailState.inactif){
            //Faire un  truc pour qu'il bouge tout seul
        }




    }

    // Fonction appelée depuis MouseController.cs pour mettre à jour la target de l'escargot
    public void newTarget(UnityEngine.Vector3 t)
    {
        //m_target = t;
        m_newTarget=t;  //Nouvelle cible
        state=SnailState.hasToMove; //L'escargot se met en mouvement
    }

    public void takeDamage(int attack){
        Hp-=attack;
        Color n=new Color(1/2000f, 1/2000f, 1/2000f);
        targetMaterial.color = targetMaterial.color -attack*n;

        if(Hp<=0){
            Destroy(gameObject);
            Instantiate(deadPrefab, transform.position, transform.rotation);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
            Debug.Log(Hp);
;        }

    }

    

}
