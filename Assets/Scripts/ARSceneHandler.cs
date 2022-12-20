using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("ExitBtn").GetComponent<Button>().onClick.AddListener(() => ARSceneManager.instance.loadMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
