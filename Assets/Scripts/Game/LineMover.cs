using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMover : MonoBehaviour
{
    [SerializeField] private float _offset;

    public void MoveAllLines(Transform allLines)
    {
        StopAllCoroutines();

        StartCoroutine(Move(allLines, new Vector3(allLines.position.x, allLines.position.y + _offset, allLines.position.z))); ;
    }

    private IEnumerator Move(Transform objTransform, Vector3 needPosition)
    {
        
        float duration = 0f;

        float pathTime = 1.5f;
        
        while (duration < 1f)
        {
            objTransform.position = Vector3.Lerp(objTransform.position, needPosition, duration);
            duration += Time.deltaTime / pathTime;
            yield return null;
        }
    }
    
}
