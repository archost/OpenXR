using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupObject : MonoBehaviour
{
    [SerializeField]
    private string objectName = "None";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out var p))
        {
            Debug.Log($"Надел {objectName}!");
            p.AddItem(objectName);
<<<<<<< HEAD


=======
>>>>>>> 2db949602788e6ad83d0a0067859f8e7b24e5b8a
            Destroy(gameObject);
        }
    }
}
