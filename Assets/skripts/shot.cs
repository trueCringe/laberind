using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject fireBall;
    public bool canShot = true;
    public float reloadTime = 1.5f;
    public GameManager gameManager;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShot==true)
        {
            canShot = false;
            gameManager.canonBallSound.Play();
            Instantiate(fireBall, transform.position, transform.rotation);
            StartCoroutine(Reload());
        }
    }
    private IEnumerator Reload()
    {
        Debug.Log("relouding" + reloadTime + "sekonds");
        yield return new WaitForSeconds(reloadTime);
        canShot = true;
        Debug.Log("reload finish");
    }
}
 