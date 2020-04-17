using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 6f;

    [SerializeField]
    float smoothTime = 0.15f;

    [SerializeField]
    float rotationSpeed = 80f;

    private Rigidbody rigidbody;
    private PlayerAnimator playerAnimator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        RespondToTranslateInput();
        RespondToRotateInput();
    }

    private void RespondToRotateInput()
    {
        rigidbody.angularVelocity = Vector3.zero;
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationThisFrame);
        }
    }

    private void RespondToTranslateInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float speed = moveSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = moveSpeed * 1.3f;
                playerAnimator?.UpdatePlayerState(PlayerState.Running);
            }
            else
            {
                playerAnimator?.UpdatePlayerState(PlayerState.Walking);
            }

            transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        }
        else
        {
            playerAnimator?.UpdatePlayerState(PlayerState.Idle);
        }
    }
}
