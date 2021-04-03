using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBienMal : MonoBehaviour
{
    public Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void Cerrar()
	{
		animator.SetTrigger("cerrar");
		Destroy(gameObject, 1);
	}
}
