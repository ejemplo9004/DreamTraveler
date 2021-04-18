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
    public Button[] btns;
    public Image imCara;
    public GameObject gmOpciones;
    public GameObject cnvFinal;
    public int puntos;

    public Sprite[] sp0;
    public Sprite[] sp1;

    public int indice;

    void Start()
    {
        MostrarOpcion(indice);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarOpcion(int di)
	{
        Dialogo d = dialogos[di];

        if (d.multiOpciones)
		{
            txtNormal.gameObject.SetActive(false);
            gmOpciones.SetActive(true);
			for (int i = 0; i < btns.Length; i++)
			{
                btns[i].GetComponentInChildren<Text>().text = d.opciones[i]; 
			}
            btns[Random.Range(0, btns.Length)].transform.SetSiblingIndex(0);
            btns[Random.Range(0, btns.Length)].transform.SetSiblingIndex(0);
            btns[Random.Range(0, btns.Length)].transform.SetSiblingIndex(0);
        }
        else
		{
            txtNormal.text = d.frase;
            txtNormal.gameObject.SetActive(true);
            gmOpciones.SetActive(false);
        }

		if (di%2 == 0)
		{
            animP0.SetBool("hablando", true);
            animP1.SetBool("hablando", false);
            imCara.sprite = sp0[Numero()];
		}
		else
		{
            animP0.SetBool("hablando", false);
            animP1.SetBool("hablando", true);
            imCara.sprite = sp1[Numero()
                ];
        }
	}

    public void Verificar(int c)
	{
		if (c == 2)
		{
            puntos++;
		}
        Siguiente();
    }

    public void Siguiente()
	{
        indice++;
		if (indice < dialogos.Length)
		{
            MostrarOpcion(indice);
		}
		else
		{
            gmOpciones.SetActive(false);
            Invoke("TerminarNivel", 2);

        }
	}

    void TerminarNivel()
	{
        Instantiate(cnvFinal);
	}

    public int Numero()
	{
        if (puntos > dialogos.Length * 0.7f) return 2;
        if (puntos > dialogos.Length * 0.4f) return 2;
        return 0;
	}
}

[System.Serializable]
public class Dialogo
{
    public string frase;
    public int puntos;
    public bool multiOpciones;
    public string[] opciones;
}