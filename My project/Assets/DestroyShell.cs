using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShell : MonoBehaviour
{
    private float timeBeforeDeletion = 5;

    // Update is called once per frame
    void Update()
    {
        timeBeforeDeletion -= Time.deltaTime;
        if(timeBeforeDeletion <0)
            Destroy(gameObject);
    }
}
