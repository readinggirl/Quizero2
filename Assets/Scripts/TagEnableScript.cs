using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TagEnableScript : MonoBehaviour
{
    private GameObject[] eventTags;

    private float distance;
    
    void Start()
    {
        // Stores all the Event tags in an array

        eventTags = Resources.FindObjectsOfTypeAll<GameObject>()
            .Where(obj => obj.CompareTag("Event"))
            .ToArray();


        if (eventTags.Length == 0)
        {
            Debug.LogWarning("No event objects found with the tag 'Event'.");
        }
    }

    void Update()
    {
        // Exit if there are no event tags

        if (eventTags == null || eventTags.Length == 0)
        {
            return; 
        }

        foreach (GameObject eventTag in eventTags)
        {
            // Skip if the object no longer exists

            if (eventTag == null) continue; 

            // Calculate distance between the current marker and the player
            float distance = Vector2.Distance(transform.position, eventTag.transform.position);

            // Activate and deactivate based on distance
            if (distance < 0.5)
            {
                eventTag.SetActive(true);
            }
            else
            {
                eventTag.SetActive(false);
            }

        }
    }

}
