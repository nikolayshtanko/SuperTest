using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;

    private Transform _transform;
    private float _time = 0f;

    void Start()
    {
        _transform = transform;
        spawn.SetActive(false);
    }

	void Update()
    {
        if (_time <= 0f) {
            GameObject obj = Instantiate(spawn, _transform.position, _transform.rotation) as GameObject;
            obj.SetActive(true);
            _time = 0.4f;
        }
        _time -= Time.deltaTime;
	}
}
