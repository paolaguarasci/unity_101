using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
     * INTELLIGENZA NEMICA
     * Questo funziona in 4 fasi e usa il RayCast (SphereCast)
     * 
     * 1. si muove di un po in avanti
     * 2. controllo con il raycast la presenza di un ostacolo
     * 3. mi giro in un altra direzione
     * 4. fine del loop, ritorno al punto 1
     *
     * Di solito il RayCast parte dal centro della camera
     * questa volta creiamo un raycast che parte dal nemico,
     * dalla z del nemico per la precisione
     *
     * Facciamo partire una Sfera, inceve che un punto,
     * SphereCast() invece che RayCast(),
     * per prendere in considerazione anche le dimensioni del nemico
     * Il RayCast si usa con "proiettili" che solitamente hanno dimensioni
     * trascurabili.
     *
     * 
     */

public class WonderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    private bool _alive;

    private void Start() {
        _alive = true;
    }

    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            // il raggio parte dalla posizione dell'oggetto e punta in avanti (relativo all'oggetto)
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void setAlive(bool alive)
    {
        _alive = alive;
    }
}
