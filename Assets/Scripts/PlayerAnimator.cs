using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnimator : MonoBehaviour
{   
    [SerializeField]
    Vector3  offsetFromCollider =  new Vector3(0, -2.25f, 2.1f);
    [SerializeField]
    PlayerState playerState = PlayerState.Idle;

    private Animator animator;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    public void Update()
    {
        if (!animator.GetBool("isDead"))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, mainCamera.transform.localEulerAngles.y, mainCamera.transform.localEulerAngles.z);
            transform.localPosition = mainCamera.transform.localPosition + offsetFromCollider;
        }
    }
    public void UpdatePlayerState(PlayerState state)
    {
        playerState = state;
        switch (playerState)
        {
            case PlayerState.RunningForward:
                animator.SetBool("isRunningForward", true);
                animator.SetBool("isRunningBackward", false);
                animator.SetBool("isSprinting", false);
                break;

            case PlayerState.RunningBackward:
                animator.SetBool("isRunningBackward", true);
                animator.SetBool("isRunningForward", false);
                animator.SetBool("isSprinting", false);
                break;
            case PlayerState.Sprinting:
                animator.SetBool("isSprinting", true);
                break;
            default:
                animator.SetBool("isRunningForward", false);
                animator.SetBool("isRunningBackward", false);
                animator.SetBool("isSprinting", false);
                break;
        }
    }
}
