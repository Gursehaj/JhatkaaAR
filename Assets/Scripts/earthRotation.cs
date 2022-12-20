using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthRotation : MonoBehaviour
{
    GameObject earth;
    [Range(0f, 10f)]
    public float rotationSpeed;
    private float earthYRotation;
    public bool rotate = true;

    public static earthRotation instance;

    private void OnEnable()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        earth = GameObject.FindGameObjectWithTag("Earth");
        earthYRotation = earth.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (rotate)
        {
            var earthRotation = earth.transform.rotation.eulerAngles;
            earth.transform.rotation = Quaternion.Euler(new Vector3(earthRotation.x, earthRotation.y + rotationSpeed * Time.deltaTime, earthRotation.z));
        }
    }
}