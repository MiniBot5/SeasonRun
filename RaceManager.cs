using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class RaceManager : MonoBehaviour
{
    [Header("Race Settings")]
    public int totalLaps = 3;
    public int totalCheckpoints = 7;

    [Header("Players")]
    public Racer player1;
    public Racer player2;


    [Header("UI")]
    public GameObject endScreenUI;
    public TextMeshProUGUI EndText;

    private bool raceOver = false;

    void Start()
    {
        endScreenUI.SetActive(false);
    }

    public void OnPlayerLapComplete(Racer racer)
    {
        if (raceOver) return;

        racer.currentLap++;
        Debug.Log(racer.racerName + " is now on lap " + racer.currentLap + 1);

        if (racer.currentLap >= totalLaps)
        {
            RaceFinished(racer);
        }
    }

    void RaceFinished(Racer winner)
    {
        raceOver = true;
        Debug.Log(winner.racerName + " wins!");

        endScreenUI.SetActive(true);
        EndText.text = winner.racerName + " Wins!";
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
