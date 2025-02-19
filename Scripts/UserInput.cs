using UnityEngine;

public static class UserInput
{
    public const string Horizontal = "Horizontal";

    public static float SetHorizontalInput()
    {
        return Input.GetAxis(Horizontal);
    }
}