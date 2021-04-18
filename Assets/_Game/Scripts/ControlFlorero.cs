using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlFlorero : MonoBehaviour
{
    public Toggle[] tBuenos;
    public Toggle[] tMalos;
	public GameObject cnvFinal;
	public GameObject cnvMal;

    public void Validar()
	{
        bool bien = true;
		for (int i = 0; i < tBuenos.Length; i++)
		{
			if (!tBuenos[i].isOn)
			{
				bien = false;
			}
		}
		for (int i = 0; i < tMalos.Length; i++)
		{
			if (tMalos[i].isOn)
			{
				bien = false;
			}
		}
		if (bien)
		{
			Instantiate(cnvFinal);
			Vicioso.singleton.SumarAcierto();
		}
		else
		{
			cnvMal.SetActive(true);
			Vicioso.singleton.SumarError();
		}
	}
}
