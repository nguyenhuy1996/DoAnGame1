using UnityEngine;
using System.Collections;

public class DemoMove : MonoBehaviour {
	public Vector3 pointB;
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
		pointB = transform.position + new Vector3 (2, 0, 0);
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine(MoveObject(transform, transform.position, pointB, 0.5f));
		}
	}

	
//	IEnumerator start()
//	{
//		var pointA = transform.position;
//		pointB = transform.position + new Vector3 (2, 0, 0);
//
//
//	
//			Debug.Log(transform.position);
//			yield return StartCoroutine(MoveObject(transform, pointA, pointB, 0.5f));
//			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
//
//	}
//	
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
	{
		var i= 0.0f;
		var rate= 1.0f/time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

}
