using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySlotTrigger : MonoBehaviour
{
    public CandyType NeedType;
    [Range(-0.1f,0.1f)]
    public float OffssetY;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter " + other.tag);
        if (other.CompareTag("Candy"))
        {
            if (other.gameObject.GetComponent<Candy>().type == NeedType)
            {
                Vector3 pos = new Vector3(transform.position.x, OffssetY, transform.position.z);
                GameObject obj = Instantiate(other.gameObject, pos, other.transform.rotation);
                Destroy(other.gameObject);
                MoveManager.singltone.AddCandy();
            }
        }
    }
}
