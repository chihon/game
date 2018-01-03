using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ball_collect_alphabet : NetworkBehaviour
{
    //public UnityEngine.UI.Text msg;


    private string alphabetChar;
    private string alphabetCharCopy; // to avoid race condiciton

    [SyncVar]
    public string dictionarySerializedSync;

    private Dictionary<string, int> charCount;

    //public Dictionary<string, int> charCount;
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

    public int forceUIUpdateIntervalLength = 30; // force update UI every interval
    private int UIUpdateCountdown;


    //Sprite[] sprites;
    //Mage atk
    private MageATKManager MageATK;
    private WarrATKManager WarrATK;
    private GunATKManager GunATK;
    private Texture tempTexture;
    private int maxWeight;

    private List<bool> skillAvalible;
    public bool isDead;


    static private string[] StrICE = { "I", "C", "E" };
    static private string[] StrFLASH = { "F", "L", "A", "S", "H" };
    static private string[] StrFIRE = { "F", "I", "R", "E" };
    static private string[] StrWIND = { "W", "I", "N", "D" };




    // FUNCION START
    // ========================================================================================================

    // Use this for initialization
    void Start()
    {
        isDead = false;
        UIUpdateCountdown = forceUIUpdateIntervalLength;
        alphabetChar = "";
        charCount = new Dictionary<string, int>();
        allStrs = new List<string>();
        currentTexture = new List<Sprite[]>();

        MageATK = GetComponent<MageATKManager>();
        allStrs = MageATK.abilityList;
        maxWeight = MageATK.maxLength;
        currentTexture = emptySpriteList(maxWeight);

        for (int i = 0; i < allStrs.Count; i++)
        {
            for (int j = 0; j < allStrs[i].Length; j++)
            {
                string currChar = allStrs[i][j].ToString();
                if (!charCount.ContainsKey(currChar))
                {
                    charCount.Add(currChar, 0);
                    Debug.Log("Word Add To Dic: " + currChar);
                }
            }
        }

        GameObject go = GameObject.Find("AbilityPanel");
        Image[] sr = go.GetComponentsInChildren<Image>();
        sr[0].sprite = CreateNewAbilitySprite();

        skillAvalible = new List<bool>();

        //foreach(Sprite[] s in currentTexture)
        for (int i = 0; i < currentTexture.Count; i++)
        {
            skillAvalible.Add(false);
        }
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


    Sprite[] getMappingImage(string input, int maxLength)
    {
        Sprite[] contentArray = new Sprite[maxLength];
        try
        {
            //Debug.Log("In getMappingImage: " + input + " : " + input.Length);    
            for (int i = 0; i < input.Length; i++)
            {
                // Debug.Log("Input: " + input[i]);
                //contentArray[i] = sprites[ spriteList.IndexOf(input[i].ToString())];
                contentArray[i] = Resources.Load<Sprite>("alpha2/" + input[i].ToString());
                //Debug.Log(contentArray[i].name + " w: " + contentArray[i].rect.width + " h: " + contentArray[i].rect.height);
            }
            //Debug.Log("ContentArray before length: " + contentArray.Length);
            if (input.Length < maxLength)
            {
                for (int i = input.Length; i < maxLength; i++)
                {
                    //contentArray[i] = sprites[17];
                    contentArray[i] = Resources.Load<Sprite>("alpha2/0");
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }
        return contentArray;
        //Debug.Log("ContentArray after length: " + contentArray.Length);

    }

    bool listStringIdentical(List<string> a, List<string> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }

    void myEffect(List<string> code)
    {
        if (listStringIdentical(code, new List<string> { "F", "L", "A", "S", "H" }))
        {
            print("Flash done");
        }
    }

    string DictionaryToStr(Dictionary<string, int> dict)
    {
        string data = "";
        foreach (string key in dict.Keys)
        {
            int val = dict[key];
            data += (key + "," + val.ToString() + "|");
        }
        return data;
    }
    Dictionary<string, int> StrToDictionary(string str)
    {
        Dictionary<string, int> result = new Dictionary<string, int> { };
        string[] pairs = str.Split('|');

        foreach (string pair in pairs)
        {
            if (pair == "")
                continue; // ignore last split
            string[] Columns = pair.Split(',');
            if (Columns.Length < 2)
            {
                Debug.Log("Bad String " + str + " in StrToDicionary");
                return result;
            }
            else
            {
                string key = Columns[0];
                int cnt = int.Parse(Columns[1]);
                if (!result.ContainsKey(key))
                {
                    result.Add(key, cnt);
                }
                else
                {
                    result[key] = cnt;
                    Debug.Log("Duplicate entries, bad string " + str + " in StrToDicionary");
                }
            }
        }
        return result;
    }


    void serializeDictionary()
    {
        dictionarySerializedSync = DictionaryToStr(charCount);
    }
    void unserializeDictionary()
    {
        charCount = StrToDictionary(dictionarySerializedSync);
    }

    [ClientRpc]
    void RpcUnserializeDictionary()
    {
        unserializeDictionary();
    }

    // Update is called once per frame

    bool collectAlphabetUpdate()
    {
        if (isLocalPlayer)
        {
            //Debug.Log("isLocalPlayer=" + dictionarySerializedSync);
        }
        else
        {
            //Debug.Log("notLocalPlayer=" + dictionarySerializedSync);
        }

        if (isServer)
        {
            // server code
            serializeDictionary();
            bool isChanged = false;
            alphabetCharCopy = alphabetChar;
            if (alphabetCharCopy != "")
            {
                //這邊紀錄目前字母數量 && 加上是否有被改變的 flag
                alphabetChar = "";
                charCount[alphabetCharCopy] += 1;
                isChanged = true;
            }
            return isChanged;

        }
        else
        {
            string prevDictSerialized = DictionaryToStr(charCount);
            unserializeDictionary();
            string currDictSerialized = DictionaryToStr(charCount);
            return (currDictSerialized != prevDictSerialized);
        }
    }

    string CheckCurrSkillWordCount(string currSkill)
    {
        string output = "";
        for (int i = 0; i < currSkill.Length; i++)
        {
            string currChar = currSkill[i].ToString();
            try
            {
                if (charCount[currChar] > 0)
                {
                    output += currChar;
                }
                else
                {
                    output += "0";
                }
            }
            catch (Exception e)
            {
                Debug.Log("CurrChar in catch: " + currChar);
                Debug.Log(e.StackTrace);
            }
        }
        return output;
    }

    void skillUIUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        currentTexture = new List<Sprite[]>(allStrs.Count);
        for (int i = 0; i < allStrs.Count; i++)
        {
            currentTexture.Add(getMappingImage(CheckCurrSkillWordCount(allStrs[i]), maxWeight));
        }
        GameObject go = GameObject.Find("AbilityPanel");
        Image[] sr = go.GetComponentsInChildren<Image>();
        sr[0].sprite = CreateNewAbilitySprite();

        skillAvalible = new List<bool>();

        //foreach(Sprite[] s in currentTexture)
        for (int i = 0; i < currentTexture.Count; i++)
        {
            int counter = 0;
            for (int j = 0; j < currentTexture[i].Length; j++)
            {
                //Debug.Log("Cur skill word: " + currentTexture[i][j].name + " : " + counter);
                if (currentTexture[i][j].name != "0")
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
    }

    [ClientRpc]
    void RpcSkillUIUpdate()
    {
        skillUIUpdate();
    }


    void useSkill(int inputKey)
    {
        if (skillAvalible[0] && (inputKey == 49) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //print("fire is clicked");
            CmdUseSkill(StrFIRE);
        }
        if (skillAvalible[1] && (inputKey == 50 )&& Input.GetKeyDown(KeyCode.Mouse0))
        {
            //print("wind is clicked");
            CmdUseSkill(StrWIND);
        }
        if (skillAvalible[2] && (inputKey == 51) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //print("Ice is clicked");
            CmdUseSkill(StrICE);
        }
        if (skillAvalible[3] && (inputKey == 52) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Debug.Log("flash is clicked");
            CmdUseSkill(StrFLASH);
        }
    }

    [Command]
    void CmdUseSkill(string[] skill)
    {
        ServerUseSkill(skill);
    }

    [ClientRpc]
    void RpcRemoveString(string[] skill)
    {
        foreach (string alphabet in skill)
        {
            if (charCount.ContainsKey(alphabet))
            {
                charCount[alphabet] -= 1;
                if (charCount[alphabet] < 0)
                {
                    charCount[alphabet] = 0;
                    Debug.Log("Bad Command, charCount[" + alphabet + "] < 0");
                }
            }
            else
            {
                Debug.Log("Bad Command, no such key " + alphabet);
            }
        }
    }

    static bool stringArrayEqual(string[] a, string[] b)
    {
        if (a.Length != b.Length)
        {
            return false;
        }
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }
        return true;
    }

    void ServerUseSkill(string[] skill)
    {
        // server help check skill
        if (!isServer)
        {
            return;
        }
        else
        {
            PlayerHealth myHealth = this.GetComponent<PlayerHealth>();
            bool goodCmd = true;
            foreach (string alphabet in skill)
            {
                if (charCount.ContainsKey(alphabet))
                {
                    charCount[alphabet] -= 1;
                    if (charCount[alphabet] < 0)
                    {
                        charCount[alphabet] = 0;
                        Debug.Log("Bad Command, charCount[" + alphabet + "] < 0");
                        goodCmd = false;
                    }
                }
                else
                {
                    Debug.Log("Bad Command, no such key " + alphabet);
                    goodCmd = false;
                }
            }
            if (goodCmd)
            {
                if (stringArrayEqual(skill, StrFIRE))
                {
                    myHealth.MageATK1();
                    MageATK.RpcATK1();
                    Debug.Log("FIRE");

                }
                else if (stringArrayEqual(skill, StrWIND))
                {
                    myHealth.MageATK2();
                    MageATK.RpcATK2();
                    Debug.Log("WIND");
                }
                else if (stringArrayEqual(skill, StrICE))
                {
                    myHealth.MageATK3();
                    MageATK.RpcATK3();
                    Debug.Log("ICE");
                }
                else if (stringArrayEqual(skill, StrFLASH))
                {
                    myHealth.MageATK4();
                    MageATK.RpcATK4();
                    Debug.Log("FLASH");
                }
            }
        }

    }

    void Update()
    {
        UIUpdateCountdown--;
        bool isChanged = collectAlphabetUpdate();
        if (!isDead) { 
            if (isChanged || UIUpdateCountdown <= 0)
            {
                UIUpdateCountdown = forceUIUpdateIntervalLength;
                skillUIUpdate();
            }
            if (isLocalPlayer)
            {
                int inputKey = 0;
                if(Input.GetKeyDown( KeyCode.Alpha1))
                        inputKey = 49;
                if (Input.GetKeyDown(KeyCode.Alpha2))
                    inputKey = 50;
                if (Input.GetKeyDown(KeyCode.Alpha3))
                    inputKey = 51;
                if (Input.GetKeyDown(KeyCode.Alpha4))
                    inputKey = 52;
                useSkill(inputKey);
            }
        }
    }

    string charsToString(List<string> chars)
    {
        string charsStr = "";
        for (int i = 0; i < chars.Count; i++)
        {
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

    void OnCollisionEnter(Collision coll)
    {
        // just wait alphabet to write in
    }

    public void SetAlphabetChar(string str)
    {
        this.alphabetChar = str;
    }

    public Sprite CreateNewAbilitySprite()
    {
        //Debug.Log("CT[0].Length: " + currentTexture[0].Length + "CTC: " + currentTexture.Count);
        Texture2D newSkillIcon = new Texture2D(64 * currentTexture[0].Length, 64 * currentTexture.Count, TextureFormat.ARGB32, false);
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
                w += 64;
            }
            h += 64;
        }
        newSkillIcon.Apply();
        tempTexture = newSkillIcon;
        return Sprite.Create(newSkillIcon, new Rect(0.0f, 0.0f, newSkillIcon.width, newSkillIcon.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
}