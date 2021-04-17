using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotadRags : MonoBehaviour
{
    public Vector3 posInicial;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (DragMe.drgActivo == null)
		{
            transform.position = posInicial;
		}
		else
		{
            transform.position = DragMe.drgActivo.transform.position;
		}
    }

    public void RotarObjeto()
	{
        if (DragMe.drgActivo != null)
        {
            DragMe.drgActivo.transform.Rotate(Vector3.forward * 45);
        }
        
	}
}
