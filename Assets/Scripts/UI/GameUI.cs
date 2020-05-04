using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    Canvas gameOverCanvas;

    public Canvas GetGameOverCanvas()
    {
        return gameOverCanvas;
    }
}
