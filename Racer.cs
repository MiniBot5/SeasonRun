using UnityEngine;

public class Racer : MonoBehaviour
{
    public string racerName;
    public int currentLap = 0;

    private bool[] checkpointsVisited;
    private RaceManager raceManager;

    private void Start()
    {
        raceManager = Object.FindFirstObjectByType<RaceManager>();
        checkpointsVisited = new bool[raceManager.totalCheckpoints];
    }

    public void CheckpointReached(int checkpointIndex)
    {
        if (checkpointIndex >= 0 && checkpointIndex < checkpointsVisited.Length)
        {
            checkpointsVisited[checkpointIndex] = true;
        }
    }

    public bool HasClearedAllCheckpoints()
    {
        for (int i = 0; i < checkpointsVisited.Length; i++)
        {
            if (!checkpointsVisited[i])
                return false;
        }
        return true;
    }

    public void ResetCheckpoints()
    {
        for (int i = 0; i < checkpointsVisited.Length; i++)
        {
            checkpointsVisited[i] = false;
        }
    }
}
