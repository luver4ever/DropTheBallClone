using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Transform _menuTransform;

    public UnityAction GameStarted;

    public void StartGame()
    {
        StartCoroutine(MoveMenu());
    }
    private IEnumerator MoveMenu()
    {
        var pathTime = 2f;
        var duration = 0f;
        while(duration < 1f)
        {
            _menuTransform.position = Vector3.Lerp(_menuTransform.position, _menuTransform.position + Vector3.up * 2, duration);
            duration += Time.deltaTime / pathTime;
            yield return null;
        }
        GameStarted?.Invoke();
    }
}
