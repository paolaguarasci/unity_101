using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    };

    // Le variabili pubbliche possono essere editate dall'editor (Inspector)
    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivyHor = 9.0f;
    public float sensitivyVer = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0f;

    private void Start()
    {
        // evita che la rotazione del mouse sia controllata dal motore fisico del gioco

        // controllo che effettivamente gli sia stato appioppato la simulazione "Corpo rigido"
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            // se la simulazione esiste, ferma il controllo della rotazione
            body.freezeRotation = true;
        }
    }

    private void Update()
    {
        if (axes == RotationAxes.MouseX) {
            // horizontal rotation here
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivyHor, 0);
        }
        else if (axes == RotationAxes.MouseY) {
            // vertical rotation here
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivyVer;
            // maths.clamp() setta i limiti
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

            //transform.Rotate(_rotationX,0, 0);
        }
        else {
            // both horizontal and vertical rotations here
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivyVer;
            // maths.clamp() setta i limiti
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivyHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

            //transform.Rotate(_rotationX,0, 0);
        }

    
    }
}
