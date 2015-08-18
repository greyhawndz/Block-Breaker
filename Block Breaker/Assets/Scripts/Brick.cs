using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] sprites;
	public AudioClip explosion;
	public GameObject smoke;
	public static int breakableCount = 0;
	private LevelManager lvlManager;
	private int timesHit;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		
		isBreakable = (this.tag == "Breakable");
		if(isBreakable){
			breakableCount++;
			
		}
		timesHit = 0;
		lvlManager = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(explosion, transform.position, 0.2f);
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		int maxHits = sprites.Length + 1;
		
		timesHit++;
		if(timesHit >= maxHits){
			breakableCount--;
			Debug.Log(breakableCount);
			lvlManager.BrickDestroyed();
			puffSmoke();
			Destroy(gameObject);
		}
		else{
			LoadSprites();
		}
	}
	
	void puffSmoke(){
		SpriteRenderer color = this.GetComponent<SpriteRenderer>();
		GameObject smokePuff;
		smokePuff = (GameObject)Instantiate(smoke, this.transform.position, Quaternion.identity);
		ParticleSystem smokeColor = smokePuff.GetComponent<ParticleSystem>();
		smokeColor.startColor = color.color;
	}
	
	void LoadSprites(){
		int i = timesHit - 1;
		if(sprites[i] != null){
			this.GetComponent<SpriteRenderer>().sprite = sprites[i];
		}
		else{
			Debug.LogError("Sprite Missingu");
		}
	}
	
	// TODO remove this method once we can actually win
	
	
	
	
	
}
