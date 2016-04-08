using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameGridHandler : MonoBehaviour {

	public Text challangeText;
	private LevelHandler levelHandler;
	private Level currLevel;

	// Use this for initialization
	void Start () {
		levelHandler = GetComponent<LevelHandler> ();
		levelHandler.TryGetNextLevel (out currLevel);
		LoadLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadLevel()
	{
		challangeText.text = currLevel.ChallangeText;
	}
}
