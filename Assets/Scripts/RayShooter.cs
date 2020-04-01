using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        // blocco il cursore
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    
        {

            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;

            // ritorna un buleano... colpito?
            // out significa che e' un passaggio per riferimento
            if (Physics.Raycast(ray, out hit))
            {

                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                WonderingAI ai = hitObject.GetComponent<WonderingAI>();
               
                
                if (target != null && ai != null)
                {
                    ai.setAlive(false);
                    target.ReactToHit();
                    
                } else
                {


                // avvia una cooroutine per rispondere al colpo
                // Attenzione non avvia un nuovo Thread
                // non si tratta di calcolo parallelo ma concorrente
                // in unity fondamentalmente fa tutto il thread principale
                // le cooroutine simulano comportamenti asincroni
                StartCoroutine(SphereIndicator(hit.point));

                // un metodo messo qui con il metodo in pausa (yeald)
                // sarebbe eseguito
                }
            }
        }
        
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Cooroutine che usa la funzione IEnumerator
    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;


        // la keyword yeald dice alla cooroutine dove mettersi in pausa
        yield return new WaitForSeconds(1);

        // distrugge la sfera
        Destroy(sphere);
    } 
}
