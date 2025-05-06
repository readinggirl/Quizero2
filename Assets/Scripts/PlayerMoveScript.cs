using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public GameObject player;
    public float scaleFactor = 1f; 
    private Vector2 originCoordinates = new Vector2(48.188995f, 16.404566f); // Real world origin of your map

    void Start()
    {
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        // Check if location services are enabled
        if (!Input.location.isEnabledByUser)
        {
            Debug.LogError("Location services are not enabled on this device.");
            yield break;
        }

        // Start the location service
        Input.location.Start();

        // Wait for the location service to initialize
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.LogError("Timed out initializing location services.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.LogError("Unable to determine device location.");
            yield break;
        }

        Debug.Log("Location service started successfully.");
    }

    void Update()
    {
        // Ensure location services are running
        if (Input.location.status == LocationServiceStatus.Running)
        {
            // Get current GPS data
            float currentLatitude = Input.location.lastData.latitude;
            float currentLongitude = Input.location.lastData.longitude;

            // Calculate Unity coordinates based on the offset and scale factor
            float x = (currentLongitude - originCoordinates.y) * scaleFactor;
            float z = (currentLatitude - originCoordinates.x) * scaleFactor;

            
            player.transform.position = new Vector3(x, player.transform.position.y, z);
        }
        else
        {
            Debug.LogWarning("Location services are not running.");
        }
    }
}
