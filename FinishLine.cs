using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public RaceManager raceManager;

    private void OnTriggerEnter(Collider other)
    {
        Racer racer = other.GetComponent<Racer>();
        Debug.Log(racer);

        if (racer.HasClearedAllCheckpoints())
        {
            raceManager.OnPlayerLapComplete(racer);
            Debug.Log("Lap completed!");
            racer.ResetCheckpoints();
        }
    }
}
