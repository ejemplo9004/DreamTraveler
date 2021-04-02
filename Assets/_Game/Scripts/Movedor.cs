using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movedor : MonoBehaviour
{
    public Vector3  velocidad;
    public bool     activo = true;
    void Update()
    {
		if (activo)
		{
            transform.Translate(velocidad * Time.deltaTime);
		}
    }
}
