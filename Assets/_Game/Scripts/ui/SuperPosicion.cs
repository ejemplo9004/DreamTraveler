using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(EventTrigger))]

public class SuperPosicion : MonoBehaviour
{

	public Vector3 posicion;
	public float tiempo;
	public SuperValores2[] hijos;

	Vector3 posInicial;
	private void Start()
	{
		posInicial = transform.position;
		for (int i = 0; i < hijos.Length; i++)
		{
			hijos[i].posInicial = hijos[i].objeto.transform.position;
		}
	}

	public void Activar()
	{
		LeanTween.move(gameObject, posInicial + posicion, tiempo);
		for (int i = 0; i < hijos.Length; i++)
		{
			StartCoroutine(ActivarConDelay(hijos[i]));
		}
	}
	public void Desactivar()
	{
		LeanTween.move(gameObject, posInicial, tiempo);
		for (int i = 0; i < hijos.Length; i++)
		{
			hijos[i].Desactivar();
		}
	}


	public IEnumerator ActivarConDelay(SuperValores2 sv)
	{
		yield return new WaitForSeconds(sv.delay);
		sv.Activar();
	}
}

[System.Serializable]
public class SuperValores2
{
	public GameObject objeto;
	public float delay = 0.2f;
	public Vector3 valor;
	public float tiempo = 0.2f;
	[HideInInspector]
	public Vector3 posInicial;

	public void Activar()
	{
		LeanTween.move(objeto, posInicial + valor, tiempo);
	}
	public void Desactivar()
	{
		LeanTween.move(objeto, posInicial, tiempo);
	}
}