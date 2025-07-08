using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;
    [SerializeField] AudioClip laserBeamSFX;

    AudioSource audioSource;
    bool isFiring = false;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
    }
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }



    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;

        if (Input.GetMouseButton(0))    //checking if left mouse button is pressed
        {
            audioSource.PlayOneShot(laserBeamSFX);
        }


    }
    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;   //emission variable is technically ParticleSystem.EmissionModule type
            emissionModule.enabled = isFiring;
        }
    }
    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    private void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;    //subtracting 2 vector3's to get the direction of where the lasers need to be fired
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;    //changing the rotation of the laser GameObjects to the targetPoint's position
        }
    }
}
