using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InitTestScene;

public enum State{
    WAIT,   // Attend un ordre
    OBEY,   // Obéit à un ordre
    AUTO,   // Prend des décisions tout seul
    FIGHT,  // Combat un ennemi
    DEAD    // Est mort
}

public class Snail_2 : MonoBehaviour
{
    public GameObject m_deadPrefab; //La coquille quand on meurt
    public State m_state = State.AUTO; //Au départ agit tout seul
    public float speed=2f;

    private GameObject m_EnnemyTarget = null;
    public UnityEngine.Vector3 m_target; // Position que l'escargot doit atteindre
    public float m_timeBeforeNextDecision;
    public int m_hp = 1000;
    private float visionRadius = 20f;


    private State m_forLogState = State.WAIT;

    // Start is called before the first frame update
    void Start()
    {
        m_timeBeforeNextDecision = Random.Range(0.5f, 2);
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_state)
        {
            case State.OBEY:
            obeyOrder();
            break;
            case State.WAIT:
            wait();
            break;
            case State.AUTO:
            actAuto();
            break;
            case State.FIGHT:
            fight();
            break;
            case State.DEAD:
            die();
            break;
        }
        m_timeBeforeNextDecision -= Time.deltaTime;
        logState();
    }

    // Cette méthode pourra varier suivant le type d'escargot
    private void obeyOrder()
    {   
        followTarget();
        // L'escargot s'arrête lorsqu'il atteint la cible
        if(Vector3.Distance(transform.position, m_target) < 0.1){
            m_state=State.AUTO;
        }
    }
    private void wait()
    {
        if(m_timeBeforeNextDecision < 0)
            m_state = State.AUTO;
    }
    private void actAuto()
    {
        if(m_timeBeforeNextDecision < 0)
        {
            m_timeBeforeNextDecision = 2f;
            // Take a decision : target an ennemy or follow other snails
            GameObject nearestEnnemy = InitTestScene.getNearestEnnemy(gameObject, visionRadius);
            GameObject nearestAlly = InitTestScene.getNearestAlly(gameObject, visionRadius);
            if(nearestAlly == null)
            {
                if (nearestEnnemy == null)
                {
                    // Pas d'allié ni d'ennemi : on attend
                    m_state = State.WAIT;
                    return;
                }
                else
                {
                    // Fuit l'ennemi lorsqu'il est seul
                    m_target = 2*transform.position - nearestEnnemy.transform.position;
                }
            }
            else
            {
                if (nearestEnnemy == null)
                {
                    // Direction dans laquelle va chercher à aller l'escargot
                    Vector3 targetDirection;
                    float distAlly = Vector3.Distance(transform.position, nearestAlly.transform.position);

                    // S'écarte d'un allié trop proche
                    if(distAlly < 5)
                        m_target = (transform.position - nearestAlly.transform.position)/distAlly + transform.position;
                    
                    // Va dans la même direction qu'un allié pas trop éloigné
                    else if(distAlly < 2*visionRadius/3)
                    {
                        Vector3 allyDirection = (nearestAlly.transform.TransformDirection(Vector3.forward) - nearestAlly.transform.position);
                        m_target = allyDirection + transform.position;
                    }
                    // Se rapproche de l'allié s'il est loin
                    else
                        m_target = nearestAlly.transform.position;
                    
                }
                else
                {
                    // Attaque l'ennemi lorsqu'il est à plusieurs
                    m_target = - transform.position + 2*nearestEnnemy.transform.position;
                    Debug.Log("Ennemy non nul, target : "+m_target);
                }
            }
        }
        followTarget();
    }

    private void fight() {}
    private void die() {}

    // Rapproche l'escargot de sa cible (position ou ennemi)
    private void followTarget()
    {
        // Maj de la direction ciblée si la cible est un ennemi
        if(m_EnnemyTarget != null)
            m_target = m_EnnemyTarget.transform.position;
        // Rotation de l'escargot
        UnityEngine.Vector3 direction=m_target-transform.position;
        direction.y=0;
        UnityEngine.Quaternion rotation=UnityEngine.Quaternion.LookRotation(direction);//Utilisation d'un quaternion pour l'interpolation

        transform.rotation=UnityEngine.Quaternion.RotateTowards(transform.rotation,rotation,80f*Time.deltaTime);

        //Deplacement de l'escargot
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    public void takeDamage(int damage)
    {
        m_hp -= damage;

        if(m_hp <= 0){
            Destroy(gameObject);
            Instantiate(m_deadPrefab, transform.position, transform.rotation);
            Debug.Log(m_hp);
        }
    }


    private void logState()
    {
        if(m_state == m_forLogState) return;

        Debug.Log("Nouvel état " + m_state);
        m_forLogState = m_state;
        if(m_EnnemyTarget != null)
            Debug.Log("target : " + m_EnnemyTarget.transform.name + ", position : " + m_target);
        else
            Debug.Log("target : " + m_target);
    }

    /////////////////////////////////////////////////////////
    // Fonctions appelées depuis MouseController.cs pour   //
    // mettre à jour la target de l'escargot               //
    /////////////////////////////////////////////////////////
    
    public void makeWait()
    {
        m_state = State.WAIT;
        m_timeBeforeNextDecision = 5;
    }

    public void newTarget(Vector3 t)
    {
        m_EnnemyTarget = null;
        m_target=t;  //Nouvelle cible
        m_state=State.OBEY; //L'escargot se met en mouvement
    }
        public void newTarget(GameObject ennemy)
    {
        m_EnnemyTarget = ennemy;  //Nouvelle cible
        m_state=State.OBEY; //L'escargot se met en mouvement
    }
}
