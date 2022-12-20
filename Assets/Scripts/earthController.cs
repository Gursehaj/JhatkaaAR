using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthController : MonoBehaviour
{
    private float startTime;
    private float thresholdTime = 2f;
    [Range(0.1f, 10f)]
    public float sweepSpeed;
    private GameObject earth;
    // Start is called before the first frame update
    void Start()
    {
        earthRotation.instance.rotate = false;
        startTime = Time.time;
        earth = GameObject.FindGameObjectWithTag("Earth");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                //Debug.LogWarning("Moving Earth");
                earthRotation.instance.rotate = false;
                startTime = Time.time;
                var eRotation = earth.transform.rotation.eulerAngles;
                earth.transform.rotation = Quaternion.Euler(new Vector3(eRotation.x + sweepSpeed * touch.deltaPosition.y * Time.deltaTime, eRotation.y - sweepSpeed * touch.deltaPosition.x * Time.deltaTime, 0));
            }
        }
        else
        {
            if (Time.time - startTime > thresholdTime)
            {
                //Debug.LogWarning("Rotating Earth");
                earthRotation.instance.rotate = true;
            }
        }
    }
}
