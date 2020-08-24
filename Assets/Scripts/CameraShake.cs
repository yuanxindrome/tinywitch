using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake shakeCam;
    public GameObject currPos;

    private float shakeTimeRemaining, shakepower, shakeFadeTime, shakeRotation;
    public float rotationMultiplier = 7f;

    public void Awake()
    {
        shakeCam = this;

    }

    private void Update()
    {
        transform.position = currPos.transform.position;

    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakepower;
            float yAmount = Random.Range(-1f, 1f) * shakepower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakepower = Mathf.MoveTowards(shakepower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));
    }


    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakepower = power;

        shakeFadeTime = power/length;

        shakeRotation = power * rotationMultiplier;
    }


}