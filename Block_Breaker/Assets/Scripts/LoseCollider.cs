using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public LevelManager levelManager;
	
	// Trigger detection
	void OnTriggerEnter2D (Collider2D trigger) {
		print ("Trigger");
		levelManager.LoadLevel("Win Scene");
	}
	
	// Collision detection
	void OnCollisionEnter2D (Collision2D collision) {
		print ("Collision");
	}
}
