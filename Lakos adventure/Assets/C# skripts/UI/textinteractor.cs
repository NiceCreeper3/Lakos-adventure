using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "textbox indecator", menuName = "textindecator")]
public class textinteractor: ScriptableObject
{
    public TypeWriterEffect textboxinsceene;

    public void RunTextBox(string text)
    {
        textboxinsceene.gameObject.SetActive(true);
        textboxinsceene.CallUpdateFullText(text);
    }
}
