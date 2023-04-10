using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
	public Transform controlDisparo;
    public GameObject disparo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
		{
			Disparar();
		}
    }
	
	private void Disparar()
	{
		Instantiate(disparo, controlDisparo.position,controlDisparo.rotation);
	}
}
