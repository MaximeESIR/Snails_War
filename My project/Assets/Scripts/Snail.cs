using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;

//Structure Etat de l'escargot, peut servir de machine à état..
public enum SnailState{
    inactif, //Il n'est pas contraint de se diriger vers une position X
    hasToMove //Obligation pour l'escargot d'avancer jusqu'à une certaine position
}

public class Snail : MonoBehaviour
{
    public SnailState state=SnailState.inactif; //Au départ il est inactif
    public UnityEngine.Vector3 m_target;
    public UnityEngine.Vector3 m_newTarget; //Zone à atteindre
    public float speed=2f;

    void Start()
    {
        // L'escargot obient le tag "Snail" qui lui permet d'être
        // Reconnu par d'autres scripts
        gameObject.tag  = "Snail";
        // L'escargot prend des décisions à intervalle régulier quand
        // il n'a pas de directive précise (pas encore finit)
        InvokeRepeating("setTarget", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO : Déplacement de l'escargot et actions en fonction des
        // directives (faire un truc du style machine à états)
       /* if(m_target != null)
        {
            state=SnailState.mouvement;
            transform.position = m_target;
        }
        
        */
        //il faurait ajouter un etat où si l'escargot est coincé il tente de se décoincer
        if(state==SnailState.hasToMove){
            //Deplacement de l'escargot dans la direction de la targer
            transform.position=UnityEngine.Vector3.MoveTowards(transform.position,m_newTarget,speed*Time.deltaTime);
       
            UnityEngine.Vector3 direction=m_newTarget-transform.position;
            direction.y=0; //sinon ca va pas être beau à voir! 
            UnityEngine.Quaternion rotation=UnityEngine.Quaternion.LookRotation(direction);//Utilisation d'un quaternion pour l'interpolation
            transform.rotation=UnityEngine.Quaternion.Lerp(transform.rotation,rotation,2f*Time.deltaTime);

            
        }
        if(transform.position==m_newTarget){
            state=SnailState.inactif;
        }
        if(state==SnailState.inactif){
            //Faire un  truc pour qu'il bouge tout seul
        }




    }

    // Fonction appelée depuis MouseController pour mettre à jour la target de l'escargot
    public void newTarget(UnityEngine.Vector3 t)
    {
        //m_target = t;
        m_newTarget=t;  //Nouvelle cible
        state=SnailState.hasToMove; //L'escargot se met en mouvement
    }

    private void setTarget()
    {
        // TODO : Prise de décision de l'escargot
    }

    

}
