using UnityEngine;

public class TrackCamera : MonoBehaviour
{
    [SerializeField]
    Transform _rootCar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 _offset = new Vector3(-5.62000179f, 9.84000111f, 1.8500005f);
    private Quaternion _rotationOffset ;
    void Start()
    {
        gameObject.transform.position = new Vector3(-5.62000179f, 9.84000111f, 1.8500005f);
        _rotationOffset = _rootCar.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        _offset = _rootCar.position + new Vector3(0.50599957f, 22.8736038f, -20.5288086f);
        gameObject.transform.rotation =  _rotationOffset * Quaternion.Euler(50, 60, 0);
        gameObject.transform.position = _offset;
    }
}
