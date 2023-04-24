using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject menuPrincipal;
	public GameObject menuGameOver;
    public Renderer fondo;
	public float inputHorizontal;
	public float inputVertical;
	public GameObject enemigos;
	public Transform CreateEnemy;
	public bool gameOver = false;
	public bool start = false;
	public int puntos;
	Enemy enemigo;
	
	
    void Start()
    {

			enemigo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
			InvokeRepeating("CrearEnemigos",5f,3f);
			
		
		
    }


    void Update()
    {
		if(start == true && gameOver ==true)
		{
			menuGameOver.SetActive(true);
			if(Input.GetKeyDown(KeyCode.X))
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				
			}
		}
		if(start == false)
		{
			if(Input.GetKeyDown(KeyCode.X))
			{
				start = true;
				
			}
		}
		
		if(start == true && gameOver == false)
		{
			menuPrincipal.SetActive(false);
			inputHorizontal = Input.GetAxis("Horizontal");
			if(inputHorizontal > 0)
			{
				fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(inputHorizontal,0) * Time.deltaTime;
			}
			
		}
		
		
    }
	
	
	public void CrearEnemigos()
	{
		if(start == true && gameOver == false)
		{
		 Instantiate(enemigo, CreateEnemy.position,CreateEnemy.rotation);	
		 
		 puntos+=18;
		 if(puntos >= 15)
		 {
			 SceneManager.LoadScene("2",LoadSceneMode.Single);
		 }
		}		 
	}
}
