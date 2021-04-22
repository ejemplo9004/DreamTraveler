using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GestorPreguntas : MonoBehaviour
{
    public static GestorPreguntas singleton;
	public Pregunta[] preguntas;
	public int indice;
	public List<BotonPreguntas> botones;

	[Header("UI")]
	public Text txtPregunta;
	public Transform padreRespuestas;
	public GameObject prBotonRespuesta;
	public bool enEspera;
	public GameObject prBien;
	public GameObject prMal;
	public GameObject cnvFinal;
	int i;

	private void Awake()
	{
        singleton = this;
	}

	IEnumerator Start()
	{
		List<Pregunta> ordenada = new List<Pregunta>();
		List<Pregunta> desordenada = new List<Pregunta>();
		for (int i = 0; i < preguntas.Length; i++)
		{
			ordenada.Add(preguntas[i]);
		}

		for (int i = 0; i < preguntas.Length; i++)
		{
			int k = Random.Range(0,ordenada.Count);
			desordenada.Add(ordenada[k]);
			ordenada.RemoveAt(k);
		}

		preguntas = desordenada.ToArray();

		for (i = 0; i < preguntas.Length; i++)
		{
			CrearPregunta(preguntas[i]);
			yield return new WaitUntil(() => !enEspera);
			yield return new WaitForSeconds(1);
		}
		Instantiate(cnvFinal);
	}

	void CrearPregunta(Pregunta p)
	{
		LimpiarRespuestas();
		txtPregunta.text = p.pregunta;
		for (int i = 0; i < p.respuestas.Length; i++)
		{
			GameObject bt = Instantiate(prBotonRespuesta, padreRespuestas) as GameObject;
			BotonPreguntas btn = bt.GetComponent<BotonPreguntas>();
			btn.Inicializar(p.respuestas[i], i);
			botones.Add(btn);
		}
		enEspera = true;
	}

	public void LimpiarRespuestas()
	{
		if (botones == null)
		{
			botones = new List<BotonPreguntas>();
		}
		for (int i = 0; i < botones.Count; i++)
		{
			Destroy(botones[i].gameObject);
		}
		botones = new List<BotonPreguntas>();
	}

	public void Verificar(int cual)
	{
		if (preguntas[i].correcta == cual)
		{
			print("Respuesta correcta");
			Vicioso.singleton.SumarAcierto();
			Instantiate(prBien);
		}
		else
		{
			Instantiate(prMal);
			Vicioso.singleton.SumarError();
			print("Respuesta MALA!!!!!! aprenda..");
		}
		enEspera = false;
	}
}

[System.Serializable]
public class Pregunta
{
	public string pregunta;
	public string[] respuestas;
	public int correcta;
}
