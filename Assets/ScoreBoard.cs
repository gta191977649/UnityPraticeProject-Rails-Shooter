using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour {

	int score;
	Text scoreLabel;
	[SerializeField] int scorePerHit = 12;
	// Use this for initialization
	void Start () {
		scoreLabel = GetComponent<Text>();
		scoreLabel.text = score.ToString();
	}
	
	public void scoreHit(){
		score += scorePerHit;
	}
	// Update is called once per frame
	void Update () {
		scoreLabel.text = score.ToString();
	}
}
