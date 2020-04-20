using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothVector;
    public float horizontalSensitivity = 5.0f;
    public float verticallSensitivity = 5.0f;
    public float smoothing = 2.0f;
    GameObject character;
    public bool enable = true;

    // Start is called before the first frame update
    void Start()
    {
        mouseLook = new Vector2(0, -transform.eulerAngles.x);
        character = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mouseDelta = Vector2.Scale(mouseDelta, new Vector2(horizontalSensitivity * smoothing, verticallSensitivity * smoothing));

            smoothVector.x = Mathf.Lerp(smoothVector.x, mouseDelta.x, 1f / smoothing);
            smoothVector.y = Mathf.Lerp(smoothVector.y, mouseDelta.y, 1f / smoothing);
            mouseLook += smoothVector;
            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right); //Rotate the camera Verically
            character.transform.Rotate(0, mouseLook.x, 0, Space.Self); //Rotate the player Horizontally
            mouseLook.x = 0;
        }
    }
}
