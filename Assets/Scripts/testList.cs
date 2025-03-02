using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class testList : MonoBehaviour
{
    public GameObject textPrefab; // Assign a TextMeshProUGUI prefab
    public Transform contentPanel; // Assign the "Content" object of the Scroll View

    private int counter = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detects left-click
        {
            AddNewText("New Entry " + counter);
            counter++;
        }
    }

    void AddNewText(string text)
    {
        GameObject newText = Instantiate(textPrefab, contentPanel);
        newText.GetComponent<TMP_Text>().text = text;
    }
}
