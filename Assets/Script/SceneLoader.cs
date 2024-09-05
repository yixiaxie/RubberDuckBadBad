using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string dialogueSceneName = "DialogueScene";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadDialogueScene();
        }
    }

    void LoadDialogueScene()
    {
        SceneManager.LoadScene(dialogueSceneName);
    }
}
