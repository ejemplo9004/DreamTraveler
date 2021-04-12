using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeMaletas : MonoBehaviour
{
    public Vector3 posicionInicial;
    public Vector3 posObjetivo;
    public float t;
    public float velocidad = 0.05f;
    public float periodo = 0.05f;
    public TipoPalabra tipo;
	public int cualEra;
	public Text txtPalabra;

    public bool devolviendose;

	public Animator animPersonaje;
	float tiempoIniciado;
	float tiempoRandom;
	public bool padreDelHijo;

	private void Start()
	{
		StartCoroutine(Entrar());
		txtPalabra.text = tipo.ToString().Replace('_', ' ');
		tiempoIniciado = Time.time;
		tiempoRandom = Random.Range(8f, 12f);
	}

	IEnumerator Entrar()
	{
		animPersonaje.SetBool("caminando", true);

		Vector3 nsl = GetTransform().localScale;
		nsl.x *= Mathf.Sign(posObjetivo.x - posicionInicial.x);
		GetTransform().localScale = nsl;

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

		Vector3 nsl = GetTransform().localScale;
		nsl.x *= (cualEra == 0?-1:1)*Mathf.Sign(posObjetivo.x - posicionInicial.x);
		GetTransform().localScale = nsl;

		while ( t > 0)
		{
			transform.position = Vector3.Lerp(posicionInicial, posObjetivo, t);
			t -= velocidad;
			yield return new WaitForSeconds(periodo);
		}
		CreadorMaletas.singleton.CrearPersonaje(cualEra);
		Destroy(gameObject);
	}

	public Transform GetTransform()
	{
		if (padreDelHijo)
		{
			return animPersonaje.transform.parent;
		}
		return animPersonaje.transform;
	}

	private void Update()
	{
		if (!devolviendose && Time.time > tiempoIniciado + tiempoRandom)
		{
			Devolver();
		}
	}

}
