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
		currentImage = baseImage;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GridButtonClicked() {
		assignedTool = toolHandler.SelectedTool;

		if (toolHandler.TryGetToolImage (out currentImage)) {
			GetComponentInParent<Image> ().overrideSprite = currentImage.sprite;
		} else {
			GetComponentInParent<Image>().overrideSprite = baseImage.sprite;
		}
	}
}
