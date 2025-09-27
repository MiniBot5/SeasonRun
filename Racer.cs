using UnityEngine;
using UnityEngine.InputSystem;

public class Racer : MonoBehaviour
{
    public string racerName;
    public int currentLap = 1;

    [Header("Car References")]
    public Transform carRoot;      // assign the top-level car object
    public Rigidbody carRigidbody; // assign the main Rigidbody

    private bool[] checkpointsVisited;
    private RaceManager raceManager;
    private Transform lastCheckpoint;

    [Header("Reset Settings")]
    public float holdDuration = 2f; // seconds to hold E
    private float resetHoldTime = 0f;

    private void Start()
    {
        raceManager = Object.FindFirstObjectByType<RaceManager>();
        checkpointsVisited = new bool[raceManager.totalCheckpoints];

        if (carRoot == null) carRoot = transform.root;
        if (carRigidbody == null) carRigidbody = carRoot.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Handle "hold E to reset"
        if (Input.GetKey(KeyCode.E))
        {
            resetHoldTime += Time.deltaTime;

            if (resetHoldTime >= holdDuration)
            {
                ResetToLastCheckpoint();
                resetHoldTime = 0f; // reset timer
            }
        }
        else
        {
            resetHoldTime = 0f;
        }
    }
 

    public void CheckpointReached(int checkpointIndex, Transform checkpointTransform)
    {
        if (checkpointIndex >= 0 && checkpointIndex < checkpointsVisited.Length)
        {
            checkpointsVisited[checkpointIndex] = true;
            lastCheckpoint = checkpointTransform;
            Debug.Log(racerName + " reached checkpoint " + checkpointIndex);
        }
    }

    public bool HasClearedAllCheckpoints()
    {
        for (int i = 0; i < checkpointsVisited.Length; i++)
            if (!checkpointsVisited[i])
                return false;
        return true;
    }

    public void ResetCheckpoints()
    {
        for (int i = 0; i < checkpointsVisited.Length; i++)
            checkpointsVisited[i] = false;
    }

    public void ResetToLastCheckpoint()
    {
        if (lastCheckpoint != null && carRoot != null && carRigidbody != null)
        {
            // Temporarily disable physics to avoid forces messing up position
            carRigidbody.isKinematic = true;

            carRoot.position = lastCheckpoint.position;
            carRoot.rotation = lastCheckpoint.rotation;

            carRigidbody.linearVelocity = Vector3.zero;
            carRigidbody.angularVelocity = Vector3.zero;

            carRigidbody.isKinematic = false;

            Debug.Log(racerName + " reset to last checkpoint.");
        }
        else
        {
            Debug.LogWarning(racerName + " has no checkpoint or car reference to reset to!");
        }
    }
}
