using UnityEngine;

public class UserInput : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    public const KeyCode KeySpace = KeyCode.Space;
    public const KeyCode KeyR = KeyCode.R;

    public float SetHorizontalInput()
    {
        return Input.GetAxis(Horizontal);
    }

    public bool SetKeyCode(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}