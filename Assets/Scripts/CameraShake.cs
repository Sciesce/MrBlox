using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    public IEnumerator Shake (float duration, float magnitude) //creating coroutine
    {
        Vector3 originalPos = transform.localPosition; //initializing original position

        float elapsed = 0.0f; //setting/resetting elapsed time
        
        while (elapsed < duration) //while the time passed is less than the max duration
        {
            float x = Random.Range(-1f, 1f) * magnitude; //random in range 
            float y = Random.Range(-1f, 1f) * magnitude; //random in range

            transform.localPosition = new Vector3(x, y, originalPos.z); //combining

            elapsed += Time.deltaTime; //incrementing elapsed time

            yield return null; //corouting return
        }

        transform.localPosition = originalPos; //resetting position after shake ends

    }
}
