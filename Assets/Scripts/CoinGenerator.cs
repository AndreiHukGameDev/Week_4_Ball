using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Text _countText;

    private float _rangPos = 25.0f;
    private Vector3 _positionSpawnCoin;
    private int _coinIndex = 20;
    private List<Coin> _coinsList = new List<Coin>();

    private void Start()
    {
        CreateCoin();
    }

    public void CollectionCoin(Coin coin)
    {
        _coinsList.Remove(coin);
        Destroy(coin.gameObject);
        UpdateText();
    }
    public Coin GetClosset(Vector3 point)
    {
        float minDis = Mathf.Infinity;
        Coin closedCoin = null;
        for (int i = 0; i < _coinsList.Count; i++)
        {
            float distance = Vector3.Distance(point, _coinsList[i].transform.position);
            if (distance < minDis)
            {
                minDis = distance;
                closedCoin = _coinsList[i];
            }
        }
        return closedCoin;
    }

    private void CreateCoin()
    {

        for (int i = 0; i < _coinIndex; i++)
        {
            _positionSpawnCoin = new Vector3(
                Random.Range(-_rangPos, _rangPos), 
                0.0f, 
                Random.Range(-_rangPos,_rangPos));

            GameObject newCoin = Instantiate(_coinPrefab, _positionSpawnCoin, Quaternion.identity,transform);
            _coinsList.Add(newCoin.GetComponent<Coin>());
        }
        UpdateText();
    }
    private void UpdateText()
    {
        _countText.text = $"You need find {_coinsList.Count.ToString()} coin(s)";
    }
}
