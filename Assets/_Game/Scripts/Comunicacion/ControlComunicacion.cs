using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlComunicacion : MonoBehaviour
{
    public Dialogo[] dialogos;
    public Animator animP0;
    public Animator animP1;
    public Text txtNormal;
    public Button btns;
    public Image imCara;
    public GameObject gmOpciones;

    public int indice;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarOpcion(Dialogo d)
	{
        imCara.sprite = d.imagen;

		if (d.multiOpciones)
		{
            txtNormal.gameObject.SetActive(false);
            gmOpciones.SetActive(true);
			for (int i = 0; i < d.opciones.Length; i++)
			{

			}
        }
        else
		{
            txtNormal.gameObject.SetActive(true);
            gmOpciones.SetActive(false);
        }
	}
}

[System.Serializable]
public class Dialogo
{
    public string frase;
    public Sprite imagen;
    public int puntos;
    public int siguiente;
    public bool multiOpciones;
    public string[] opciones;
}