using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float inputHorizontal;
	public float vida;
	public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
		if (gameManager.start)
			{
			inputHorizontal = Input.GetAxis("Horizontal");
			if(inputHorizontal > 0)
			{
				transform.position = transform.position + new Vector3(-inputHorizontal,0,0) * Time.deltaTime * 10;
			}else
			{
				transform.position = transform.position + new Vector3(-0.09f,0,0) * Time.deltaTime * 20;
			}
		}
		if (gameManager.gameOver)
        {
            Destroy(gameObject);
        }
    }
	
	public void TomarDanio(float danio)
	{
		vida -= danio;
		if(vida <= 0)
		{
			Destroy(gameObject);
		}
		
	}
	
	
	
}
