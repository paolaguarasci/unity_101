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
            if (Physics.Raycast(ray, out hit)) {
                RespondToHit enemy = hit.transform.GetComponent<RespondToHit>();
                if (enemy != null)
                {
                    Debug.Log("Hit nemico!");
                }
            }
        }
        
    }
}
