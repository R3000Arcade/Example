using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
	public Transform controlDisparo;
    public GameObject disparo;
	public GameObject UltraDisparo;
	public int contador = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
		{
			Disparar();
			contador++;
		}
		if(Input.GetButtonDown("Fire2") && contador >= 200)
		{
			DisparoUltra();
			contador = 0;
		}
    }
	
	private void Disparar()
	{
		Instantiate(disparo, controlDisparo.position,controlDisparo.rotation);
	}
	
		private void DisparoUltra()
	{
		Instantiate(UltraDisparo, controlDisparo.position,controlDisparo.rotation);
	}
}
