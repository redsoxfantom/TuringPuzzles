using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class LevelHandler : MonoBehaviour {

	private List<Level> LoadedLevels;
	int currLevel;

	// Use this for initialization
	void Start () {
		var levels = Resources.LoadAll ("Levels");
		LoadedLevels = new List<Level> ();

		foreach (var level in levels) {
			var rawJson = JSON.Parse(level.ToString());

			Level deserializedLevel = new Level();
			deserializedLevel.ChallangeText = rawJson["ChallangeText"];
			var rawTestStrings = rawJson["TestStrings"].AsArray;
			List<LevelTestString> testStrings = new List<LevelTestString>();
			foreach(var rawTestString in rawTestStrings.Childs)
			{
				string TestString = rawTestString["TestString"].Value;
				bool ShouldPass = rawTestString["ShouldPass"].AsBool;
				LevelTestString deserializedTestString = new LevelTestString();
				deserializedTestString.ShouldPass = ShouldPass;
				deserializedTestString.TestString = TestString;

				testStrings.Add(deserializedTestString);
			}
			deserializedLevel.TestStrings = testStrings.ToArray();

			LoadedLevels.Add(deserializedLevel);
		}

		currLevel = 0;
	}

	public bool TryGetNextLevel(out Level nextLevel)
	{
		if (currLevel < LoadedLevels.Count) {
			nextLevel = LoadedLevels [currLevel];
			currLevel++;
			return true;
		} else {
			nextLevel = null;
			return false;
		}

	}
}

public class Level
{
	public string ChallangeText{get;set;}
	public LevelTestString[] TestStrings{get;set;}
}

public class LevelTestString
{
	public string TestString{ get; set; }
	public bool ShouldPass{ get; set; }
}