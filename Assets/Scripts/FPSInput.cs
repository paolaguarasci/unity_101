using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// se non c'e' il charactercontroller se lo prende da solo
[RequireComponent(typeof(CharacterController))]

// aggiunge questa voce di menu cosi da poter selezionarlo da "Add Component"
[AddComponentMenu("Control FPS Input")]


public class FPSInput : MonoBehaviour
{
    public float speed = 10.0f;

    private CharacterController _characterController;
    public float gravity = -9.8f;

    private void Start()
    {
        // accesso ad un componente attaccato allo stesso oggetto
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // limita la velocita diagonale dei movimenti, la fa diventare uguale a quella lungo gli assi
        movement = Vector3.ClampMagnitude(movement, speed);
        // evita il volo....
        movement.y = gravity;

        // Il delta Time serve ad ottenere un movimento indipendente dal framerate
        // Time.deltaTime scala la velocita' a seconda del framerate
        // a 30 FPS e' 1/30 per esempio...
        movement *= Time.deltaTime;

        // Trasforma il vettore movimento da locale a globale (coordinate)
        movement = transform.TransformDirection(movement);

        // dice al character controller di muoversi usando il vettore
        _characterController.Move(movement);
    } 
}
