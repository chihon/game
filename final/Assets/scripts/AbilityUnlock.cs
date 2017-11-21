using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityUnlock : MonoBehaviour
{

    public string abilityButtonAxisName = "Fire1";
    public Image darkMask;
    public Text lockText;

    [SerializeField] private Ability ability;
    [SerializeField] private GameObject weaponHolder;
    private Image myButtonImage;
    private bool abilityLock;
    private float nextReadyTime;
    private float coolDownTimeLeft;

    void Start()
    {
        Initialize(ability, weaponHolder);
    }

    public void Initialize(Ability selectedAbility, GameObject weaponHolder)
    {
        ability = selectedAbility;
        myButtonImage = GetComponent<Image>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;
        abilityLock = ability.aBaseLock;
        ability.Initialize(weaponHolder);
        AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        //改成吃到所有的閃電字
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetButtonDown(abilityButtonAxisName))
            {
                ButtonTriggered();
            }
        }
        else
        {
            UnLock();
        }
    }

    private void AbilityReady()
    {
        lockText.enabled = false;
        darkMask.enabled = false;
    }

    private void UnLock()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        lockText.text = roundedCd.ToString();
        darkMask.fillAmount = 0;
    }

    private void ButtonTriggered()
    {
        darkMask.enabled = true;
        lockText.enabled = true;
        ability.TriggerAbility();
    }
}