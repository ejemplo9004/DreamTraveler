using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(EventTrigger))]
public class SuperZoom : MonoBehaviour
{
    public float zoom = 1.2f;
	public float tiempo;
	public SuperValores[] hijos;
    public void Activar()
	{
		LeanTween.scale(gameObject, Vector3.one*zoom, tiempo);
		for (int i = 0; i < hijos.Length; i++)
		{
			StartCoroutine(ActivarConDelay(hijos[i]));
		}
	}
	public void Desactivar()
	{
		LeanTween.scale(gameObject, Vector3.one, tiempo);
		for (int i = 0; i < hijos.Length; i++)
		{
			hijos[i].Desactivar();
		}
	}


	public IEnumerator ActivarConDelay(SuperValores sv)
	{
		yield return new WaitForSeconds(sv.delay);
		sv.Activar();
	}
}

[System.Serializable]
public class SuperValores
{
	public GameObject objeto;
	public float delay = 0.2f;
	public float valor = 1.1f;
	public float tiempo=0.2f;

	public void Activar()
	{
		LeanTween.scale(objeto, Vector3.one * valor, tiempo);
	}
	public void Desactivar()
	{
		LeanTween.scale(objeto, Vector3.one, tiempo);
	}
}
