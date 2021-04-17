using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSurrealista : MonoBehaviour
{
    public DragMe[] draggers;
    public Text txtPalabra;
    public string[] palabras;

    public static ControlSurrealista singleton;
    Vector3[] posDraggers;

    int indice = 0;

	private void Awake()
	{
        singleton = this;
	}

	void Start()
    {
        posDraggers = new Vector3[draggers.Length];
		for (int i = 0; i < draggers.Length; i++)
		{
            posDraggers[i] = draggers[i].transform.position;
		}
        txtPalabra.text = palabras[indice];
    }

    public void ReiniciarPosiciones()
	{
        for (int i = 0; i < draggers.Length; i++)
        {
            draggers[i].transform.position = posDraggers[i];
            draggers[i].transform.rotation = Quaternion.identity;
        }
    }

    public void Siguiente()
	{
        indice++;
		if (indice < palabras.Length)
		{
            txtPalabra.text = palabras[indice];
            ReiniciarPosiciones();
		}
		else
		{
            print("Finalizado");
		}
    }
    
}
