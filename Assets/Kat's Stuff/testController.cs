using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = new Vector3(speed * Input.GetAxis("Horizontal") * Time.deltaTime, speed * Input.GetAxis("Vertical") * Time.deltaTime, 0);
        transform.Translate(moveVector);
    }
}
