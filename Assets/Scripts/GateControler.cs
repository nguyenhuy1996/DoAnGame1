using UnityEngine;
using System.Collections;

public class GateControler : MonoBehaviour {
	public GameObject target;
	public float speed;
	private float offset;
	// Use this for initialization
	void Start () {
		//target = GetComponent<Transform> ();
		//offset = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		offset = transform.position.z - target.transform.position.z;
		if (offset == 10.0f && transform.position.x > 411.0f)
			open ();

	}
	void open()
	{
		transform.position = new Vector3 (transform.position.x - 2.0f * speed * Time.deltaTime, transform.position.y, transform.position.z);
	}
}
