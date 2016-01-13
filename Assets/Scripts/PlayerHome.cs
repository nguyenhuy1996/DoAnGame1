using UnityEngine;
using System.Collections;

public class PlayerHome : MonoBehaviour {
	// Use this for initialization
	private float timer;
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 30.0f)
			timer = 0f;
		if (timer < 5.0f) 
			gameObject.GetComponent<Animation> ().Play ("idle"); 
		if (timer > 5.0f && timer < 10f)
			gameObject.GetComponent<Animation> ().Play ("run");
		if (timer > 10.0f && timer < 15f)		
			gameObject.GetComponent<Animation> ().Play ("idle"); 
		if (timer < 20.0f && timer > 15f)	
			gameObject.GetComponent<Animation> ().Play ("jump");
		if (timer > 20.0f && timer < 25f)		
			gameObject.GetComponent<Animation> ().Play ("idle"); 
		if (timer > 25.0f && timer < 30f)
			gameObject.GetComponent<Animation> ().Play ("flip");
	
	}
}
