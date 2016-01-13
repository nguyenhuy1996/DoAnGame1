using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HomeManager : MonoBehaviour {
	private int highScore;
	public Text highScoreValue;
	private int highDistance;
	public Text highDistanceValue;
	private AudioSource aud;
	public Slider audioSize;
	public GameObject optionsPanel;
	private bool checkSpeak;
	// Use this for initialization
	void Start () {
		highScore= PlayerPrefs.GetInt ("highScoreKey");
		highDistance=PlayerPrefs.GetInt ("highDistanceKey");
		highScoreValue.text = highScore.ToString ();
		highDistanceValue.text = highDistance.ToString ();
		aud = GetComponent<AudioSource> ();
		audioSize.value = 1;
		checkSpeak = true;
		aud.volume = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		aud.volume = audioSize.value;
	}
	public void Playgame()
	{
		Application.LoadLevel ("Game");
	}
	public void hideOptionsPanel()
	{
		optionsPanel.SetActive (false);
	}
	public void showOptionsPanel()
	{
		optionsPanel.SetActive (true);
	}
	public void OnOffSpeak()
	{
		if (checkSpeak == true) //da bat
			aud.volume = 0.0f;
		else
			aud.volume = 1.0f;
	}
}
