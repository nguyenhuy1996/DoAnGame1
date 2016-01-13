using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	private Vector3 offset;
	public Transform targer; // khai bao kieu tranform do chi can lay dia chi
	public float smoothing;

	// Use this for initialization
	void Start () {
		offset = transform.position - targer.position;

	}


	void FixedUpdate()
	{

		Vector3 newPos = targer.position + offset;
		transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * smoothing);
		//transform.position = targer.position + offset;
	}

	// Update is called once per frame
	
}
