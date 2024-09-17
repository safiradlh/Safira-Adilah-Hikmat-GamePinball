using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float returnTime;
    public float followSpeed;
    public float length;
    public Transform target;

    private Vector3 deafultPosition;

    public bool hasTarget { get {  return target != null; } }

    private void Start()
    {
        deafultPosition = transform.position;
        target = null;
    }

    private void Update()
    {
        // fungsi update kita ubah total menjadi fungsi untuk kamera mengikuti object
        // secara terus menerus sampai target kamera dikosongkam kembali
        if (hasTarget)
        {
            Vector3 targetToCameraDirection = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = target.position + (targetToCameraDirection * length);

            // disini kamera dipindahkan menggunakan lerp biasa yang terjadi tiap update
            // Lerp yang dijalankan disini secara otomatis menjadi smoothing karena menggunakan
            // transform.position secara langsung
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget(Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();
        target = targetTransform;
        length = targetLength;
    }

    public void GoBackToDeafult()
    {
        StopAllCoroutines();

        target = null;

        //gerakan ke posisi deafult dalam waktu return time
        StartCoroutine(MovePosition(deafultPosition, returnTime));
    }

    private IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0;
        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(0.0f, 1.0f, timer/time));

            timer+= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}
