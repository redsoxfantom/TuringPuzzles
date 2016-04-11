using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour {

	public Button TestSolutionButton;
	public Button NewGameButton;
	public Canvas MainMenuCanvas;
	public Canvas GameCanvas;
	public Canvas ResultCanvas;
	public Text ResultHeader;
	public Text ResultMessage;
	public Button ResultButton;
	private GameGridHandler gameHandler;

	// Use this for initialization
	void Start () {
		MainMenuCanvas.enabled = true;
		GameCanvas.enabled = false;
		ResultCanvas.enabled = false;
		gameHandler = GetComponent<GameGridHandler> ();
		NewGameButton.onClick.AddListener (newGameClicked);
		TestSolutionButton.onClick.AddListener (testSolutionClicked);
		ResultButton.onClick.AddListener (resultDismissed);
	}

	void resultDismissed()
	{
		ResultCanvas.enabled = false;
	}

	void testSolutionClicked()
	{
		gameHandler.TestSolution ();
	}

	void newGameClicked()
	{
		GameCanvas.enabled = true;
		MainMenuCanvas.enabled = false;
	}

	public void AlertSuccess()
	{
		ResultHeader.text = "SUCCESS";
		ResultMessage.text = "Congratulations!";
		ResultCanvas.enabled = true;
	}

	public void AlertFailure(string message)
	{
		ResultHeader.text = "FAILURE";
		ResultMessage.text = message;
		ResultCanvas.enabled = true;
	}
}
