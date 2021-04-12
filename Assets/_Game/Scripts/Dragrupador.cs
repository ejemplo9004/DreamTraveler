using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragrupador : MonoBehaviour
{
    Vector3 posInicial;
    public int bando;
    public Dragrupador dragrupador;
	public bool desaparecer;
	public bool borrar;
	public float distanciaObjetivo = 2;
    void Start()
    {
        posInicial = transform.position;
		transform.localScale = Vector3.zero;
		LeanTween.scale(gameObject, Vector3.one, 0.2f);
	}

	public void VerificarDrag()
	{

		if (dragrupador != null && dragrupador.bando == bando)
		{
			float distancia = (transform.position - dragrupador.transform.position).magnitude;
			if (distancia < distanciaObjetivo)
			{
				print("correcto");
				Desaparecer();
				dragrupador.Desaparecer();
				if (ControlGenerico.singleton != null)
				{
					ControlGenerico.singleton.SumarPuntos(1);
				}
			}
			else
			{
				print(distancia);
				transform.position = posInicial;
			}
		}
		else
		{
			print("incorre");
			transform.position = posInicial;
		}
	}

	public void Desaparecer()
	{
		if (desaparecer)
		{
			LeanTween.scale(gameObject, Vector3.zero, 0.2f);
		}
		if (borrar)
		{
			Destroy(gameObject, 0.3f);
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
        Dragrupador dgp = collision.transform.GetComponent<Dragrupador>();
		if (dgp != null)
		{
            dragrupador = dgp;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		dragrupador = null;
	}
}
