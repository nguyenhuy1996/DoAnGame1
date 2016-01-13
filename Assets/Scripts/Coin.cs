using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {
	//public GameObject taget;
	private float speedRotation;
	public float distance = 5.0f;
	private Transform playerTransform;
	public float coinSpeed = 5.0f;

	// Use this for initialization
	void Start () {
//		taget = GetComponent<Rigidbody> ();
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		speedRotation = 100.0f;
	
//		GameManager.timeGravity.text = GameManager.timeGravityValue.ToString ();
	}

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up *speedRotation* Time.deltaTime);
		if (Mathf.Abs (Vector3.Distance (playerTransform.position, transform.position)) < distance && PlayerRun.isGravity ==true	) {
			transform.position = Vector3.MoveTowards (transform.position, 
			                                          playerTransform.position, Time.deltaTime * coinSpeed);
			
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player") {
			GameManager.score++;//Debug.Log("eat");
			Destroy(gameObject);
		}
	}
}
