using System.Collections.Generic;
using UnityEngine;

public class CameraCentr : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRB;

    private List<Vector3> _velocityList = new List<Vector3>();
    private int _velocityListCount = 10;
    private Vector3 _summVel;

    private void Start()
    {
        for (int i = 0; i < _velocityListCount; i++)
        {
            _velocityList.Add(Vector3.zero);
        }
    }

    private void Update()
    {
        _summVel = Vector3.zero;
        for (int i = 0; i < _velocityList.Count; i++)
        {
            _summVel += _velocityList[i];
        }

        transform.position = _playerTransform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_summVel), Time.deltaTime * 10.0f); 
    }

    private void FixedUpdate()
    {
        _velocityList.Add(_playerRB.velocity);
        _velocityList.RemoveAt(0);
    }
}
