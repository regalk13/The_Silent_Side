using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject Girl;
      // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Girl.transform.position.x;
        position.y = Girl.transform.position.y;
        transform.position = position;
    }
}
