using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointIndex;

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Car"))
        {
            Racer racer = other.GetComponent<Racer>();
            if (racer != null)
            {
                racer.CheckpointReached(checkpointIndex, transform);
            }
        }
    }
}
