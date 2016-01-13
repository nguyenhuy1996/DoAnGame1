using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerRun : MonoBehaviour {
	private  float speed;  // Toc do cua Player
	private Animation ani;   // Thanh phan add Animation
	private int  distance;  // Khoang cach dich chuyen giua cac trang thai 1,2,3
	private int  isKich;  //Bien check cho Player chi trong 3 trang thai 1,2,3

	public float jumpForce;  // Do nhay cao cua Player
	private bool checkJump;
	private bool turn;
	private bool checkKill;
	private int choose;
	private float timekill;
	public float speedMax, speedMin;
	public static bool isSpeedMax;
	public static bool isGravity; //kiem tra luc hut Diamond
	private GameManager gameManager;
	//-----
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;
	Vector3 offset;
	public TouchPhase t;
//	public float speed;
//	public float jumpForce;
	public static int distancePlayer; //do khoang cach
	public Transform pointStart;
	private float speedCurrent;
	private int since;
	public static bool isDie;
	public static float timeDie=0f;
	// bien check Neu o mat dat thi duoc nhay, va Chi duoc nhay 1 buoc
	// Use this for initialization
	private AudioSource audioSource;
	public AudioClip audioClip;
	void Start () {
		ani = GetComponent <Animation> ();
		distance = 3;
		isKich = 2; 
//		ani.Play ("idle");
		turn = false;
		GetComponent<Rigidbody> ();
		checkKill = false;
		choose = 1;
		checkJump = false;
		isGravity = false;
		gameManager = FindObjectOfType<GameManager> ();

		offset = new Vector3 (5.0f, 0.0f, 0f);
		speed = speedMin;
		isSpeedMax = false;
		speedCurrent = speed;
		since = 1500;
		isDie = false;


	}
 	void Update() //Neu dat trong ham FixedUpdate() thi chi dich chuyen duoc 2 buoc
	{
		if (!isDie) {
			Running ();
			if (  checkJump == true) { //checkjump= true tuc la dang o mat dat
				ani.Play ("run");
			}

			Swipe ();
			distancePlayer = Mathf.FloorToInt (transform.position.z - pointStart.position.z);
			if (speed != 0f && speed != speedMax) {
				speedCurrent = speed;
			}
			if (distancePlayer > since && speed < 20f) {
				speed = speed + 2.0f; 
				since += 1500;
			}
			if (transform.position.y < -10f) {
				isDie = true;
				Die ();
			}
		}
		if (timeDie > 0f)
			timeDie -= Time.deltaTime;
	}

	//--end UPdate();
	public void Swipe()
	{
		if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);
				
				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
				
				//normalize the 2d vector
				currentSwipe.Normalize();
				
				//swipe upwards
				if(currentSwipe.y > 0 &&  currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
				{
					//moveUp();
					if (checkJump==true){
						Jump();
						Debug.Log("up swipe");
					}
				}
				//swipe down
				if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
				{
				//	Debug.Log("down swipe");
				}
				//swipe left
				if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					moveLeft();
				//	Debug.Log("left swipe");
				}
				//swipe right
				if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
				{
					moveRight();
					//Debug.Log("right swipe");
				}
			}
		}
	}
	void moveLeft()
	{
		if (isKich == 3 || isKich == 2)  {
			Vector3 newPosLeft = new Vector3 (transform.position.x - distance, transform.position.y, transform.position.z+2f);
		//	transform.position = Vector3.Lerp (transform.position, newPosLeft, 1.0f);
		//	MoveObject(gameObject.transform, transform.position, newPosLeft, 3.0f);
			StartCoroutine(MoveObject(transform,transform.position, newPosLeft, 0.2f));
			isKich = isKich - 1;

	}
	}
	void moveRight()
	{
		if (isKich == 1 || isKich == 2) {
				Vector3 newPosRight = new Vector3 (transform.position.x + distance, transform.position.y, transform.position.z+2f);
				//transform.position = Vector3.Lerp (transform.position, newPosRight, 1.0f);
			StartCoroutine(MoveObject(transform,transform.position, newPosRight, 0.2f));
				isKich = isKich + 1;
			}

	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Floor") {
			checkJump = true;
				Debug.Log (" check jump "+ checkJump);
		}
		if (isSpeedMax == false && isDie ==false) {
			if (col.gameObject.tag == "Obstacle") {
				isDie = true;
				Die ();
			}
		} else 
			if (col.gameObject.tag=="Obstacle")
				col.gameObject.SetActive(false);
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Magnet") {
			isGravity = true;
			Destroy (col.gameObject);
			gameManager.startGravity();
		}
		if (col.gameObject.tag == "Gas") {
			col.gameObject.SetActive(false);
			speed=speedMax;
			gameManager.startSpeedMax();
			//Debug.Log(speed+"speedcurrent");
			isSpeedMax = true;
		}
//		if (col.gameObject.tag == "coin") {
//			audioSource.PlayOneShot(audioClip,0.5f);
			//---
		}
	

	void Running()
	{
		transform.position =new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
	}
	void Jump()
		{
			gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(0.0f, jumpForce , 0.0f));
			checkJump=false;
		Debug.Log("checkjum " + checkJump);
			int k = Random.Range(1,3);
			if (k==1) ani.Play("jump");
			if (k==2) ani.Play("flip");
		}
	void Die()
	{

		checkJump = false;
		Debug.Log ("die");
		ani.Play ("death");
		speedZero();
		timeDie = 2f;
		if (GameManager.score > GameManager.highScore)
			PlayerPrefs.SetInt ("highScoreKey", GameManager.score);
		else
			PlayerPrefs.SetInt ("highScoreKey", GameManager.highScore);
		if (distancePlayer > GameManager.highDistance)
			PlayerPrefs.SetInt ("highDistanceKey", distancePlayer);
		else 
					PlayerPrefs.SetInt("highDistanceKey", GameManager.highDistance);
		//Time.timeScale = 0.0f; // dung man hinh
		PlayerPrefs.Save ();
		//gameManager.backToHome ();
	}

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
	public void stopSpeedMax()
	{
		speed = speedCurrent;
	//	Debug.Log (speed + "stop");
	}
	public void speedZero()
	{
		speed = 0f;
	}
	public void loadSpeedCurrent()
	{
		if (isDie == false) {
			speed = speedCurrent;
			isSpeedMax = false;
		}
	}
}
