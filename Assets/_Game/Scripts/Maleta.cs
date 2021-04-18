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
		else if (collision.CompareTag("Personaje"))
		{
			pm = collision.gameObject.GetComponent<PersonajeMaletas>();
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
			Devolverla();
		}
	}

	void Devolverla()
	{
		CreadorMaletas.singleton.DevolverMaleta(palabra);
		Destroy(gameObject);
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
			if (pm.tipo == palabra.tipo && !pm.devolviendose)
			{
				/////////////////////////////////// Acertó
				pm.Devolver();
				ControlGenerico.singleton.SumarPuntos(1);
				Vicioso.singleton.SumarAcierto();
				Destroy(gameObject);
			}
			else
			{
				Vicioso.singleton.SumarError();
				RestablecerPosicion();
			}
		}

		void RestablecerPosicion()
		{
			print(gameObject.name);
			transform.position = posicionInicial + movedor.velocidad * (Time.time - tInicial);
		}

		if (transform.position.x < -30)
		{
			Devolverla();
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
	SUSTANTIVO,
	VERBO,
	ADJETIVO,
	PREPOSICIÓN,
	PRONOMBRE,
	NATURALEZA,
	FRUTAS,
	PARTES_DEL_CUERPO
}
