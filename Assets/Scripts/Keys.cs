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
            Debug.Log(keysLeft);
        }
        else if (col.gameObject.tag == "exit")
        {
            Debug.Log(keysLeft);
            if (keysLeft <= 0)
            {
                Debug.Log("Win");
            }
        }
    }


}
