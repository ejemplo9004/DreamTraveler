using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maleta : MonoBehaviour
{
    public DragMe drag;
    public Movedor movedor;
    public Palabra palabra;
    public Text txtPalabra;

	PersonajeMaletas pm;

	Vector3 posicionInicial;
	float tInicial;

	public void Inicializar(Palabra p)
	{
        palabra = p;
        txtPalabra.text = p.palabra;

	}

    public void Desactivar()
	{
        drag.enabled = false;
        movedor.enabled = false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Cinta"))
		{
			if (!movedor.activo)
			{
                movedor.activo = true;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Cinta"))
		{
			movedor.activo = false;
		}
		else if (collision.CompareTag("Personaje"))
		{
			pm = null;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Destructor")
		{
			CreadorMaletas.singleton.DevolverMaleta(palabra);
			Destroy(gameObject);
		}
	}

	public void IniciarDrag()
	{
		posicionInicial = transform.position;
		tInicial = Time.time;
	}

	public void TerminarDrag()
	{
		if (pm == null)
		{
			RestablecerPosicion();
		}
		else
		{
			if (pm.tipo == palabra.tipo)
			{
				pm.Devolver();
			}
			else
			{
				RestablecerPosicion();
			}
		}

		void RestablecerPosicion()
		{
			transform.position = posicionInicial + movedor.velocidad * (Time.time - tInicial);
		}
	}
}

[System.Serializable]
public class Palabra
{
    public string palabra;
    public TipoPalabra tipo;
}
public enum TipoPalabra
{
    sustantivo,
    vervo,
    pronombre,
    articulo
}
