using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;
using System;

public class GameGridHandler : MonoBehaviour {

	public Text challangeText;
	public GameObject gamePanel;
	public GameGridButton gameGridButton;

	private GameGridButton[,] gameGridButtons;
	private LevelHandler levelHandler;
	private ToolHandler toolHandler;
	private Level currLevel;
	private RectTransform gamePanelRect;
	private MainMenuHandler menuHandler;

	// Use this for initialization
	void Start () {
		levelHandler = GetComponent<LevelHandler> ();
		toolHandler = GetComponent<ToolHandler> ();
		gamePanelRect = gamePanel.GetComponent<RectTransform> ();
		menuHandler = GetComponent<MainMenuHandler> ();

		levelHandler.TryGetNextLevel (out currLevel);
		LoadLevel ();
	}

	public void TestSolution()
	{
		bool testWasSuccessful = true;
		string errorMsg = null;

		foreach (var testString in currLevel.TestStrings) {
			Debug.Log(string.Format("Testing String {0}, should pass: {1}",testString.TestString,testString.ShouldPass));

			ToolExecutionStatus status = new ToolExecutionStatus();
			status.TestString = testString.TestString;
			int currBtnX = 4;
			int currBtnY = 7;
			GameGridButton currBtn = gameGridButtons[currBtnX,currBtnY];

			try
			{
				while(status.Status == ToolStatus.NO_STATUS)
				{
					currBtn.ExecuteTool(ref status);
					currBtn = GetNextButton(ref currBtnX, ref currBtnY, status.NextDirection);
				}
			}
			catch (ToolExecutionException ex)
			{
				Debug.Log(String.Format("Tool Exception: {0}",ex.Message));
				status.Status = ToolStatus.ERROR;
				errorMsg = string.Format("Error when executing step {0}x{1} ({2})",currBtnX,currBtnY,ex.Message);
			}
			catch(Exception ex)
			{
				Debug.Log(String.Format("General Exception: {0}",ex.Message));
				status.Status = ToolStatus.ERROR;
				errorMsg = string.Format("Error when executing step {0}x{1} ({2})",currBtnX,currBtnY,ex.Message);
			}

			Debug.Log(string.Format("String test completed with status {0}", status.Status));

			if(!OkToContinue(testString.ShouldPass, status.Status))
			{
				testWasSuccessful = false;
				if(String.IsNullOrEmpty(errorMsg))
				{
					errorMsg = string.Format("String {0} failed testing",testString.TestString);
				}
				break;
			}
		}

		if (!testWasSuccessful) {
			Debug.Log ("Test Failed");
			menuHandler.AlertFailure(errorMsg);
		} else {
			Debug.Log("Test Passed");
			menuHandler.AlertSuccess();

			if(levelHandler.TryGetNextLevel (out currLevel))
			{
				ClearLevel();
				LoadLevel ();
			}
		}
	}

	void ClearLevel()
	{
		for(int x = 0; x < 9; x++)
		{
			for(int y = 0; y < 8; y++)
			{
				GameGridButton btn = gameGridButtons[x,y];
				Destroy(btn);
			}
		}
	}

	bool OkToContinue(bool testShouldHavePassed, ToolStatus testStatus)
	{
		if (testStatus == ToolStatus.ACCEPTED && testShouldHavePassed) {
			return true;
		}
		if (testStatus == ToolStatus.REJECTED && !testShouldHavePassed) {
			return true;
		}
		return false;
	}

	GameGridButton GetNextButton(ref int currBtnX, ref int currBtnY, ToolOutputDirection nextDirection)
	{
		switch (nextDirection) {
		case ToolOutputDirection.DOWN:
			currBtnY--;
			break;
		case ToolOutputDirection.LEFT:
			currBtnX--;
			break;
		case ToolOutputDirection.RIGHT:
			currBtnX++;
			break;
		case ToolOutputDirection.UP:
			currBtnY++;
			break;
		}
		
		return gameGridButtons[currBtnX,currBtnY];
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
