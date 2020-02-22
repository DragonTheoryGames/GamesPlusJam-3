using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    // Grabbing the object clicked at
    private GameObject hitObject;

    // Grabbing the EventObject script from the object clicked at
    private EventObject eventObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Assign any objects that want to be triggered with the Trigger tag
                if (hit.transform.tag == "Trigger")
                {

                    hitObject = hit.transform.gameObject;
                    CanTriggerEvent();

                }
            }
        }
    }

    // This will see if we've already triggered this object, and if we can trigger it again (if it's reusable)
    void CanTriggerEvent()
    {
        eventObject = hitObject.GetComponent<EventObject>();
        
        if (eventObject.isReusable == true)
        {
            Debug.Log("Running event!");
        }
        else
        {
            if (eventObject.isUsable == true)
            {
                Debug.Log("Running event!");
                eventObject.isUsable = false;
            }
            else
            {
                Debug.Log("You cannot run this event again.");
            }
        }
    }

    void TriggerEvent()
    {
       
    }
}
