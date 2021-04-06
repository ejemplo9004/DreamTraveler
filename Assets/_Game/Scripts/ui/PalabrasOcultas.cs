using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalabrasOcultas : MonoBehaviour
{
    public Text txt;
    public string palabra;
	
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
		if (p.Equals(palabra))
		{
			txt.text = palabra;
			return true;
		}
		return false;
	}
}
