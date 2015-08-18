using UnityEngine;
using System.Collections;

public class SoundTrigger : MonoBehaviour {
	public AudioClip source;
	private bool hasPlayed = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasPlayed){
		triggerSound();
			hasPlayed = false;
		}
		
		
	}
	
	void triggerSound(){
		hasPlayed = true;
		if(Brick.breakableCount == 60 || Brick.breakableCount == 30 || Brick.breakableCount == 10){
			AudioSource.PlayClipAtPoint(source, transform.position);
		}
	}
}
