using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour {

	public Button NewGameButton;
	public Canvas MainMenuCanvas;
	public Canvas GameCanvas;

	// Use this for initialization
	void Start () {
		MainMenuCanvas.enabled = true;
		GameCanvas.enabled = false;
		NewGameButton.onClick.AddListener (newGameClicked);
	}

	void newGameClicked()
	{
		GameCanvas.enabled = true;
		MainMenuCanvas.enabled = false;
	}
}
