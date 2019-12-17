using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    float horizontalThrow, verticalThrow;

    [SerializeField] float speed = 95f;
    [SerializeField] float horizontalRangeView = 70f;
    [SerializeField] float verticalRangeView = 40f;

    [SerializeField] float PitchFactor = -40f;
    [SerializeField] float RollFactor = -50f;
    [SerializeField] float yawFactor = .4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerRotation();
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
