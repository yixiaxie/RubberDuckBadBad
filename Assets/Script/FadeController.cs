using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FadeController : MonoBehaviour
{
    public Image fadeImage; // Reference to the Image component used for fading
    public float fadeDuration = 1f; // Duration of the fade

    private void Start()
    {
        // Ensure the image starts fully transparent
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
    }

    // Coroutine to fade in (from black to clear)
    public IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure the image is fully transparent at the end
        fadeImage.color = new Color(color.r, color.g, color.b, 0f);
    }

    // Coroutine to fade out (from clear to black)
    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        // Ensure the image is fully opaque at the end
        fadeImage.color = new Color(color.r, color.g, color.b, 1f);
    }
}