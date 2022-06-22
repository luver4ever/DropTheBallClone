using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BlockView : MonoBehaviour
{
    [SerializeField] private Block _block;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _block.FillUpdate += OnFillUpdate;
    }
    private void OnDisable()
    {
        _block.FillUpdate -= OnFillUpdate;
    }

    private void OnFillUpdate(int destroyPrice)
    {
        _text.text = destroyPrice.ToString();
    }
}
