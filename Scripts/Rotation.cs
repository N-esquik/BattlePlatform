using UnityEngine;

public class Rotation : MonoBehaviour
{
    public void Rotate(float direction,int rotationLeft,int rotationRight)
    {
        if(direction < 0)
        {
            SetRotation(rotationLeft);
        }
        else if(direction > 0) 
        {
            SetRotation(rotationRight);
        }
    }

    private void SetRotation(int angle)
    {
        Quaternion rotation = transform.rotation;
        rotation.y = angle;
        transform.rotation = rotation;
    }
}
