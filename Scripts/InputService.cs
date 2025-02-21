using UnityEngine;

public static class InputService
{
    public static KeyCode KeySpace = KeyCode.Space;

    public static bool SetKeyCode(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}
