using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class annonceur : MonoBehaviour
{
    private float currentProgression=0.0f;
    private float maxProgression=100f;
    public Image barProgress;



    // Start is called before the first frame update
    void Start()
    {
        barProgress.fillAmount=currentProgression/maxProgression;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.K)){
                Capture();
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
