using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMaletas : MonoBehaviour
{
    public Vector3 posicionInicial;
    public Vector3 posObjetivo;
    public float t;
    public float velocidad = 0.05f;
    public float periodo = 0.05f;
    public TipoPalabra tipo;

    public bool devolviendose;

	public Animator animPersonaje;

	private void Start()
	{
		StartCoroutine(Entrar());
	}

	IEnumerator Entrar()
	{
		animPersonaje.SetBool("caminando", true);
		while (!devolviendose && t < 1)
		{
            transform.position = Vector3.Lerp(posicionInicial, posObjetivo, t);
            t += velocidad;
            yield return new WaitForSeconds(periodo);
		}
		if(!devolviendose) animPersonaje.SetBool("caminando", false);
	}

	public void Devolver()
	{
		devolviendose = true;
		StartCoroutine(Volviendo());
	}

	IEnumerator Volviendo()
	{
		animPersonaje.SetBool("caminando", true);
		while ( t > 0)
		{
			transform.position = Vector3.Lerp(posicionInicial, posObjetivo, t);
			t -= velocidad;
			yield return new WaitForSeconds(periodo);
		}
		Destroy(gameObject);
	}

}
