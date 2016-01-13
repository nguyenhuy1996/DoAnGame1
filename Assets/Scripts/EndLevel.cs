using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			levelManager.MapGenerate();
		}
	}
}
