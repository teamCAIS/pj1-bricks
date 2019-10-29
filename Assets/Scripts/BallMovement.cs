using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour {

	protected Rigidbody2D rb2d;
	public float speed = 100.0f;
	private bool onPlay = false;
	private Vector2 initialPosition = new Vector2(0.0f,-4.3f);
	public AudioClip clip;
	public AudioSource source;

	private int lifes = 3;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		this.source.clip = this.clip;
	}

	void Update () {
		if(Input.GetButtonUp("Jump") && !this.onPlay)
		{
			this.rb2d.AddForce(new Vector2(1.0f*speed,1.0f*speed));
			this.onPlay = true;
		}
		if(this.lifes <= 0) {
			SceneManager.LoadScene("GameOverScene");
		}
	}

	void OnTriggerExit2D()
    {
        this.onPlay = false;
        transform.position = this.initialPosition;
        this.rb2d.velocity = Vector2.zero;
				this.lifes--;
				Debug.Log(this.lifes);
    }
	
	void FixedUpdate () {
		//rb2d.velocity = new Vector2(speedX * Time.deltaTime * 10, speedY * Time.deltaTime * 10);
	}
	
	void OnCollisionEnter2D(Collision2D col){
		source.Play();
		if(col.gameObject.CompareTag("Brick")){
			col.gameObject.SetActive(false);
		}
	}

	/* void OnCollisionEnter2D(Collision2D col){
		//normalmente se pega a tag e não o name, 
		//pois o name é mais volúvel a mudanças, inclusive por designers
		switch(col.gameObject.name){
			case "Brick":
				//creio ser prefirivel inativar ao invés de destruir, 
				//para poder só ativar novamente se necessitar, melhorando a performance
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
	} */
}
