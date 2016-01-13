using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	private float speedRotation;
	// Use this for initialization
	void Start () {
		speedRotation = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up *speedRotation* Time.deltaTime);
	}
}
