using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
    public Renderer fondo;
	public float inputHorizontal;
	public float inputVertical;
	
    void Start()
    {
       
		
    }


    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
		if(inputHorizontal > 0)
		{
			fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(inputHorizontal,0) * Time.deltaTime;
		}
		
    }
}
