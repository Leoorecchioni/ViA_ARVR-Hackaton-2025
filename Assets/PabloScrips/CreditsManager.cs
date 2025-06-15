using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditsManager : MonoBehaviour
{
    public Image logoImage; // Reference to the UI Image component for the logo
    public Text creditsText; // Reference to the UI Text component for credits
    public float logoDisplayTime = 3f; // Time to display the logo before showing the text
    public float scrollSpeed = 50f; // Speed at which the credits scroll
    public float initialDelay = 2f; // Initial delay before starting the scroll
    public float endDelay = 5f; // Delay at the end of the credits before transitioning

    void Start()
    {
        // Start the coroutine to handle the logo and credits sequence
        StartCoroutine(DisplayLogoAndScrollCredits());
    }

    IEnumerator DisplayLogoAndScrollCredits()
    {
        // Display the logo
        logoImage.gameObject.SetActive(true);
        creditsText.gameObject.SetActive(false);

        // Wait for the logo display time
        yield return new WaitForSeconds(logoDisplayTime);

        // Hide the logo and show the credits text
        logoImage.gameObject.SetActive(false);
        creditsText.gameObject.SetActive(true);

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
    }
}
