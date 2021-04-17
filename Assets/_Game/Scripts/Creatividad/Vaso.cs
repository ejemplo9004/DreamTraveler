using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaso : MonoBehaviour
{
    public bool lleno;
    public Animator animator;
    public float pArriba;
    public float pAbajo;
    public bool arriba = false;
    public float px;
    public bool volteado;

    public static Vaso vasoActivo;

    float pActual;
    float pXActual;
    void Start()
    {
        pActual = pAbajo;
        pXActual = (float)(Mathf.RoundToInt(transform.position.x));
        px = pXActual;
    }

    // Update is called once per frame
    void Update()
    {
        pActual = Mathf.Lerp(pActual, (arriba ? pArriba : pAbajo), Time.deltaTime*5);
        pXActual = Mathf.Lerp(pXActual, px, Time.deltaTime*5);
        transform.position = new Vector3(pXActual, pActual, 0);
    }

	private void OnMouseDown()
	{
		if (!ControlVasos.singleton.inicioMovimiento)
		{
            vasoActivo = this;
            ControlVasos.singleton.posicionX = Mathf.RoundToInt(px);
            ControlVasos.singleton.tSeleccion.position = new Vector3(transform.position.x, ControlVasos.singleton.tSeleccion.position.y, 0);
            ControlVasos.singleton.posVasoSeleccionado = Mathf.RoundToInt(px);
        }

    }

	public void Subir()
	{
        arriba = true;
	}

    public void Bajar()
	{
        arriba = false;
	}

    public void Izquierda()
    {
        px --;
    }
    public void Derecha()
    {
        px++;
    }
    public void Voltear()
    {
        if (!volteado)
        {
            animator.SetTrigger("activar");
            volteado = true;
            lleno = false;
        }
    }
    public void Enderezar()
    {
        if (volteado)
        {
            animator.SetTrigger("activar");
            volteado = false;
        }
    }

}
