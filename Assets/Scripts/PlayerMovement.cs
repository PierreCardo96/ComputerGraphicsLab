using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 2;

    private PlayerAnimator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    public void ProcessTranslation()
    {
        float verticalTranslation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontalTranslation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(horizontalTranslation, 0, verticalTranslation);

        UpdateAnimation(verticalTranslation, horizontalTranslation);
    }

    private void UpdateAnimation(float verticalTranslation, float horizontalTranslation)
    {
        if (verticalTranslation > 0)
        {
            playerAnimator?.UpdatePlayerState(PlayerState.RunningForward);
        }
        else if(verticalTranslation < 0)
        {
            playerAnimator?.UpdatePlayerState(PlayerState.RunningBackward);
        }
        else
        {
            playerAnimator?.UpdatePlayerState(PlayerState.Idle);
        }
    }
}
