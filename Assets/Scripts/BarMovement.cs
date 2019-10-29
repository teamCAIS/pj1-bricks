using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour {

	public float speed = 20.0f;
	public float edge = 6.9f;
	protected float move;
	//private Rigidbody2D rb2d; 

	void Start(){
		//rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		move = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		transform.Translate(new Vector2(move,0));
		if(transform.position.x < -this.edge){
			transform.position = new Vector2(-this.edge,transform.position.y);
		}
		if(transform.position.x > this.edge){
			transform.position = new Vector2(this.edge,transform.position.y);
		}
	}
}
