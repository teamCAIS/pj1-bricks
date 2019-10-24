using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

	protected Rigidbody2D rb2d;
	public float speedX = -5.0f;
	public float speedY = 3.0f;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	void FixedUpdate () {
		rb2d.velocity = new Vector2(speedX * Time.deltaTime * 10, speedY * Time.deltaTime * 10);
	}

	void OnCollisionEnter2D(Collision2D col){
		switch(col.gameObject.name){
			case "Brick":
				Destroy(col.gameObject);
				speedY *= -1;
				break;
			case "Player":
				if(speedY < 0){
					speedY *= -1;
				}
				// Rigidbody2D playerPos = col.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
				// if(playerPos != null){
				// 	float deltaX = rb2d.position.x - (playerPos.position.x -50);
				// 	speedX += deltaX*0.005f;
				// }
				break;
			case "BoundLeft":
				speedX *= -1;
				break;
			case "BoundRight":
				speedX *= -1;
				break;
			case "BoundTop":
				speedY *= -1;
				break;
			case "BoundBottom":
				speedY *= -1;
				break;
		}
	}
}
