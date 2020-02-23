using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    int keysLeft = 8;

    private void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "key")
        {
            keysLeft -= 1;
            Destroy(col.gameObject);
        }
        else if (col.gameObject.tag == "exit")
        {
            if (keysLeft <= 0)
            {
                Debug.Log("Win");
            }
        }
    }


}
