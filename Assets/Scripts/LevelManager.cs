using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public GameObject[] maps;
	private GameObject initMap;
	private float roadDistance;
	private GameObject map1, map2,map3,temp;

	// Use this for initialization
	void Start () {

		map1 = maps [0];
		map2 = maps [1];
		int mapRandom2 = Random.Range (0, 10);
		map3 = Instantiate (maps[mapRandom2], new Vector3 (map2.transform.position.x
		                                                  , map2.transform.position.y 
		                                                  , map2.transform.position.z+90)
		                    , map2.transform.rotation) as GameObject;   
//		map2 = maps [1]; // player dang udng o day
//		map3 = maps[2];
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void MapGenerate()
	{
		int randomMap = Random.Range (1,  maps.Length);
		GameObject map = maps [randomMap];
		//float offset = map2.transform.FindChild("street90").GetComponent<MeshRenderer> ().bounds.size.z;
		//Debug.Log (offset);
		temp = map3;
		Destroy (map1);
		map3 = Instantiate (map, new Vector3 (map2.transform.position.x
		                                         , map2.transform.position.y 
		                                     , map2.transform.position.z+ 2 * 90)
		                       , map2.transform.rotation) as GameObject;
		//if (map1.gameObject.name.Contains ("Clone"))

		map1 = map2;
		map2 = temp;
	
	}
}

// 1 2 3 4 5
//   sau khi cham col2  2 3 4 5 1
// 1+ offset
// 2 = 1;
// 3= 2;
// 4= 3;
// 1= 4

//map1 A map2 B map3 c
//	map1 A map2 B map3 C mapIns random
