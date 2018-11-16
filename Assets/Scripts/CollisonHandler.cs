using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour {

	[SerializeField] float levelLoadDelay = 1f;
	[SerializeField] GameObject dealthFX;
	// Use this for initialization
	
	void Start () {
		
	}
	void Update () {
	}
	void startDealthSequence() {
		Debug.Log("GAME OVER");
		SendMessage("OnPlayerDealth");
	}
	void OnTriggerEnter(Collider other) {
		startDealthSequence();
		boomFX();
		Invoke("reloadLevel",levelLoadDelay);
	}
	void boomFX(){
		GameObject boom = Instantiate(dealthFX,transform.position,Quaternion.identity);
		boom.SetActive(true);
	}
	
	private void reloadLevel(){
		SceneManager.LoadScene(1);
	}
}
