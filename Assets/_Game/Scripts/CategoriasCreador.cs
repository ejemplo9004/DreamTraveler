using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoriasCreador : MonoBehaviour
{
    public Transform[] posiciones;
    public GameObject[] creados;
    public List<PPalabra> palabras;
    public GameObject prPalabra;

    void Start()
    {
        creados = new GameObject[posiciones.Length];
        StartCoroutine(VerificadorConstante());
    }

    IEnumerator VerificadorConstante()
    {
		while (palabras.Count > 0)
		{
            for (int i = 0; i < creados.Length; i++)
            {
                if (creados[i] == null && palabras.Count>0)
                {
                    int ind = Random.Range(0, palabras.Count);
                    GameObject gmo = Instantiate(prPalabra, posiciones[i].position, posiciones[i].rotation) as GameObject;
                    gmo.GetComponent<Dragrupador>().bando = palabras[ind].bando;
                    gmo.GetComponentInChildren<UnityEngine.UI.Text>().text = palabras[ind].palabra;
                    creados[i] = gmo;
                    palabras.RemoveAt(ind);
                    yield return new WaitForSeconds(0.2f);
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}

[System.Serializable]
public class PPalabra
{
    public string palabra;
    public int bando;
}