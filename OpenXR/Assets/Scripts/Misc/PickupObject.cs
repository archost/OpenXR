using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var p))
        {
            Debug.Log($"Надел {gameObject.name}");
            //сигнал о выполнении задачи
            Destroy(gameObject);
        }
    }
}
