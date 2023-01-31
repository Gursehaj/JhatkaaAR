using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Button enterButton;
    [SerializeField]
    GameObject menuPanel;
    bool toggled = false;
    float animSpeed = 1600f;

    float yPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(false);
        enterButton.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (toggled)
        {
            var r = menuPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, yPos += Time.deltaTime * animSpeed);
            if(yPos >= 900)
                toggled = false;
        }
    }

    public void displayAvilableLocations()
    {
        menuPanel.SetActive(true);
        enterButton.gameObject.SetActive(false);
        toggled = true;
    }
}
