using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartPuzzle()
    {
        // Load the puzzle canvas or scene
        SceneManager.LoadScene("PuzzleScene"); // Replace with actual scene name
    }

    public void CompletePuzzle()
    {
        // Handle logic for completing the puzzle
        Debug.Log("Puzzle Completed!");
        // Transition back to main scene or next step
        SceneManager.LoadScene("MainScene");
    }
}