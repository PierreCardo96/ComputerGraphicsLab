using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectHit : MonoBehaviour
{
    [SerializeField]
    Slider healthBar;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        healthBar.value -= 0.2f;
        if(healthBar.value <= 0)
        {
            animator.SetBool("isDead", true);
            FindObjectOfType<CameraMouseLook>().enable = false;
        }
    }
}
