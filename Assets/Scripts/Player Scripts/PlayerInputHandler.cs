using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttacking playerAttacking;
    private MouseMovement mouseMovement;
    private PowersHotkey powersHotkey;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttacking = GetComponent<PlayerAttacking>();
        mouseMovement = GetComponentInChildren<MouseMovement>();
        powersHotkey = GetComponent<PowersHotkey>();
    }

    public void RespondToInput()
    {
        playerMovement.RespondToTranslationInput();
        playerAttacking.RespondToAttackingInput();
        mouseMovement.RespondToMouseMovement();
        powersHotkey.RespondToHotKey();

        //RaycastHit hitInfo;
        //float smooth = 1f;
        //GameObject x = GetComponent<Player>().gameObject;
        //Ray ray = new Ray(x.transform.position, -x.transform.up);
        //if (Physics.Raycast(ray, out hitInfo))
        //{
        //    print("Ground it");
        //    Quaternion target = Quaternion.FromToRotation(x.transform.up, hitInfo.normal) * x.transform.rotation;
        //    x.transform.rotation = Quaternion.Lerp(x.transform.rotation, target, Time.deltaTime * smooth);
        //}
    }
}
