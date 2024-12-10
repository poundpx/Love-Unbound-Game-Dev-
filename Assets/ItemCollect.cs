using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCollect : MonoBehaviour
{
    //call notebook count UI and change text as notebook increment
    public TextMeshProUGUI bookCountText;
    public int curNoteBookCollect;

    void Start()
    {
        curNoteBookCollect = 0;
    }

    public void Collect()
    {
        curNoteBookCollect++;
        Debug.Log("Note book " + curNoteBookCollect);
        bookCountText.text = curNoteBookCollect.ToString();
    }
}