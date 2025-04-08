using UnityEngine;

public class SpawnerAura : MonoBehaviour
{
    public GameObject Create(GameObject prefab,Transform transform)
    {
        return Instantiate(prefab, transform.position, Quaternion.identity);
    }
}