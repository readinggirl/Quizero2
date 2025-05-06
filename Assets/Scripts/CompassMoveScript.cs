using System.Linq; // Required for LINQ
using UnityEngine;

public class CompassMoveScript : MonoBehaviour
{
    private Quaternion currentRotation;
    private Quaternion newRotation;

    private float rotationSpeed = 1f;

    private GameObject player;
    private GameObject[] eventMarkers;

    private Vector2 playerVector;
    private Vector2 targetVector;

    void Start()
    {
        // Find the player GameObject
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Ensure it has the correct tag.");
        }

        // Find all inactive and active event markers
        eventMarkers = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(obj => obj.CompareTag("Event")) // Filter by tag
            .ToArray();

        if (eventMarkers.Length == 0)
        {
            Debug.LogWarning("No event markers found. Ensure they are tagged correctly.");
        }
    }

    void Update()
    {
        if (player == null || eventMarkers == null || eventMarkers.Length == 0)
        {
            return;
        }

        GameObject closestEvent = null;
        float closestDistance = Mathf.Infinity;

        // Convert player position to Vector2
        playerVector = new Vector2(player.transform.position.x, player.transform.position.y);

        // Find the closest event marker
        foreach (GameObject eventMarker in eventMarkers)
        {
            Vector2 eventPosition = new Vector2(eventMarker.transform.position.x, eventMarker.transform.position.y);
            float distance = Vector2.Distance(playerVector, eventPosition);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEvent = eventMarker;
            }
        }

        // Rotate towards the closest event marker
        if (closestEvent != null)
        {
            targetVector = new Vector2(closestEvent.transform.position.x, closestEvent.transform.position.y);

            Vector2 directionVector = targetVector - playerVector;
            float angleDegrees = Mathf.Atan2(directionVector.x, directionVector.y) * Mathf.Rad2Deg;

            if (angleDegrees < 0)
            {
                angleDegrees += 360f;
            }

            newRotation = Quaternion.Euler(0, 0, -angleDegrees);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Optional utility method (ignore)
    public GameObject[] GetEventMarkers()
    {
        return eventMarkers;
    }
}