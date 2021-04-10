using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalabrasOcultas : MonoBehaviour
{
    public Text txt;
    public string palabra;

	bool verificado = false;
    public void Inicializar(string p)
	{
        palabra = p;
		txt.text = "";
		for (int i = 0; i < p.Length; i++)
		{
			txt.text += "■";
		}
	}

	public bool Comparar(string p)
	{
		if (!verificado && p.Equals(palabra))
		{
			txt.text = palabra;
			verificado = true;
			return true;
		}
		return false;
	}
}
