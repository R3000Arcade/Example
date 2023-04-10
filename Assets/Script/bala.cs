using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidad;
	public float danio;
	Enemy enemigo;
    void Start()
    {
		enemigo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
	
	private void OnCollisionEnter2D(Collision2D collition)
	{
		if(collition.gameObject.tag == "Enemy")
		{
			Debug.Log("Pum");
			if(enemigo.vida > 0)
			{
			 enemigo.TomarDanio(danio);
			}
			Destroy(gameObject);			
		}
	}

}
	/*
	private void OntriggerEnter2D(Collider2D collition)
	{
		Debug.Log("Choco");
		if(collition.CompareTag("Enemy"))
		{
			collition.GetComponent<Enemy>().TomarDanio(danio);
			Destroy(gameObject);
			
		}
	}
	*/

