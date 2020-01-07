using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    float horizontalThrow, verticalThrow;
    bool controlEnabled = true;

    [Header("General")]
    [SerializeField] float speed = 95f;
    [Header("Screen Position")]
    [SerializeField] float horizontalRangeView = 70f;
    [SerializeField] float verticalRangeView = 40f;
    [Header("Controll Input")]
    [SerializeField] float PitchFactor = -40f;
    [SerializeField] float RollFactor = -50f;
    [SerializeField] float yawFactor = .4f;

    // Update is called once per frame
    void Update()
    {
        if (controlEnabled)
        {
            playerMovement();
            playerRotation();
        }
    }

    void OnPlayerDeath() //Called by string Reference
    {
        print("Player Died");
        controlEnabled = false;
    }

    public void playerMovement()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float horizontalOffset = horizontalThrow * speed * Time.deltaTime;
        float verticalOffset = verticalThrow * speed * Time.deltaTime;

        float rawHorizontalPos = transform.localPosition.x + horizontalOffset;
        float clampedHorizontalPos = Mathf.Clamp(rawHorizontalPos, -horizontalRangeView, horizontalRangeView);

        float rawVerticalPos = transform.localPosition.y + verticalOffset;
        float clampedVerticalPos = Mathf.Clamp(rawVerticalPos, -verticalRangeView, verticalRangeView);

        transform.localPosition = new Vector3
            (clampedHorizontalPos, clampedVerticalPos, transform.localPosition.z);
    }

    public void playerRotation()
    {
        float pitch = verticalThrow * PitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = horizontalThrow * RollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
