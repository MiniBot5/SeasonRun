using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    [Header("Race Settings")]
    public int totalLaps = 8;

    [Header("Players")]
    public Racer player1;
    public Racer player2;

    [Header("UI")]
    public GameObject endScreenUI;
    public Text EndText;

    private bool raceOver = false;

    void Start()
    {
        endScreenUI.SetActive(false);
    }

    public void OnPlayerLapComplete(Racer racer)
    {
        if (raceOver) return;

        racer.currentLap++;
        Debug.Log(racer.name + " is now on lap " + racer.currentLap);

        if (racer.currentLap > totalLaps)
        {
            RaceFinished(racer);
        }
    }

    void RaceFinished(Racer winner)
    {
        raceOver = true;
        Debug.Log(winner.name + " wins!");

        endScreenUI.SetActive(true);
        EndText.text = winner.name + " Wins!";
        Time.timeScale = 0f;
    }

    public void RestartRace()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
