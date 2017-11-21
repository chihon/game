using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_collect_alphabet : MonoBehaviour {
	public UnityEngine.UI.Text msg;
	public string alphabetChar;

	private string alphabetCharCopy; // to avoid race condiciton

	private Dictionary<string, int> charCount;
	private List< List<string> > allStrs;
	private ball_move bm;

	// Use this for initialization
	void Start () {
		bm = GetComponent<ball_move> ();
		alphabetChar = "";
		charCount = new Dictionary<string, int>();
		allStrs = new List< List<string> >();
		allStrs.Add (new List<string> { "C", "A", "B" });
		allStrs.Add (new List<string> { "B", "A", "T" });
	}
	void OnGUI () {
		int height = 40;
		int width = 50;
		int X = 10;
		int Y = 10;
		for (int i = 0; i < allStrs.Count; i++) {
			string s = charsToString (allStrs [i]);
			bool GUIButtonRet;
			if (checkString (allStrs [i])) {
				GUI.color = Color.blue;
				GUIButtonRet = GUI.Button (new Rect (X, Y, width, height), s);
				if (GUIButtonRet) {
					print (s + " is clicked");
					for (int j = 0; j < allStrs [i].Count; j++) {
						charCount [allStrs [i] [j]] -= 1;
					}
					//do effects
					myEffect(allStrs[i]);
				}
			} else {
				GUI.color = Color.black;
				GUIButtonRet = GUI.Button (new Rect (X, Y, width, height), s);
			}
			Y += height;
		}
	}
	bool listStringIdentical(List<string> a, List<string> b) {
		if (a.Count != b.Count) {
			return false;
		}
		for (int i = 0; i < a.Count; i++) {
			if (a[i] != b[i]) {
				return false;
			}
		}
		return true;
	}

	void myEffect(List<string> code) {
		if (listStringIdentical (code, new List<string> { "B", "A", "T" })) {
			bm.rb.AddForce (bm.jumpForceVec * 10.0f, ForceMode.Impulse);
		} else if (listStringIdentical (code, new List<string> { "C", "A", "B" })) {
			// speed up
			bm.maxSpeed *= 3.0f;
			bm.Acc *= 1.4f;
			bm.jumpForce *= 1.5f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		alphabetCharCopy = alphabetChar;
		if (alphabetCharCopy != "") {
			alphabetChar = "";
			if (!charCount.ContainsKey (alphabetCharCopy)) {
				charCount.Add (alphabetCharCopy, 0);
			}
			charCount[alphabetCharCopy] += 1;
		}
		string dictInfo = "";
		Dictionary<string, int>.KeyCollection keys = charCount.Keys;
		foreach (string s in keys) {
			if (charCount [s] > 0) {
				dictInfo += (s + ": " + charCount [s].ToString () + " ");
			}
		}
		msg.text = dictInfo;
		//for (int i = 0; i < allStrs.Count; i++) {
			//string s = charsToString (allStrs [i]);
		//}
	}
	string charsToString (List<string> chars) {
		string charsStr = "";
		for (int i = 0; i < chars.Count; i++) {
			charsStr += chars[i];
		}
		return charsStr;
	}

	bool checkString(List<string> chars) {
		Dictionary<string, int> strsCharCount = new Dictionary<string, int>();
		for (int i = 0; i < chars.Count; i++) {
			if (!strsCharCount.ContainsKey (chars [i])) {
				strsCharCount.Add (chars [i], 0);
			}
			strsCharCount [chars [i]] += 1;
		}
		Dictionary<string, int>.KeyCollection keys = strsCharCount.Keys;
		foreach (string s in keys) {
			if (!charCount.ContainsKey (s)) {
				return false;
			}
		}
		foreach (string s in keys) {
			if (charCount[s] < strsCharCount[s]) {
				return false;
			}
		}
		return true;
	}


	void OnCollisionEnter(Collision coll) {
		// just wait alphabet to write in
	}
}
