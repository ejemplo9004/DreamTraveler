using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGenerico : MonoBehaviour
{
    public static ControlGenerico singleton;
	public int puntos;
	public int puntosEsperados = 10;
	public GameObject cnvFinalNivel;

	private void Awake()
	{
		singleton = this;
	}

	public void SumarPuntos(int p)
	{
		puntos += p;
		if (puntos >=puntosEsperados)
		{
			Instantiate(cnvFinalNivel);
		}
	}
}
