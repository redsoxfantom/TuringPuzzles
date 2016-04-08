using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameGridHandler : MonoBehaviour {

	public Text challangeText;
	public GameObject gamePanel;
	public GameGridButton gameGridButton;

	private GameGridButton[,] gameGridButtons;
	private LevelHandler levelHandler;
	private ToolHandler toolHandler;
	private Level currLevel;
	private RectTransform gamePanelRect;

	// Use this for initialization
	void Start () {
		levelHandler = GetComponent<LevelHandler> ();
		toolHandler = GetComponent<ToolHandler> ();
		gamePanelRect = gamePanel.GetComponent<RectTransform> ();

		levelHandler.TryGetNextLevel (out currLevel);
		LoadLevel ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadLevel()
	{
		challangeText.text = currLevel.ChallangeText;

		gameGridButtons = new GameGridButton[9,9];
		for(int x = 0; x < 9; x++)
		{
			for(int y = 0; y < 8; y++)
			{
				GameGridButton btn = (GameGridButton)Instantiate(gameGridButton, gamePanelRect.position + new Vector3(x-4.5f,y-3.5f,0), Quaternion.identity);
				btn.transform.SetParent(gamePanel.transform);
				btn.transform.localScale = new Vector3(1f,1f,0f);
				btn.toolHandler = toolHandler;
				gameGridButtons[x,y] = btn;
			}
		}
	}
}
