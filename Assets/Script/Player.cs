using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
	public float furzaSalto;
	private Rigidbody2D rigidBody2D;
	public float inputHorizontal;
	public float inputVertical;
	private BoxCollider2D boxCollider;
	public LayerMask capaSuelo;
	bool moverse =  true;
    void Start()
    {
         animator = GetComponent<Animator>();
		 rigidBody2D = GetComponent<Rigidbody2D>();
		 boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
		inputVertical = Input.GetAxis("Vertical");
		if(inputHorizontal > 0 && moverse)
		{
			animator.SetBool("Correr", true);
			animator.SetBool("Parado", false);
			animator.SetBool("Saltar",false);
            transform.position = transform.position + new Vector3(inputHorizontal, 0, 0) * Time.deltaTime;

        }
		if(inputHorizontal <= 0)
		{
			animator.SetBool("Correr", false);
			animator.SetBool("Parado", true);
			animator.SetBool("Saltar",false);
		}
		
		if(inputVertical >0 && EstaenelSuelo() && moverse)
		{
			animator.SetBool("Correr", false);
			animator.SetBool("Parado", false);
			animator.SetBool("Saltar",true);	
			rigidBody2D.AddForce(new Vector2(0,furzaSalto));
			 
		}
		if(inputVertical >0 && inputHorizontal > 0 && moverse)
		{
			transform.position = transform.position + new Vector3(3, 0, 0) * Time.deltaTime;
		}

    }
	
	bool EstaenelSuelo()
	{
		//Primer valor punto de origen de donde parte la caja
		//Segundo valor el tamoño del colaider
		//Angulo 
		//Direccion
		//Distancia
		//Mascara de capas
		RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,new Vector2(boxCollider.bounds.size.x,boxCollider.bounds.size.y), 0f,Vector2.down,0.2f,capaSuelo);
		if(raycastHit.collider == null)
		{
			return false;
		}
		return true;
		
	}
	
	private void OnCollisionEnter2D(Collision2D collition)
	{
		if(collition.gameObject.tag == "Enemy")
		{
			Debug.Log("Pum");
			Quaternion target = Quaternion.Euler(0, 0, -90);
			transform.rotation =  target;
			moverse = false;
		}
	}
}
