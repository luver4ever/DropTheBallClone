using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseTrigger : MonoBehaviour
{
    public UnityAction PlayerLose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Block block))
        {
            PlayerLose?.Invoke();
        }
    }
}
