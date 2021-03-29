using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public void CambiarEscena(string e)
	{
		SceneManager.LoadScene(e);
	}

	public void Salir()
	{
		Application.Quit();
	}
}
