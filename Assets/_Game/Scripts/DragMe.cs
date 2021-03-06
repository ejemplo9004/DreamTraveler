using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DragMe : MonoBehaviour
{
    public static DragMe drgActivo;

    bool canMove;
    bool dragging;
    Collider2D collider;

    public UnityEvent iniciaDrag;
    public UnityEvent draggeando;
    public UnityEvent terminaDrag;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (collider == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            if (canMove)
            {
                dragging = true;
                iniciaDrag.Invoke();
                drgActivo = this;
            }


        }
        if (dragging && drgActivo == this)
        {
            this.transform.position = mousePos;
            draggeando.Invoke();
        }
        if (Input.GetMouseButtonUp(0) && dragging)
        {
            canMove = false;
            dragging = false;
            terminaDrag.Invoke();
        }
    }
}