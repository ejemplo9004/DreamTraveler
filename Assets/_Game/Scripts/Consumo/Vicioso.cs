using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Vicioso : MonoBehaviour
{
    public static Vicioso singleton;
	public DatoJuego datos;
	public string email;
	public string url;

	private void Awake()
	{
		if (singleton != null)
		{
            DestroyImmediate(gameObject);
		}
		else
		{
			transform.parent = null;
			DontDestroyOnLoad(gameObject);
			singleton = this;
		}
	}

	private void Start()
	{
		InvokeRepeating("Cronometro", 1, 1);
	}

	public void Cronometro()
	{
		datos.tiempo++;
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
		StartCoroutine(Subir());
		print("GuardandoDatoas");
	}

	IEnumerator Subir()
	{
		WWWForm form = new WWWForm();
		form.AddField("email_usuario", datos.email_usuario);
		form.AddField("categoria", datos.categoria);
		form.AddField("juego", datos.juego);
		form.AddField("tiempo", datos.tiempo);
		form.AddField("aciertos", datos.aciertos);
		form.AddField("errores", datos.errores);
		form.AddField("metodo", "crear");

		UnityWebRequest www = UnityWebRequest.Post(url, form);
		yield return www.SendWebRequest();
		//print(www.)
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