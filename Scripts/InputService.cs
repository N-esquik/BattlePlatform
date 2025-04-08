using UnityEngine;

public static class InputService
{
    public static KeyCode KeySpace = KeyCode.Space;
    public static KeyCode KeyR = KeyCode.R;

    public static bool SetKeyCode(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}
