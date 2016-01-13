using UnityEngine;
using System.Collections;

public class CoinInto : MonoBehaviour {
	public float distance = 5.0f;
	private Transform playerTransform;
	public float coinSpeed = 5.0f;
	private Transform Obj;
	
	// Use this for initialization
	void Start () {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (Vector3.Distance (playerTransform.position, transform.position)) < distance && PlayerRun.isGravity ==true	) {
			{
				Obj = playerTransform;
				transform.position = Vector3.MoveTowards (transform.position, 
			                                          Obj.position, Time.deltaTime * coinSpeed);
			}

		}
	}
	//ham tra ve tap hop cac diem vecto3 co huong ve trong tam cua player
}