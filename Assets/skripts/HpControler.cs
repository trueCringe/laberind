using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpControler : MonoBehaviour
{
    public Slider slider;
    public GameManager gameManager;
    void Update()
    {
        slider.value = gameManager.hp;
    }
}
