using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVasos : MonoBehaviour
{
    public Button btnVotear;
    public Button btnEnderezar;
    public bool arriba;
    public int posicionX;
    public Transform tSeleccion;
    public bool inicioMovimiento;
    public int posVasoSeleccionado;
    public Vaso[] vasos;
    public GameObject botonera;
    public GameObject cnvgameOver;
    public GameObject prBien;

    public static ControlVasos singleton;

    private void Awake()
    {
        singleton = this;
    }
	// Start is called before the first frame update
	void Start()
    {
        botonera.SetActive(false);
    }
    public void Subir()
    {

		if (Vaso.vasoActivo != null)
        {
            inicioMovimiento = true;
            Vaso.vasoActivo.Subir();
            arriba = Vaso.vasoActivo.arriba;
		}
    }

    public void Bajar()
    {
        if (Vaso.vasoActivo != null)
        {
            inicioMovimiento = true;
            Vaso.vasoActivo.Bajar();
            arriba = Vaso.vasoActivo.arriba;
            Invoke("Verificar", 2);
        }
    }

    public void Verificar()
	{
		if ((!vasos[0].lleno && !vasos[2].lleno && !vasos[4].lleno && vasos[1].lleno && vasos[3].lleno && vasos[5].lleno) && (posicionX == 7 || posicionX == 8 || posicionX==9)  )
		{
            Instantiate(prBien);
		}
		else
		{
            GameOver();
		}
	}

    public void Izquierda()
    {
        if (Vaso.vasoActivo != null)
        {
            inicioMovimiento = true;
            Vaso.vasoActivo.Izquierda();
            posicionX = Mathf.RoundToInt(Vaso.vasoActivo.px);
        }
    }



    public void Derecha()
    {
        if (Vaso.vasoActivo != null)
        {
            inicioMovimiento = true;
            Vaso.vasoActivo.Derecha();
            posicionX = Mathf.RoundToInt(Vaso.vasoActivo.px);
        }
    }
    public void Voltear()
    {
        if (Vaso.vasoActivo != null && !Vaso.vasoActivo.volteado)
        {
			if (Vaso.vasoActivo.lleno && posicionX % 2 == 0)
			{
				if (!vasos[posicionX/2].lleno)
				{
                    vasos[posicionX / 2].animator.SetTrigger("llenar");
                    vasos[posicionX / 2].lleno = true;
                }
			}
            inicioMovimiento = true;
            Vaso.vasoActivo.Voltear();
            btnVotear.interactable = false;
            btnEnderezar.interactable = true;
        }
    }
    public void Enderezar()
    {
        if (Vaso.vasoActivo != null && Vaso.vasoActivo.volteado)
        {
            inicioMovimiento = true;
            Vaso.vasoActivo.Enderezar();
            btnVotear.interactable = true;
            btnEnderezar.interactable = false;
        }
    }

    public void GameOver()
	{
        cnvgameOver.SetActive(true);
	}
}
