using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LifeCounter : MonoBehaviour {
	public Text text;
	// Use this for initialization
	void Start () {
		text.text = "Lives: " +Ball.ballLife;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Lives: " +Ball.ballLife;
	}
}
