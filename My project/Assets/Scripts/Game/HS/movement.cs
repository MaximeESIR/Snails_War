using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
// NON UTILLISE HS
public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20.0f;
    public float turnSpeed = 80;
    public float jumpForce = 10f; // Force de saut

    public bool auSol=true;
    public List<Material> materials;
    public Material mat_roues;

    //Devient true quand on rencontre un CoquillePoint;
    public bool is_CoquillePoint=false;


    void Start()
    {
       //var mesh = GetComponentsInChildren<MeshRenderer>().ToList();
       // mesh.ForEach(m => m.material = mat_ref);
    }

    // Update is called once per frame
    void Update()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");
        //transform.Translate(Vector3.forward * Time.deltaTime * deplacementVertical * speed);

        transform.Rotate(Vector3.up, Time.deltaTime * deplacementHorizontal * turnSpeed);
        if (auSol)
        {                     //this.transform.forward pour toi théo coucou, les prefabs sont mal aligné donc c est .right :)
            GetComponent<Rigidbody>().AddForce(this.transform.right * Time.deltaTime * deplacementVertical * speed, ForceMode.VelocityChange);
            Animation anim = GetComponent<Animation>();
            
            // Ajoutez une force vers le haut pour simuler le saut
            if (Input.GetKeyDown(KeyCode.Space)) 
                GetComponent<Rigidbody>().AddForce(this.transform.up * jumpForce, ForceMode.Impulse);
           //anim.Play("roues");
        }
/*        if (deplacementVertical<0)
        {
            GetComponentsInChildren<MeshRenderer>().ToList().ForEach(m => m.material = mat_red);
        }
        else if (deplacementVertical > 0)
        {
            GetComponentsInChildren<MeshRenderer>().ToList().ForEach(m => m.material = mat_blue);
        }*/
    }

    // Cette m�thode est appel�e lorsque le collider du personnage entre en collision avec un autre collider
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            auSol = true;
        }
  
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            auSol = false;
        }
        if (collision.gameObject.tag == "Coquille_Point")
        {
            Destroy(collision.gameObject);
            is_CoquillePoint=true;
        }
    }
    public void changerCOULEUR(Material material) {
        
        foreach(MeshRenderer m in GetComponentsInChildren<MeshRenderer>().ToList())
        {
            if (m.material.Equals(mat_roues))
                m.material = material;
        }
    }
}
