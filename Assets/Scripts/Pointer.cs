using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private CoinGenerator _coinGenerator;
    [SerializeField] private Transform _targetPos;

    private Coin ClossetCoin;

    private Vector3 _toTartget;
    private Vector3 _toTargetXZ;

    private void Update()
    {
        transform.position = _targetPos.position;

        ClossetCoin = _coinGenerator.GetClosset(transform.position);

        _toTartget = ClossetCoin.transform.position - transform.position;
        _toTargetXZ = new Vector3(_toTartget.x, 0.0f, _toTartget.z);

        transform.rotation = Quaternion.LookRotation(_toTargetXZ);
    }
}
