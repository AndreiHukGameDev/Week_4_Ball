using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CoinGenerator _coinGenerator;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _cameraCentr;
    [SerializeField] private float _torqueSpeed = 5.0f;

    private float _horizontalInput;
    private float _verticalInput;

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _rigidbody.AddTorque(-_cameraCentr.forward * _horizontalInput * _torqueSpeed);
        _rigidbody.AddTorque(_cameraCentr.right * _verticalInput * _torqueSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        _coinGenerator.CollectionCoin(other.GetComponent<Coin>());
    }
}
