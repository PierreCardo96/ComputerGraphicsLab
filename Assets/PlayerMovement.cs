using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;

    [SerializeField]
    float smoothTime = 0.15f;

    private Vector3 localMoveAmount;
    private Vector3 smoothMoveVelocity;

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
    }

    private void ProcessTranslation()
    {
        Vector3 moveDirection = GetUserMoveDirection();
        Vector3 targetMoveAmount = moveDirection * moveSpeed;
        localMoveAmount = Vector3.SmoothDamp(localMoveAmount, targetMoveAmount, ref smoothMoveVelocity, smoothTime);//Gradually changes a vector towards a desired goal over time.
    }

    private Vector3 GetUserMoveDirection()
    {
        float rawHorizontalInput = Input.GetAxisRaw("Horizontal");
        float rawVerticalInput = Input.GetAxisRaw("Vertical");
        return new Vector3(rawHorizontalInput, 0, rawVerticalInput).normalized;
    }

    private void FixedUpdate()
    {
        MoveObjectInWorld();
    }

    private void MoveObjectInWorld()
    {
        Vector3 worldMoveAmount = transform.TransformDirection(localMoveAmount);
        Rigidbody playerRigidBody = GetComponent<Rigidbody>();
        playerRigidBody.MovePosition(playerRigidBody.position + worldMoveAmount * Time.fixedDeltaTime);//moves the player in world
    }
}
