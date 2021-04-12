using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pastel : MonoBehaviour
{
    public Text mensaje;
    public GameObject imMensaje;
    public Toggle[] toggles;

    public void Verificar()
	{
        int cuantos = 0;
		for (int i = 0; i < toggles.Length; i++)
		{
			if (toggles[i].isOn) cuantos++;
		}
		if (cuantos != 3)
		{
			mensaje.text = "Debe seleccionar exactamente 3 cortes, pero seleccionaste " + cuantos;
			imMensaje.SetActive(true);
		}
		else
		{
			if (toggles[5].isOn && !toggles[4].isOn && !toggles[6].isOn &&
				((toggles[0].isOn && toggles[2].isOn && !toggles[1].isOn && !toggles[3].isOn) ||
				(!toggles[0].isOn && !toggles[2].isOn && toggles[1].isOn && toggles[3].isOn))
				)
			{
				mensaje.text = "Perfecto!";
				ControlGenerico.singleton.SumarPuntos(10);
			}
			else
			{
				mensaje.text = "La respuesta no es correcta, intenta nuevamente.";
				imMensaje.SetActive(true);
			}
		}
	}
}
