using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosCaballo : MonoBehaviour
{
	public bool contacto;
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.CompareTag("Maleta"))
		{
			contacto = true;
		} 
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Maleta"))
		{
			contacto = false;
		}
	}
}
