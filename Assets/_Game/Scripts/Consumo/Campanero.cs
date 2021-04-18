using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campanero : MonoBehaviour
{
    public int categoria;
    public int juego;
	public bool guardarAlDestruir = true;
    void Start()
    {
		if (Vicioso.singleton != null)
		{
            Vicioso.singleton.Reiniciar(categoria, juego);
		}
    }

	private void OnDestroy()
	{
		if (guardarAlDestruir && Vicioso.singleton != null)
		{
			Vicioso.singleton.GuardarDatos();
		}
	}

	public void SumarAcierto()
	{
		if (guardarAlDestruir && Vicioso.singleton != null)
		{
			Vicioso.singleton.SumarAcierto();
		}
	}

	public void SumarError()
	{
		if (guardarAlDestruir && Vicioso.singleton != null)
		{
			Vicioso.singleton.SumarError();
		}
	}

}
