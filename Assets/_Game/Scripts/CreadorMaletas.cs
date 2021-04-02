using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorMaletas : MonoBehaviour
{
    public List<Palabra> palabrasPosibles;
    public GameObject[] prMaleta;
    public GameObject[] prPersonajes;
    public float periodo = 5;

    public Transform posInicial0;
    public Transform posFinal0;

    public Transform posInicial1;
    public Transform posFinal1;
    

    List<Palabra> palabrasBarajadas;

    public static CreadorMaletas singleton;

	private void Awake()
	{
        singleton = this;
	}
	void Start()
    {
        Barajar();
        StartCoroutine(CrearMaletas());
        CrearPersonaje(0);
        CrearPersonaje(1);
    }

    int getNumeroPalabras()
	{
        return Random.Range(0, palabrasBarajadas.Count);
	}

    public void CrearPersonaje(int cual)
	{
		if (palabrasBarajadas.Count==0)
		{
            CrearPersonaje(TipoPalabra.sustantivo, posInicial0.position, posFinal0.position, cual);
            return;
        }
		if (cual == 0)
		{
            CrearPersonaje(palabrasBarajadas[getNumeroPalabras()].tipo, posInicial0.position, posFinal0.position, 0);
		}
		else
		{
            CrearPersonaje(palabrasBarajadas[getNumeroPalabras()].tipo, posInicial1.position, posFinal1.position, 1);
		}
    }

    void CrearPersonaje(TipoPalabra t, Vector3 pInicial, Vector3 pFinal, int i)
	{
        GameObject go = Instantiate(prPersonajes[Random.Range(0,prPersonajes.Length)], pInicial, Quaternion.identity) as GameObject;
        PersonajeMaletas pm = go.GetComponent<PersonajeMaletas>();
        pm.posicionInicial = pInicial;
        pm.posObjetivo = pFinal;
        pm.tipo = t;
        pm.cualEra = i;
	}

    public void DevolverMaleta(Palabra p)
	{
        palabrasBarajadas.Add(p);
	}

    public IEnumerator CrearMaletas()
	{
		while (palabrasBarajadas.Count > 0)
		{
            SiguientePalabra();
            yield return new WaitForSeconds(periodo);
		}
	}

    public void Barajar()
	{
        palabrasBarajadas = new List<Palabra>();
        List<Palabra> palabrasBarajadasTemp = new List<Palabra>();
		for (int i = 0; i < palabrasPosibles.Count; i++)
		{
            palabrasBarajadasTemp.Add(palabrasPosibles[i]);
        }
		while (palabrasBarajadasTemp.Count > 0)
		{
            int ind = Random.Range(0, palabrasBarajadasTemp.Count);
            palabrasBarajadas.Add(palabrasBarajadasTemp[ind]);
            palabrasBarajadasTemp.RemoveAt(ind);
		}
	}

    [ContextMenu("Siguiente Palabra")]
    public void SiguientePalabra()
	{
		if (palabrasBarajadas.Count<=0)
		{
            return;
		}
        GameObject GOM = Instantiate(prMaleta[Random.Range(0,prMaleta.Length)], transform.position, transform.rotation);
        Maleta m = GOM.GetComponent<Maleta>();
        m.Inicializar(palabrasBarajadas[0]);
        palabrasBarajadas.RemoveAt(0);
	}
}
