using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public int hp = 100;
    public int maxhp = 100;
    public AudioSource doorSound;
    public AudioSource winSound;
    public AudioSource loseSound;
    public AudioSource canonBallSound;
    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }
    void Update()
    {
        
    }
    public void RecountHp(int value)
    {
        hp += value;
        Debug.Log(hp + "hp");
        if (hp > maxhp)
        {
            hp = maxhp;
        }
        if (hp <= 0)
        {
            Lose();
        }
    }
    public void Win()
    {
        winPanel.SetActive(true);
        winSound.Play();
        Time.timeScale = 0;
    }
    public void Lose()
    {
        losePanel.SetActive(true);
        loseSound.Play();
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
