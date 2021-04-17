using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesSelector : MonoBehaviour
{
    Collider2D collider;
    void Start()
    {
        collider = GetComponent<Collider2D>();

    }
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            print(Physics2D.OverlapPoint(mousePos));
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                Desseleccionar();
            }

        }
        
	}

    public void Desseleccionar()
	{
        DragMe.drgActivo = null;
    }
}
