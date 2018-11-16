using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
	
	private void Awake() {
		int numofMusic = GameObject.FindObjectsOfType<MusicPlayer>().Length;
		GameObject activeMusic = gameObject;
		if(numofMusic > 1) {
			GameObject music = GameObject.Find("Music");
			if(music.GetComponent<AudioSource>().clip != activeMusic.GetComponent<AudioSource>().clip) {
				activeMusic = gameObject;
				Destroy(music);
			} else {
				activeMusic = music;
				Destroy(gameObject);
			}
		} 
		DontDestroyOnLoad(activeMusic);
		
		
	}
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	}
}
