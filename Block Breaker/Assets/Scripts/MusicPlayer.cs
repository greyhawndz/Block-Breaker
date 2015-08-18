using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	private static MusicPlayer musicPlayer = null;
	// Use this for initialization
	
	void Awake(){
		
		if(musicPlayer != null){
			Destroy(gameObject);
			print("Duplicate Music Player ded");
		}
		else{
			musicPlayer = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
