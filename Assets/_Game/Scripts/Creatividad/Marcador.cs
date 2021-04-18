using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marcador : MonoBehaviour
{
    public GameObject tinta;
    public float distancia;
    Vector2 posAnterior;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButton(0) || Input.touchCount >0)
		{
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if((posAnterior - hit.point).magnitude > distancia)
			    {
                    Instantiate(tinta, hit.point, Quaternion.identity);
                    posAnterior = hit.point;
                }
            }
		}

    }
}
