using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class PlayerHealth : NetworkBehaviour
{

    public const int startingHealth = 100;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    neocontrol neocontrol;
    ball_collect_alphabet ball_Collect_Alphabet;

    public static bool isDead;
    bool damaged;

    public GameObject[] players;
    // Use this for initialization
    void Awake()
    {
        isDead = false;
        currentHealth = startingHealth;
        neocontrol = GetComponent<neocontrol>();
        ball_Collect_Alphabet = GetComponent<ball_collect_alphabet>();
        healthSlider = GameObject.FindGameObjectWithTag("Slider").GetComponent<Slider>();
        damageImage = GameObject.FindGameObjectWithTag("SliderImage").GetComponent<Image>();
        //Debug.Log("healthSlider get/not: " + healthSlider);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
        if (!isServer)
        {
            return;
        }
    }
    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        currentHealth -= amount;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void OnChangeHealth(int health)
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //Debug.Log("Health: " + health);
        healthSlider.value = currentHealth;
    }

    void Death()
    {
        Debug.Log("Dead");
        isDead = true;
        neocontrol.isDead = true;
        ball_Collect_Alphabet.isDead = true;
    }

    public void normalAttack()
    {

    }
    public void MageATK1()
    {
        Color myColor = this.GetComponent<SetupLocalPlayer>().playerColor;

        // FIRE gain health
        currentHealth += 5;
    }
    public void MageATK2()
    {
        currentHealth += 10;
    }
    public void MageATK3()
    {
        Color myColor = this.GetComponent<SetupLocalPlayer>().playerColor;
        // ICE: whole game AOE
        players = GameObject.FindGameObjectsWithTag("player");

        Debug.Log("MageATK3");
        Debug.Log("players.Length = " + players.Length.ToString());
        foreach (GameObject player in players)
        {
            Color playerColor = player.GetComponent<SetupLocalPlayer>().playerColor;
            //Debug.Log(playerColor); 
            if (playerColor != myColor)
            {
                player.GetComponent<PlayerHealth>().currentHealth -= 10;
            }
        }
    }
    public void MageATK4()
    {
        currentHealth += 30;
    }
    public void WarrATK1()
    {

    }
    public void WarrATK2()
    {

    }
    public void WarrATK3()
    {

    }
    public void WarrATK4()
    {

    }
    public void GunATK1()
    {

    }
    public void GunATK2()
    {

    }
    public void GunATK3()
    {

    }
    public void GunATK4()
    {

    }
}
