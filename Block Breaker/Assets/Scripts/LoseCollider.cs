using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager lvlManager;
	

	
	void OnTriggerEnter2D(Collider2D trigger){
		
		print("Trigger");
		Ball ball = GameObject.FindObjectOfType<Ball>();
		if(Ball.ballLife <= 0){
			lvlManager = GameObject.FindObjectOfType<LevelManager>();
			lvlManager.LoadLevel("Lose");
		}
		else{
			ball.restartBall();
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		
		print ("Collision");
	}
}
