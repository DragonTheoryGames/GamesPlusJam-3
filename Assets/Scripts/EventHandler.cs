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
                if (hit.transform.tag == "EventObject")
                {

                    hitObject = hit.transform.gameObject;
                    TriggerEvent();

                }
            }
        }
    }

    // This will see if we can trigger the event, then trigger the event if we can.
    void TriggerEvent()
    {
        eventObject = hitObject.GetComponent<EventObject>();
        
        if (eventObject.isReusable == true)
        {
            Debug.Log("Running event!");
            eventObject.Run();
        }
        else
        {
            if (eventObject.isUsable == true)
            {
                Debug.Log("Running event!");
                eventObject.Run();
                eventObject.isUsable = false;
            }
            else
            {
                Debug.Log("You cannot run this event again.");
                return;
            }
        }
    }

}
