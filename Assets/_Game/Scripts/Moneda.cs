using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public Vector3 velocidad;
	public static int monedas;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(velocidad * Time.deltaTime);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Destroy(gameObject);
			monedas++;
		}
	}
}
