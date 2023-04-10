using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	
    public Renderer fondo;
	public float inputHorizontal;
	public float inputVertical;
	public GameObject enemigos;
	public Transform CreateEnemy;
	
    void Start()
    {
       InvokeRepeating("CrearEnemigos",5f,3f);
		
    }


    void Update()
    {
		
        inputHorizontal = Input.GetAxis("Horizontal");
		if(inputHorizontal > 0)
		{
			fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(inputHorizontal,0) * Time.deltaTime;
		}
		
		
    }
	
	
	public void CrearEnemigos()
	{
		Instantiate(enemigos, CreateEnemy.position,CreateEnemy.rotation);
	}
}
