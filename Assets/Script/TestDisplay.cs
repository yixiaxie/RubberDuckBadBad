using UnityEngine;
using TMPro; 

public class TextDisplayManager : MonoBehaviour
{
    public TMP_Text uiText; // 
    // public TMP_Text uiText; 

    public void UpdateText(string newText)
    {
        if (uiText != null)
        {
            uiText.text = newText;
        }
        else
        {
            Debug.LogError("UI Text component not assigned.");
        }
    }
}
