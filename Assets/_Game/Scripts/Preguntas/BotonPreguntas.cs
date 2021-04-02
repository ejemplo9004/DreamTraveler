using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPreguntas : MonoBehaviour
{
	public int opcion;
	public Text txtBoton;

	public void Inicializar(string respuesta, int o)
	{
		opcion = o;
		txtBoton.text = respuesta;
	}
    public void Verificar()
	{
		GestorPreguntas.singleton.Verificar(opcion);
	}
}
