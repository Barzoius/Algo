using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstuctionList : MonoBehaviour
{
    public GameObject textPrefab; 
    public Transform contentPanel;


    public void AddNewText(string text)
    {
        GameObject newText = Instantiate(textPrefab, contentPanel);
        newText.GetComponent<TMP_Text>().text = text;
    }
}
