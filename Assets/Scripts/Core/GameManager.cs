using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float timeModulationFactor = 1f / 10f;
    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    // Slow motion effect
    private IEnumerator RestartLevel()
    {
        // Slow down time
        Time.timeScale = timeModulationFactor;
        Time.fixedDeltaTime = Time.fixedDeltaTime * timeModulationFactor;

        // Let the game do its thing for 2 sec
        yield return new WaitForSeconds(1f * timeModulationFactor);

        // Return time back to normal and load a new scene
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime / timeModulationFactor;
        SceneManager.LoadScene(0); //TODO: change this to main menue scene
    }
}
