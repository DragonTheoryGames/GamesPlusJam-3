using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLight : MonoBehaviour
{
    bool hittingwall = false;
    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col);
        if (col.gameObject.tag == "wall")
        {
            hittingwall = true;
        }
        if (col.gameObject.tag == "agent" && !hittingwall)
        {
            GameOver();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "wall")
        {
            hittingwall = false;
        }
    }

    void GameOver(){
        Debug.Log("gameover");
    }




}
