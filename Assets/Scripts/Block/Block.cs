using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice;
    private int _alreadyFilled;

    public int LeftToFill => _destroyPrice - _alreadyFilled;

    public UnityAction<int> FillUpdate;

    private void Start()
    {
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);

        FillUpdate?.Invoke(_destroyPrice);
    }

    public void Fill()
    {
        _alreadyFilled++;

        FillUpdate?.Invoke(LeftToFill);
        if(_alreadyFilled == _destroyPrice)
        {
            Destroy(gameObject);
        }
    }
}
