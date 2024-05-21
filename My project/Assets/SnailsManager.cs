using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailsManager : MonoBehaviour
{
    private static GameObject[] m_ennemies;
    private static GameObject[] m_allies;

    public static void setEnnemies(GameObject[] ennemies) {m_ennemies = ennemies;}
    public static void setAllies(GameObject[] allies) {m_allies = allies;}


    public static GameObject[] getEnnemies() {return m_ennemies; }
    public static GameObject[] getAllies() {return m_allies; }

    // Obtenir l'escargot situé le plus proche dans le camp ennemi
    public static GameObject getNearestEnnemy(GameObject snail, float maxDist)
    {
        if(m_ennemies == null) return null;
        GameObject[] tab;
        if(snail.tag == "Snail")
            tab = m_ennemies;
        else
            tab = m_allies;

        GameObject ret = null;
        float d = maxDist;
        foreach (GameObject e in tab)
        {
            if(e == null) continue;
            float d2 = Vector3.Distance(snail.transform.position,
                                        e.transform.position);
            if(d2 < d)
            {
                d = d2;
                ret = e;
            }
        }
        return ret;
    }

    public static GameObject getNearestAlly(GameObject snail, float maxDist)
    {
        if(m_allies == null) return null;
        GameObject[] tab;
        if(snail.tag == "Snail")
            tab = m_allies;
        else
            tab = m_ennemies;

        GameObject ret = null;
        float d = maxDist;
        foreach (GameObject e in tab)
        {
            if(e == null || e == snail) continue;
            float d2 = Vector3.Distance(snail.transform.position,
                                        e.transform.position);
            if(d2 < d)
            {
                d = d2;
                ret = e;
            }
        }
        return ret;
    }
}

