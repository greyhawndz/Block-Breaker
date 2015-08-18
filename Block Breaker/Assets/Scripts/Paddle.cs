using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private float MousePosInBlocks;
	public bool autoPlay = false;
	private Ball ball;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update() {
		if(!autoPlay){
			MoveWithMouse();
		}
		else{
			AutoPlay();
		}
		
	}
	
	void MoveWithMouse(){
		Vector3 PaddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		MousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		PaddlePos.x = Mathf.Clamp(MousePosInBlocks, 0.5f, 15.5f);
		this.transform.position = PaddlePos;
	}
	
	void AutoPlay(){
		Vector3 PaddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		Vector3 ballPos = ball.transform.position;
		PaddlePos.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
		this.transform.position = PaddlePos;
	}
}
