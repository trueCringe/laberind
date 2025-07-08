using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSens = 5f;
    private CharacterController characterController;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform cameraTransform;
    private float xRotation;
    private float yRotation;
    private bool canTouch = true;
    private float zCooldown = 3f;
    public GameManager gameManager;
    public int damageValue = -34;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * speed * Time.deltaTime);

        if (Input.GetMouseButton(1))
        {
            xRotation -= Input.GetAxis("Mouse Y") * rotationSens;
            xRotation = Mathf.Clamp(xRotation, -60, 60);
            cameraTransform.localEulerAngles = new Vector3(xRotation, 0, 0);
            yRotation = Input.GetAxis("Mouse X") * rotationSens;
            transform.Rotate(Vector3.up, yRotation, 0);
        }
    }
    private IEnumerator Damagecooldown()
    {
        Debug.Log("бессмертие на" + zCooldown + "секунд");
        yield return new WaitForSeconds(zCooldown);
        canTouch = true;
        Debug.Log("бессмертие отключено");
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((hit.gameObject.CompareTag("Zombie")|| hit.gameObject.CompareTag("damageDoor")) &&canTouch == true)
        {
            canTouch = false;
            gameManager.RecountHp(-34);
            StartCoroutine(Damagecooldown());
            Debug.Log("zombie hitet");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("damageDoor") && canTouch == true)
        {
            canTouch = false;
            gameManager.doorSound.Play();
            gameManager.RecountHp(damageValue);
            StartCoroutine(Damagecooldown());
            Debug.Log("Damage door");
        }
        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.Win();
        }
        if (other.gameObject.CompareTag("door"))
        {
            
            gameManager.doorSound.Play();
        }
    }
}