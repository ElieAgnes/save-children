using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float hunger = 100.0f;
    [SerializeField] private float enduro = 100.0f;

    [SerializeField] private float healthMax = 100.0f;
    private float hungerMax =0f;
    private float enduroMax = 0f;

    [SerializeField] private Image healthBar = null;
    [SerializeField] private Image hungerhBar = null;
    [SerializeField] private Image enduroBar = null;
    
    [SerializeField] private int kidsTOSave = 3;
    private int savedKids = 0;
    void Start()
    {
        hungerMax = hunger;
        enduroMax = enduro;
    }

    public void Hurt(float damage = 1.0f)
    {
        health -= damage;
    }

    public void Heal(float amount = 1.0f)
    {
        health += amount;
    }

    public void Feed(float amount)
    {
        hunger += amount;
        if(hunger > 100.0f) hunger = 100.0f;
    }

    public void useRun(float deltaTime = 0.0f)
    {
        Debug.Log("Run used");
        // 20 Seconds of run should void enduro
        enduro -= 0.6f * deltaTime;
        // If enduro is lower than 50% The hunger is edited
        if(enduro < 50.0f) hunger -= 0.1f * deltaTime;
    }

    public void useJump()
    {
        // Jump use some enduro
        enduro -= 5.0f;
    }

    public void updateValues(float deltaTime = 0.0f)
    {
        if(hunger < 0.0f) hunger = 0.0f;
        if(enduro < 0.0f) enduro = 0.0f;
        if(hunger > 90.0f)
        {
            // Get full enduro in 100 sec
            enduro += deltaTime;
        }
        if(hunger <= 0.0f)
        {
            // Die in aprox 2.2 min
            health -= 0.8f * deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / healthMax;
        hungerhBar.fillAmount = hungerMax / hunger;    
        enduroBar.fillAmount = enduroMax / enduro;  

        if(health <= 0.0f)
        {
            SceneManager.LoadScene("LoseScreen");
        }
        if(savedKids >= kidsTOSave)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    public void SaveKid()
    {
        savedKids ++;
    }
}
