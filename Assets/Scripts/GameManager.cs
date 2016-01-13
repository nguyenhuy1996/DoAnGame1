using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Text ScoreText; //ghi diem
	public static int score=0;
	public static int highScore; // lay xuong diem cao
	//public static int distance=0;  
	public static int highDistance;  //lay xuong distance cao
	public Image timeGravity;  // so hien tho
	private  float timeGravityValue; //thoi gian dem
	//----
	public GameObject resumePanel;
	public  ParticleSystem effectMax;
	//--
	public ParticleSystem effectMagnet;
	public GameObject backPanel;

	// Use this for initialization

	public Text distancePlayerText;
	//---
	private float timeSpeedMax;

	public Image timeSpeedLoad;
	private PlayerRun player;
	/// <summary>
	/// --
	private int timeDelay;
	public Text timeDelayValue;
	private float timer;
	public GameObject timeObject;
	private bool isDelay;

	/// </summary>
	void Start () {
		score = 0;
		timeGravityValue = 0;

		highScore=PlayerPrefs.GetInt ("highScoreKey" ); // lay diem cao magnetSlide = GetComponent<Image> ();
		highDistance=PlayerPrefs.GetInt ("highDistanceKey");
		player = FindObjectOfType<PlayerRun> ();
		//timeGravity = GetComponent<Image> ();
		timer = 0;
		timeDelay = -2;
		isDelay = false;
		backPanel.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		ScoreText.text = score.ToString ();
		if (isDelay == false && PlayerRun.isDie==false) {
			if (timeGravityValue > 0) {		// tut thanh hut ma sat
				timeGravityValue -= Time.deltaTime * 0.05f;
				timeGravity.fillAmount = timeGravityValue;
			} else { 
				PlayerRun.isGravity = false;
				stopGravity ();
				//Debug.Log ("grabity");
			}

			if (timeSpeedMax > 0) { //tang speed len max
				timeSpeedMax -= Time.deltaTime * 0.1f;
				timeSpeedLoad.fillAmount = timeSpeedMax;

			} else {

				player.loadSpeedCurrent ();
				effectMax.Stop ();
				//Debug.Log ("timespeedmax");
			}
		}
		else if (PlayerRun.timeDie < 0) 
			backPanel.SetActive (true);


		
//---------
		if (timeDelay >= 0 && isDelay) {
			timer += Time.deltaTime;
			if (timer > 1) {
				timeDelay--;
				timer = 0;
				timeDelayValue.text = timeDelay.ToString ();
				Debug.Log (timeDelay);
				if (timeDelay < 0) // -1
					isDelay = false;
			}
		} else {
			if (isDelay ==false && timeDelay==-1 ){
				endTimeDelay ();
				timeDelay--;
				Debug.Log("timedelay");
			}
		}
		distancePlayerText.text = PlayerRun.distancePlayer.ToString ();

		//timeResumeValue.text = timeResume.ToString ();
	}
	public void startGravity()
	{
	//	Debug.Log ("ok");
		effectMagnet.Play ();
		timeGravityValue = 1;
	//	Debug.Log ("huy"+timeGravityValue);
		timeGravity.fillAmount = timeGravityValue;
		//Debug.Log (timeGravity);
	}

	public void stopGravity()
	{
		effectMagnet.Stop ();
	//	target.GetComponent<ParticleSystem> ().enableEmission = false;
	}
	public void startSpeedMax()
	{
	
		timeSpeedMax = 1;
		effectMax.Play ();
	}

	public void endTimeDelay()
	{
		timeObject.SetActive (false);
		player.loadSpeedCurrent ();
	}
	//-----
	public void showResume()
	{
		isDelay = true;
		player.speedZero ();
		resumePanel.SetActive (true);
	
	}
	public void hideResume()  //an panel resume
	{
		resumePanel.SetActive (false);
		timeDelay = 4;
		timeObject.SetActive (true);
	}
	public void backToHome()
	{
		Application.LoadLevel ("Home");
	}
	public void NewGame()
	{
	
		Application.LoadLevel ("Game");

	}

}
