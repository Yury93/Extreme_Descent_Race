using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public float speed = 3f;
    public Vector3 axis;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate((axis.x * speed * Time.deltaTime / 0.01f) , (axis.y * speed * Time.deltaTime / 0.01f) ,( axis.z * speed * Time.deltaTime / 0.01f), Space.Self);
	}
}
