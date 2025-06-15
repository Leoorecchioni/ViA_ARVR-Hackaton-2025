using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsManager : MonoBehaviour
{
    public Text creditsText; // Reference to the UI Text component for credits
    public float scrollSpeed = 50f; // Speed at which the credits scroll
    public float initialDelay = 2f; // Initial delay before starting the scroll
    public float endDelay = 5f; // Delay at the end of the credits before transitioning

    void Start()
    {
        // Start the coroutine to scroll the credits
        StartCoroutine(ScrollCredits());
    }

    IEnumerator ScrollCredits()
    {
        // Initial delay before starting the scroll
        yield return new WaitForSeconds(initialDelay);

        // Calculate the total height of the text
        float textHeight = creditsText.preferredHeight;

        // Reset the anchored position to start from the bottom
        creditsText.rectTransform.anchoredPosition = Vector2.zero;

        // Start scrolling the credits upwards
        while (creditsText.rectTransform.anchoredPosition.y < textHeight)
        {
            creditsText.rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
            yield return null;
        }

        // Wait for a delay at the end of the credits
        yield return new WaitForSeconds(endDelay);

        // Transition to another scene or quit the application
        // Example: Load a specific scene
        // UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenuScene");

        // Example: Quit the application
        Application.Quit();

        // Note: Application.Quit() does not work in the Unity Editor; it only works in a built application.
    }
}
