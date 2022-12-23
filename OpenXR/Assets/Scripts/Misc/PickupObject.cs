using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var p))
        {
            Debug.Log($"����� {gameObject.name}");
            //������ � ���������� ������
            Destroy(gameObject);
        }
    }
}
