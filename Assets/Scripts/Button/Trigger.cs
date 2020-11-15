using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject buttonInTrigger;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        buttonInTrigger = collision.gameObject.transform.parent.gameObject;
    }
}
