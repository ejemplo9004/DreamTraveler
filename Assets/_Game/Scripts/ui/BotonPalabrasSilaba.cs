using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonPalabrasSilaba : MonoBehaviour
{
	public string letras;
	public Text txt;

	private void Start()
	{
		txt.text = letras;
		BotoneraPalabras.singleton.botones.Add(this);
	}

	public void Agregar()
	{
		BotoneraPalabras.singleton.AgregarSilava(letras);
		Desaparecer();
	}

	public void Desaparecer()
	{
		LeanTween.scale(gameObject, Vector3.zero, 0.2f);
	}
	public void Aparecer()
	{
		LeanTween.scale(gameObject, Vector3.one, 0.2f);
	}
}
