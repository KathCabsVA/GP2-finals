using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioClip[] audioClip;

    public AudioSource audioSource;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public GameObject GameOverScreen;

    public GameObject InfoMessage; //ilagay dito yung "shoot all the Mori Calliopes. Press W to proceed"

    //public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        Time.timeScale = 0f; //freezes time

    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        ToStartPressW();
        //add here if condition when enemy prefab collides with player, take damage(1)
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    
    public void ToStartPressW()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            InfoMessage.SetActive(false);
            Time.timeScale = 1f; //starts time
            //sfx
            audioSource.PlayOneShot(audioClip[0]);
        }
    }

    public void GameOver()
    {
        if (currentHealth <= 0)
        {
            
            //prompt the settings-like message that says game over!
            GameOverScreen.SetActive(true);
            Time.timeScale = 0f; //freezes time
            //add a condition to go back to main menu by pressing a Key

            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("Menu");
            }

            else if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneManager.LoadScene("Game");
                Time.timeScale = 1f; //starts time
            }

        }
    }    
}
