using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	
	public void LoadLevel(string name){
		Debug.Log("Request load level for: " +name);
		Cursor.visible = true;
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
		
	}
	
	public void QuitRequest(){
		Debug.Log ("Quitting Level");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Brick.breakableCount = 0;
		Ball.ballLife = 3;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){ //if last brick is destroyed
			LoadNextLevel();	
		}
	}
	
	
}
