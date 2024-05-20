using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterCamera : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 80;
    private float currentSpeed = 0f;
    private float currentSideSpeed = 0f;
    private float currentHeightSpeed = 0f;
    private float currentSideTurnSpeed = 0f;
    private float currentHeightTurnSpeed = 0f;

    private bool followSnail = false;
    public GameObject snail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int boolToInt(bool b) { return b == true ? 1 : 0; }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && snail != null)
        {
            followSnail = !followSnail;
        }
        if(followSnail)
        {
            transform.position = snail.transform.position + 2*Vector3.up;
        }
        else {
            /*// Déplacement devant derrière (touches 5 et 0)
            currentSpeed += speed * (
            boolToInt(Input.GetKeyDown(KeyCode.Keypad5))
            - boolToInt(Input.GetKeyUp(KeyCode.Keypad5))
            - boolToInt(Input.GetKeyDown(KeyCode.Keypad0))
            + boolToInt(Input.GetKeyUp(KeyCode.Keypad0)));
            transform.Translate(Vector3.right*currentSpeed*Time.deltaTime);
*/
            // Déplacement côtés (touches 1 et 3)
            currentSideSpeed += speed * (
            boolToInt(Input.GetKeyDown(KeyCode.Keypad1))
            - boolToInt(Input.GetKeyUp(KeyCode.Keypad1))
            - boolToInt(Input.GetKeyDown(KeyCode.Keypad3))
            + boolToInt(Input.GetKeyUp(KeyCode.Keypad3)));
            transform.Translate(Vector3.left*currentSideSpeed*Time.deltaTime);

            // Déplacement haut/bas (touche 5 et 2)
            currentHeightSpeed += speed * (
            boolToInt(Input.GetKeyDown(KeyCode.Keypad5))
            - boolToInt(Input.GetKeyUp(KeyCode.Keypad5))
            - boolToInt(Input.GetKeyDown(KeyCode.Keypad2))
            + boolToInt(Input.GetKeyUp(KeyCode.Keypad2)));
            transform.Translate(Vector3.up*currentHeightSpeed*Time.deltaTime);

        }

            // Rotations gauche/droite (touche 4 et 6)
            currentSideTurnSpeed += turnSpeed * (
            boolToInt(Input.GetKeyDown(KeyCode.Keypad4))
            - boolToInt(Input.GetKeyUp(KeyCode.Keypad4))
            - boolToInt(Input.GetKeyDown(KeyCode.Keypad6))
            + boolToInt(Input.GetKeyUp(KeyCode.Keypad6)));
            transform.Rotate(Vector3.up, -currentSideTurnSpeed*Time.deltaTime);

            // Rotations haut/bas (touche 7 et 9)
            currentHeightTurnSpeed += turnSpeed * (
            boolToInt(Input.GetKeyDown(KeyCode.Keypad7))
            - boolToInt(Input.GetKeyUp(KeyCode.Keypad7))
            - boolToInt(Input.GetKeyDown(KeyCode.Keypad9))
            + boolToInt(Input.GetKeyUp(KeyCode.Keypad9)));
            transform.Rotate(Vector3.right, -currentHeightTurnSpeed*Time.deltaTime);

    }
}