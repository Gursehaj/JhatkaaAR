using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class ARSceneManager : MonoBehaviour
{
    public static ARSceneManager instance;
    [SerializeField]
    GameObject MainPanel;
    [SerializeField]
    GameObject InstructionPanel;
    
    private void OnEnable()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += setupScene;
    }
    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        InstructionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetScene(int index)
    {
        PlayerPrefs.SetInt("city", index);
        MainPanel.SetActive(false);
        InstructionPanel.SetActive(true);
    }

    public void LoadARScene()
    {
        SceneManager.LoadScene(1);
    }

    public void loadMainMenu()
    {
        //var arGround = GameObject.FindGameObjectWithTag("ARGround").transform;
        //var childCount = arGround.childCount;
        //if (childCount != 0)
        //{
        //    for (int i = 0; i < childCount; i++)
        //    {
        //       Destroy(arGround.GetChild(i));
        //    }
        //}
        SceneManager.LoadScene(0);
        Debug.LogWarning("Displaying Main Menu");
    }

    void  setupScene()
    {
        
    }

    // called second
    void setupScene(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            //var index = PlayerPrefs.GetInt("city");
            //if (index == 0)
            //{
            //    var gb = Instantiate(Resources.Load<GameObject>("Sphere"), GameObject.FindGameObjectWithTag("ARGround").transform, false);
            //    gb.transform.position = Vector3.zero;
            //}
            //else if (index == 1)
            //{
            //    var gb = Instantiate(Resources.Load<GameObject>("Cube"), GameObject.FindGameObjectWithTag("ARGround").transform, false);
            //    gb.transform.position = Vector3.zero;
            //}
            //var gb = Instantiate(Resources.Load<GameObject>(index.ToString()), GameObject.FindGameObjectWithTag("ARGround").transform, true);
            Debug.LogWarning("Displaying AR Scene");
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= setupScene;
    }
}
