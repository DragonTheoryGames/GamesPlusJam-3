using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene("MainMenu");
                Debug.Log("Win");
            }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }


}
