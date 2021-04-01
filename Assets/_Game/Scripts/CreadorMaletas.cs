using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorMaletas : MonoBehaviour
{
    public List<Palabra> palabrasPosibles;
    public GameObject prMaleta;
    public GameObject prPersonaje;
    public float periodo = 5;

    public Transform posInicial;
    public Transform posFinal;

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
        CrearPersonaje(palabrasBarajadas[0].tipo, posInicial.position, posFinal.position);
    }

    public void CrearPersonaje(TipoPalabra t, Vector3 pInicial, Vector3 pFinal)
	{
        GameObject go = Instantiate(prPersonaje, pInicial, Quaternion.identity) as GameObject;
        PersonajeMaletas pm = go.GetComponent<PersonajeMaletas>();
        pm.posicionInicial = pInicial;
        pm.posObjetivo = pFinal;
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
        GameObject GOM = Instantiate(prMaleta, transform.position, transform.rotation);
        Maleta m = GOM.GetComponent<Maleta>();
        m.Inicializar(palabrasBarajadas[0]);
        palabrasBarajadas.RemoveAt(0);
	}
}
