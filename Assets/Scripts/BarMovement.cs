using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour {

	public float speed = 20.0f;
	protected float move;
	private Rigidbody2D rb2d; 

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){
			rb2d.position = rb2d.position + new Vector2(move, 0);
		}
	}
}
