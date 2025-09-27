using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        Racer racer = other.GetComponent<Racer>();

        raceManager.OnPlayerLapComplete(racer);
    }
}
