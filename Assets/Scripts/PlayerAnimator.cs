using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimator : MonoBehaviour
{
    public PlayerState playerState = PlayerState.Idle;
    private Animator animator;
    private Camera camera;

    public Vector3  offsetFromCollider =  new Vector3(-0.53f, -1.83f, 3.15f);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        camera = Camera.main;
    }

    public void Update()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, camera.transform.localEulerAngles.y, camera.transform.localEulerAngles.z);
        transform.localPosition = camera.transform.localPosition + offsetFromCollider;
    }
    public void UpdatePlayerState(PlayerState state)
    {
        playerState = state;
        switch (playerState)
        {
            case PlayerState.Walking:
                print("Walking");
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", false);
                break;

            case PlayerState.Running:
                print("Running");
                animator.SetBool("isRunning", true);
                break;
            default:
                print("Idle");
                animator.SetBool("isWalking", false);
                animator.SetBool("isRunning", false);
                break;
        }
    }
}
