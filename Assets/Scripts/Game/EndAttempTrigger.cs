using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndAttempTrigger : MonoBehaviour
{
    public UnityAction AttempEnded;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Ball ball))
        {
            AttempEnded?.Invoke();
        }
    }
}
