using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private Vector3 PaddleToBallVector;
	private bool hasStarted = false;
	private Rigidbody2D rigidBody2d;
	public static int ballLife;
	private AudioSource[] source;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		PaddleToBallVector = this.transform.position - paddle.transform.position;
		rigidBody2d =  this.GetComponent<Rigidbody2D>();
		source = this.GetComponents<AudioSource>();
		ballLife = 2;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
		//lock the ball reliative to the paddle
			this.transform.position = paddle.transform.position + PaddleToBallVector;
			//wait for mousepress to launch
			if(Input.GetMouseButtonDown(0)){
				print ("Mouse Clicked, launch ball");
				hasStarted = true;
				source[0].Play();
				rigidBody2d.velocity = new Vector2(2f, 10f);
				
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		rigidBody2d.velocity += tweak;
		if(hasStarted)
		source[1].Play();
	}
	
	public void restartBall(){
		ballLife--;
		hasStarted = false;
		Debug.Log("Lives left: " +ballLife);
		this.transform.position = paddle.transform.position + PaddleToBallVector;
	}
}
