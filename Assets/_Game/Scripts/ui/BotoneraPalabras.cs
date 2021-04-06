using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotoneraPalabras : MonoBehaviour
{
    public string palabraActual;

    public List<BotonPalabrasSilaba> botones;
    public Text txtPrevia;

	[Header("Palabras")]
	public GameObject prPalabra;
	public string[] palabras;
	public int aciertos;
	public Transform padrePalabras;
	public List<PalabrasOcultas> palabrasOcultas = new List<PalabrasOcultas>();

    public static BotoneraPalabras singleton;

	private void Awake()
	{
        singleton = this;
	}

	private void Start()
	{
		CrearPalabras();
	}
	public void AgregarSilava(string a)
	{
		palabraActual += a;
		ActualizarTexto();
	}

	void ActualizarTexto()
	{
		txtPrevia.text = palabraActual;
	}

	[ContextMenu("Aparecer")]
	public void Aparecer()
	{
		for (int i = 0; i < botones.Count; i++)
		{
			botones[i].Aparecer();
		}
	}

	void CrearPalabras()
	{
		for (int i = 0; i < palabras.Length; i++)
		{
			GameObject go = Instantiate(prPalabra, padrePalabras) as GameObject;
			PalabrasOcultas po = go.GetComponent<PalabrasOcultas>();
			po.Inicializar(palabras[i]);
			palabrasOcultas.Add(po);
		}
	}

}
