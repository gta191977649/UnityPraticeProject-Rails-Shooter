using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField] GameObject dealthFx;
	[SerializeField] Transform parent;
	// Use this for initialization
	private BoxCollider collider;

	ScoreBoard scoreBoard;
	void Start () {
		//Setup
		collider = gameObject.AddComponent<BoxCollider>();
		collider.isTrigger = false;
		scoreBoard = FindObjectOfType<ScoreBoard>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnParticleCollision(GameObject other) {
	
		GameObject fx = Instantiate(dealthFx,transform.position,Quaternion.identity);
		fx.SetActive(true);
			
		fx.transform.parent = parent;
		Destroy(gameObject);

		scoreBoard.scoreHit();
	}
}
