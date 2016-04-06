using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AssemblyCSharp;

public class GameGridButton : MonoBehaviour {
	
	public ToolHandler toolHandler;
	private ITool assignedTool;
	private Image baseImage;
	private Image currentImage;

	// Use this for initialization
	void Start () {
		GetComponentInParent<Button> ().onClick.AddListener (GridButtonClicked);
		baseImage = GetComponentInParent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GridButtonClicked() {
		assignedTool = toolHandler.SelectedTool;

		var toolImage = toolHandler.ToolImage;
		if (toolImage != null) {
			GetComponentInParent<Image>().overrideSprite = toolImage.sprite;
		} else {
			GetComponentInParent<Image>().overrideSprite = baseImage.sprite;
		}
	}
}
