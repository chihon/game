using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_collect_alphabet : MonoBehaviour {
	//public UnityEngine.UI.Text msg;
	private string alphabetChar;
	private string alphabetCharCopy; // to avoid race condiciton

	private Dictionary<string, int> charCount;
	private List<string> allStrs;

    public string abilityButtonAxisName = "Fire1";
    public Image darkMask;
    public Text lockText;

    private Image myButtonImage;
    private bool abilityLock;
    private float nextReadyTime;
    private float coolDownTimeLeft;
    private List<Sprite[]> currentTexture;
    List<string> spriteList;
    //Sprite[] sprites;
    //Mage atk
    private MageATKManager MageATK;
	private WarrATKManager WarrATK;
	private GunATKManager GunATK;
    private Texture tempTexture;
    private int maxWeight;

    // Use this for initialization
    void Start () {
		alphabetChar = "";
		charCount = new Dictionary<string, int>();
        allStrs = new List<string>();
        currentTexture = new List<Sprite[]>();
        
        MageATK = GetComponent<MageATKManager> ();
        allStrs = MageATK.abilityList;
        maxWeight = MageATK.maxLength;
        currentTexture = emptySpriteList(maxWeight);
        //Debug.Log("CurrentTexture: " + currentTexture.Count);
        //sprites  = Resources.LoadAll<Sprite>("AlphaList");
        
        /**
        foreach (Sprite s in sprites)
        {
            spriteList.Add(s.name);
            //Debug.Log(s.name + " : " + spriteList.IndexOf(s.name));
        }
        **/
       // Debug.Log("AllStrs's Count: " + allStrs.Count);
       /**
        for (int i = 0; i < allStrs.Count; i++)
        {
            //Debug.Log("AllStrs[" + i + "]: " + allStrs[i]);
            currentTexture.Add(getMappingImage(allStrs[i], maxWeight));
            //Debug.Log("CT Lengthe: " + currentTexture[i].Length);
        }
        **/
        GameObject go = GameObject.Find("AbilityPanel");
        Image[] sr = go.GetComponentsInChildren<Image>();
        sr[0].sprite = CreateNewAbilitySprite();
    }

    private List<Sprite[]> emptySpriteList(int maxWeight)
    {
        //Debug.Log("maxWeight: " + maxWeight + " allStrs: " + allStrs.Count);
        List<Sprite[]> emptySpriteList = new List<Sprite[]>();
        for (int i = 0; i < allStrs.Count; i++)
        {
            emptySpriteList.Add(getMappingImage("", maxWeight));
        }
        return emptySpriteList;
    }

    /**
    void OnGUI () {
		int height = 40;
		int width = 100;
		int X = 1500;
		int Y = 750;
//        GUI.DrawTexture(new Rect(0.0f, 0.0f, tempTexture.width, tempTexture.height), tempTexture);
        GameObject go = GameObject.Find("AbilityPanel");
        Image[] sr = go.GetComponentsInChildren<Image>();
        for (int i = 0; i < allStrs.Count; i++) {
            bool GUIButtonRet;
			if (checkString(allStrs[i])) {
                //Debug.Log(" Current Length: " + currentTexture.ToString());
                //原先是用來 查看按鈕是否被按: 這塊要取代掉，改成在按下攻擊按鈕的地方去扣掉
				if (GUIButtonRet) {
					print (s + " is clicked");
					for (int j = 0; j < allStrs [i].Count; j++) {
						charCount [allStrs [i] [j]] -= 1;
					}
					//do effects
					myEffect(allStrs[i]);
                }
                } else {
				//GUI.color = Color.black;
				//GUIButtonRet = GUI.Button (new Rect (X, Y, width, height), allStrs[i]);
               //              sr[0].sprite = s;
            }
			Y += height;
		}
	}
    **/

    Sprite[] getMappingImage(string input, int maxLength)
    {
        Sprite[] contentArray = new Sprite[maxLength];
        try { 
        //Debug.Log("In getMappingImage: " + input + " : " + input.Length);    
        for(int i = 0; i < input.Length; i++)
        {
            // Debug.Log("Input: " + input[i]);
            //contentArray[i] = sprites[ spriteList.IndexOf(input[i].ToString())];
            contentArray[i] = Resources.Load<Sprite>("alpha/"+input[i].ToString());
            //Debug.Log(contentArray[i].name + " w: " + contentArray[i].rect.width + " h: " + contentArray[i].rect.height);
        }
        //Debug.Log("ContentArray before length: " + contentArray.Length);
        if (input.Length < maxLength)
        {
            for(int i = input.Length; i < maxLength; i++)
            {
                //contentArray[i] = sprites[17];
                contentArray[i] =  Resources.Load<Sprite>("alpha/NULL");
            }
        }
        }
        catch(Exception e)
        {
            Debug.Log(e.StackTrace);
        }
        return contentArray;
        //Debug.Log("ContentArray after length: " + contentArray.Length);

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
		if (listStringIdentical (code, new List<string> { "F", "L", "A", "S","H" })) {
			//bm.rb.AddForce (bm.jumpForceVec * 10.0f, ForceMode.Impulse);
			print ("Flash done");
        }
	}
	
	// Update is called once per frame
	void Update () {
        bool isChanged = false;
        alphabetCharCopy = alphabetChar;
        if (alphabetCharCopy != "")
        {
            //這邊紀錄目前字母數量 && 加上是否有被改變的 flag
            alphabetChar = "";
            if (!charCount.ContainsKey(alphabetCharCopy))
            {
                charCount.Add(alphabetCharCopy, 1);
                isChanged = true;
            }
            if (charCount.ContainsKey(alphabetCharCopy))
            {
                charCount[alphabetCharCopy] += 1;
                isChanged = true;
            }   
        }
        if (isChanged) { 
            currentTexture = new List<Sprite[]>(allStrs.Count);
            //Debug.Log("Allstrs: " + allStrs.Count);
            for (int i = 0; i < allStrs.Count; i++)
            {
                //Debug.Log("i: " +i + " : " + allStrs.Count);
                if (checkString(allStrs[i]))
                {
                    currentTexture.Add(getMappingImage(allStrs[i], maxWeight));
                }
                else
                {
                    currentTexture.Add(getMappingImage("", maxWeight));
                }
            }
            GameObject go = GameObject.Find("AbilityPanel");
            Image[] sr = go.GetComponentsInChildren<Image>();
            sr[0].sprite = CreateNewAbilitySprite();
        }

        List<bool> skillAvalible = new List<bool>();

        //foreach(Sprite[] s in currentTexture)
        for (int i = 0; i < currentTexture.Count; i++)
        {
            int counter = 0;
            for (int j = 0; j < currentTexture[i].Length; j++) {
                //Debug.Log("Cur skill word: " + currentTexture[i][j].name + " : " + counter);
                if (currentTexture[i][j].name != "NULL")
                {
                   counter++;
                }
            }
            if (counter == allStrs[i].Length)
            {
                skillAvalible.Add(true);
            }
            else
            {
                skillAvalible.Add(false);
            }
            //Debug.Log("Skill: " + i + " : " + skillAvalible[i]);
        }
            
        if (skillAvalible[0] && Input.GetKeyDown (KeyCode.Alpha1)) {
			print ("fire is clicked");
			MageATK.ATK1 ();
		}
		if (skillAvalible[1] && Input.GetKeyDown (KeyCode.Alpha2)) {
			print ("wind is clicked");
			MageATK.ATK2 ();
		}
        if (skillAvalible[2] && Input.GetKeyDown (KeyCode.Alpha3)) {
			print ("Ice is clicked");
			MageATK.ATK3 ();
		}
		if (skillAvalible[3] && Input.GetKeyDown (KeyCode.Alpha4)) {
			print ("flash is clicked");
			MageATK.ATK4 ();
		}
    }

	string charsToString (List<string> chars) {
		string charsStr = "";
		for (int i = 0; i < chars.Count; i++) {
			charsStr += chars[i];
		}
		return charsStr;
	}

    bool checkString(string chars)
    {
        //Debug.Log("chars: " + chars + " number of: " + chars.Length);
        Dictionary<string, int> strsCharCount = new Dictionary<string, int>();
        char[] charsArray = chars.ToCharArray();
        //Debug.Log(" split size: " + charsArray.Length + " " + charsArray.ToString());
        for (int i = 0; i < chars.Length; i++)
        {
            if (!strsCharCount.ContainsKey(charsArray[i].ToString()))
            {
                strsCharCount.Add(charsArray[i].ToString(), 0);
            }
            strsCharCount[charsArray[i].ToString()] += 1;
        }
        Dictionary<string, int>.KeyCollection keys = strsCharCount.Keys;
        foreach (string s in keys)
        {
            if (!charCount.ContainsKey(s))
            {
                return false;
            }
        }
        foreach (string s in keys)
        {
            if (charCount[s] < strsCharCount[s])
            {
                return false;
            }
        }
        return true;
    }

    void OnCollisionEnter(Collision coll) {
		// just wait alphabet to write in
	}

    public void SetAlphabetChar(string str)
    {
        this.alphabetChar = str;
    }

    public Sprite CreateNewAbilitySprite()
    {
        //Debug.Log("CT[0].Length: " + currentTexture[0].Length + "CTC: " + currentTexture.Count);
        Texture2D newSkillIcon = new Texture2D(282 * currentTexture[0].Length, 213 * currentTexture.Count, TextureFormat.ARGB32, false);
        int h = 0;
        foreach (Sprite[] texture in currentTexture)
        {
            int w = 0;
            for (int k = 0; k < texture.Length; k++)
            {
                //Debug.Log(texture[k].name + " w: " + texture[k].rect.width + " h: " + texture[k].rect.height);
                //GUI.DrawTexture(new Rect(z, w, 100, 100), texture[k]);
                Color32[] tempTexture = texture[k].texture.GetPixels32();
                //newSkillIcon.SetPixels32(w, h, (int)texture[k].rect.width+1, (int)texture[k].rect.height+1, tempTexture);
                newSkillIcon.SetPixels32(w, h, (int)texture[k].rect.width, (int)texture[k].rect.height, tempTexture);
                w += 282;
            }
            h += 213;
        }
        newSkillIcon.Apply();
        tempTexture = newSkillIcon;
        return Sprite.Create(newSkillIcon, new Rect(0.0f, 0.0f, newSkillIcon.width, newSkillIcon.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}