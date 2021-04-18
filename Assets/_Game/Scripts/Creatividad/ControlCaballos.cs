using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCaballos : MonoBehaviour
{
    public PuntosCaballo p1;
    public PuntosCaballo p2;
	public GameObject gFinal;
	public GameObject gMal;

	public void Verificar()
	{
		if (p1.contacto && p2.contacto)
		{
			Instantiate(gFinal);
			Vicioso.singleton.SumarAcierto();
		}
		else
		{
			gMal.SetActive(true);
			Vicioso.singleton.SumarError();
		}
		Vicioso.singleton.GuardarDatos();
	}
}
