using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    PlayerHealth playerHealth;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.GetHealth() > 0)
        {
            playerMovement.ProcessTranslation();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

   public float GetHealth()
    {
        return playerHealth.GetHealth();
    }
}
