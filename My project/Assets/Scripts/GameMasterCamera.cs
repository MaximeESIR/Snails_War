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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int boolToInt(bool b) { return b == true ? 1 : 0; }

    // Update is called once per frame
    void Update()
    {
        // Déplacement devant derrière (touches 5 et 0)
        currentSpeed += speed * (
        boolToInt(Input.GetKeyDown(KeyCode.Keypad5))
        - boolToInt(Input.GetKeyUp(KeyCode.Keypad5))
        - boolToInt(Input.GetKeyDown(KeyCode.Keypad0))
        + boolToInt(Input.GetKeyUp(KeyCode.Keypad0)));
        transform.Translate(Vector3.forward*currentSpeed*Time.deltaTime);

        // Déplacement côtés (touches 1 et 3)
        currentSideSpeed += speed * (
        boolToInt(Input.GetKeyDown(KeyCode.Keypad1))
        - boolToInt(Input.GetKeyUp(KeyCode.Keypad1))
        - boolToInt(Input.GetKeyDown(KeyCode.Keypad3))
        + boolToInt(Input.GetKeyUp(KeyCode.Keypad3)));
        transform.Translate(Vector3.left*currentSideSpeed*Time.deltaTime);

        // Déplacement haut/bas (touche - et +)
        currentHeightSpeed += speed * (
        boolToInt(Input.GetKeyDown(KeyCode.KeypadMinus))
        - boolToInt(Input.GetKeyUp(KeyCode.KeypadMinus))
        - boolToInt(Input.GetKeyDown(KeyCode.KeypadPlus))
        + boolToInt(Input.GetKeyUp(KeyCode.KeypadPlus)));
        transform.Translate(Vector3.up*currentHeightSpeed*Time.deltaTime);

        // Rotations gauche/droite (touche 4 et 6)
        currentSideTurnSpeed += turnSpeed * (
        boolToInt(Input.GetKeyDown(KeyCode.Keypad4))
        - boolToInt(Input.GetKeyUp(KeyCode.Keypad4))
        - boolToInt(Input.GetKeyDown(KeyCode.Keypad6))
        + boolToInt(Input.GetKeyUp(KeyCode.Keypad6)));
        transform.Rotate(Vector3.up, -currentSideTurnSpeed*Time.deltaTime);

        // Rotations haut/bas (touche 8 et 2)
        currentHeightTurnSpeed += turnSpeed * (
        boolToInt(Input.GetKeyDown(KeyCode.Keypad8))
        - boolToInt(Input.GetKeyUp(KeyCode.Keypad8))
        - boolToInt(Input.GetKeyDown(KeyCode.Keypad2))
        + boolToInt(Input.GetKeyUp(KeyCode.Keypad2)));
        transform.Rotate(Vector3.right, -currentHeightTurnSpeed*Time.deltaTime);
    }
}
