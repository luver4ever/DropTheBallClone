using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private int _score;

    public UnityAction ColliseWithBlock;
    public UnityAction<int> ScoreChanged;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Block block))
        {
            _score++;
            ScoreChanged?.Invoke(_score);
            block.Fill();
        }
    }
}
