using System;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private void Awake()
    {
        try
        {
            Destroy(gameObject, 2f);
        }
        catch (Exception)
        {
            // ignored
        }
    }

    private void Update()
    {
        transform.position += Time.deltaTime * 11f * Vector3.down;
    }
}
