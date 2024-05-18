using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private GameObject m_selectedSnail;
    public bool is_SnailSelected=false;

    // Update is called once per frame
    void Update()
    {
        // Détection d'un clic gauche souris
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left-click.");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Récupère toutes les informations sur la collision du rayon
            RaycastHit hit;

            // Dans le cas d'une collision
            if (Physics.Raycast(ray, out hit, 100)) {
                Debug.Log (hit.point);
                GameObject gObj = hit.collider.gameObject;
                // Si l'on sélectionne un escargot
                if (gObj.tag == "Snail")
                {
                    Debug.Log("c'est un snail, Youpi !!!");
                    m_selectedSnail = gObj;
                    is_SnailSelected=true;
                }
                // Si un escargot à été sélectionné précédemment
                else if (m_selectedSnail != null)
                {
                    m_selectedSnail.GetComponent<Snail>().newTarget(hit.point);
                    m_selectedSnail = null;
                    is_SnailSelected=false;
                }
            }
        }
    }
}
