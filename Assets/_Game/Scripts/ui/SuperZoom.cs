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

	public bool añadirEventosAutomaticamente = true;

	private void Start()
	{
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
