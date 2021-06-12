using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class portal : MonoBehaviour
{
    public GameObject portals;
    public GameObject target;
    public GameObject load;
    public GameObject load2;
    public GameObject lut;
    public Light2D light;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(transport());
        }
    }

    IEnumerator transport()
    {
        yield return new WaitForSeconds(0.05f);
        load.SetActive(true);
        lut.SetActive(true);
        light.intensity = 0.55f;
        yield return new WaitForSeconds(2f);
        target.transform.position = new Vector2(portals.transform.position.x, portals.transform.position.y);
        yield return new WaitForSeconds(1f);
        load.SetActive(false);
        load2.SetActive(true);
    }
}
