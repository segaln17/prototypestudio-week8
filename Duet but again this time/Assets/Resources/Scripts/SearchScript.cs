using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public TextMeshProUGUI searchText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SearchLeft()
    {
        searchText.text = "No cannonballs here...";
    }

    public void SearchRight()
    {
        searchText.text = "None here either...";
    }
}
