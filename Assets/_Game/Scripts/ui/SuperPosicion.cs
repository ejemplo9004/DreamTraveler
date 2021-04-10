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
	public bool añadirEventosAutomaticamente = true;

	Vector3 posInicial;
	private void Start()
	{
		posInicial = transform.position;
		for (int i = 0; i < hijos.Length; i++)
		{
			hijos[i].posInicial = hijos[i].objeto.transform.position;
		}
		if (añadirEventosAutomaticamente)
		{
			AñadirEventos();
		}
	}

	void AñadirEventos()
	{
		EventTrigger eventTrigger = GetComponent<EventTrigger>();

		EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry();
		pointerDownEntry.eventID = EventTriggerType.PointerEnter;
		pointerDownEntry.callback.AddListener((data) => Activar());
		eventTrigger.triggers.Add(pointerDownEntry);

		EventTrigger.Entry pointerDownEntry2 = new EventTrigger.Entry();
		pointerDownEntry2.eventID = EventTriggerType.PointerExit;
		pointerDownEntry2.callback.AddListener((data) => Desactivar());
		eventTrigger.triggers.Add(pointerDownEntry2);

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