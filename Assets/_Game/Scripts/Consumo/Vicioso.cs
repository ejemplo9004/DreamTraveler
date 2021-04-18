using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vicioso : MonoBehaviour
{
    public static Vicioso singleton;
	public DatoJuego datos;
	public string email;


	private void Awake()
	{
		if (singleton != null)
		{
            DestroyImmediate(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
			singleton = this;
		}
	}

	public void Reiniciar(int _cat, int _jue)
	{
		datos.Reiniciar(email, _cat, _jue);
	}

	public void SumarAcierto()
	{
		datos.aciertos++;
	}

	public void SumarError()
	{
		datos.errores++;
	}

	public void GuardarDatos()
	{

	}
}

[System.Serializable]
public class DatoJuego
{
	public string email_usuario;
	public int categoria;
	public int juego;
	public int tiempo;
	public int aciertos;
	public int errores;

	public void Reiniciar(string mail, int _cate, int _jueg)
	{
		email_usuario = mail;
		categoria = _cate;
		juego = _jueg;
		tiempo = 0;
		aciertos = 0;
		errores = 0;
	}
}