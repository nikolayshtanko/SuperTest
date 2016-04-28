using UnityEngine;

public class SpawnObject : MonoBehaviour
{
	void Start()
    {
        Destroy(gameObject, 1f);
	}
}
