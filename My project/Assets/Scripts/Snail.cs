using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public Vector3 m_target;
    public Vector3 m_newTarget;
    // Start is called before the first frame update
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
        if(m_target != null)
        {
            transform.position = m_target;
        }
    }

    // Fonction appelée depuis MouseController pour mettre à jour la target de l'escargot
    public void newTarget(Vector3 t)
    {
        m_target = t;
    }

    private void setTarget()
    {
        // TODO : Prise de décision de l'escargot
    }
}
