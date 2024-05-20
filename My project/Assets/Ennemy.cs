using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Classe Ennemy. est attaché à un ennemy.

public class Ennemy : MonoBehaviour
{
    public GameObject deadEnemyPrefab; 
    private int Hp=300;
    //Position dont on va éviter de s'éloigner 
    private Vector3 startPosition;
    //Un truc temporaire qui permet de savoir où veut aller notre ami l'escargot
    private Vector3 whereToGo;
    //Ecart au départ max
    public float maxDistance=1005f;
    public float speed=1f;

    // Start is called before the first frame update
    void Start()
    {
        startPosition=transform.position;
        whereToGo=transform.position;
        whereToGo.y=0;
        maxDistance=1005f;
    }

    // Update is called once per frame
    void Update()
    {
        //En fait ca ca sert rarement. Si on donne la possibilité d aller plus loin que la distance max, quand il rentre dans sa zone il en resort, etc... et c'est totalement bug car il peut pas atteindre le whereTogo
        float distance = Vector3.Distance(transform.position, startPosition);
        if (distance > maxDistance)
        {
            Debug.Log("OUCHHHHHHHHHHHHHHHHHHHHHHHHHHHH "+(distance-maxDistance));
            //On bouge grâce à une interpollation classique
            transform.position=UnityEngine.Vector3.MoveTowards(transform.position,startPosition,1f*Time.deltaTime);
            // direction vers la position de départ
            Vector3 direction = (startPosition - transform.position).normalized;
            direction.y=0; //sinon ca va pas être beau à voir! 
            UnityEngine.Quaternion rotation=UnityEngine.Quaternion.LookRotation(direction);//Utilisation d'un quaternion pour l'interpolation
            transform.rotation=UnityEngine.Quaternion.Lerp(transform.rotation,rotation,2f*Time.deltaTime);

        }
        else
        {
            //Si on a atteint la cible temporaire on la change dans la zone autour dupoint de départ
            if(Vector3.Distance(transform.position,whereToGo)<1){
                Vector3 randomOffset = Random.insideUnitSphere * 5.9f;
                whereToGo=randomOffset+startPosition;
                whereToGo.y=0;
            }
            //On bouge grâce à une interpollation classique
            transform.position=UnityEngine.Vector3.MoveTowards(transform.position,whereToGo,1f*Time.deltaTime);
            // direction vers la position de départ
            Vector3 direction = (whereToGo - transform.position);
            direction.y=0; //sinon ca va pas être beau à voir! 
            UnityEngine.Quaternion rotation=UnityEngine.Quaternion.LookRotation(direction);//Utilisation d'un quaternion pour l'interpolation
            transform.rotation=UnityEngine.Quaternion.Lerp(transform.rotation,rotation,2f*Time.deltaTime);
            Debug.Log("Position actuelle : " + transform.position);
            Debug.Log("direction : " + direction);
            Debug.Log("Destination temporaire : " + whereToGo);
            Debug.Log("Distance à la destination : " + Vector3.Distance(transform.position, whereToGo));

        }
    }
//Fonciton permettant de retirer des pv à l'ennemy et de supprimer l'object s'il meurt
    public void takeDamage(int attack){
        Hp-=attack;
        if(Hp<=0){
            Destroy(gameObject);
            Instantiate(deadEnemyPrefab, transform.position, transform.rotation);
            Debug.Log(Hp);
;        }
    }
}
