using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PNumeros : MonoBehaviour
{
    public Text textoGuia;
    public Text[] textos;
    int correcta;

    public GameObject gBien;
    public GameObject gMal;
    public float tiempo;
    public Image imTiempo;
    public GameObject cnvFinal;

    float tiempoInicial;

    bool verificando = false;

    [ContextMenu("HacerNumeros")]
    public void GenerarTextos()
	{
        List<string> numerosGenerados = new List<string>();
        int correcto = Random.Range(1, 10);
        correcto *= 10;
        correcto += Random.Range(0, 10);
        correcto *= 10;
        correcto += Random.Range(0, 10);
        correcto *= 10;
        correcto += Random.Range(0, 10);

        string strCorrecto = correcto.ToString("0000");
        textoGuia.text = strCorrecto;
        string falsa;
        numerosGenerados.Add(strCorrecto);
		for (int i = 0; i < 4; i++)
		{
            do
		    {
                int numero = Random.Range(0, 4);
                falsa = strCorrecto.Substring(0, numero) + GetRandomChar() + strCorrecto.Substring(numero + 1, 3 - numero);
		    } while (VerificarExistencia(numerosGenerados, falsa));
            numerosGenerados.Add(falsa);
		}
        correcta = Random.Range(1, 5);
        numerosGenerados[correcta] = strCorrecto;
		for (int i = 1; i < numerosGenerados.Count; i++)
		{
            textos[i-1].text = numerosGenerados[i];
		}

    }

	private void Start()
	{
        GenerarTextos();
        tiempoInicial = tiempo;
        StartCoroutine(Esperar());
    }

    IEnumerator Esperar()
	{
		while (tiempo > 0.01f)
		{
            yield return new WaitForSeconds(0.1f);
		}
        Instantiate(cnvFinal);
	}

	private void Update()
	{
        if(!verificando) tiempo -= Time.deltaTime;
		if (tiempo < 0)
		{
            tiempo = 0;
		}
        imTiempo.fillAmount = tiempo / tiempoInicial;
	}

	public void Verificar(int i)
	{
		if (verificando)
		{
            return;
		}
		if (i+1 == correcta)
		{
            StartCoroutine(ActivarDesactivar(gBien));
            Instantiate(gBien);
            Vicioso.singleton.SumarAcierto();
		}
		else
		{
            StartCoroutine(ActivarDesactivar(gMal));
            Instantiate(gMal);
            Vicioso.singleton.SumarError();
        }
	}

    IEnumerator ActivarDesactivar(GameObject g)
	{
        verificando = true;
        //g.SetActive(true);
        yield return new WaitForSeconds(2);
        //g.SetActive(false);
        verificando = false;
        GenerarTextos();
    }
    public bool VerificarExistencia(List<string> lista, string texto)
	{
		for (int i = 0; i < lista.Count; i++)
		{
			if (lista[i].Equals(texto))
			{
                return true;
			}
		}
        return false;
	}
    char GetRandomChar()
	{
        int i = Random.Range(0, 10);
		switch (i)
        {
            case 0:
                return '0';
            case 1:
                return '1';
            case 2:
                return '2';
            case 3:
                return '3';
            case 4:
                return '4';
            case 5:
                return '5';
            case 6:
                return '6';
            case 7:
                return '7';
            case 8:
                return '8';
            default:
                return '9';
        }
	}
}
