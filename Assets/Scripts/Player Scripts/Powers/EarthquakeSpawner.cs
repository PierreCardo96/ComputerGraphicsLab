using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthquakeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject earthquakePrefab;

    [SerializeField]
    Transform parentTransform;
    public void Spawn()
    {
        GameObject prefab = Instantiate(earthquakePrefab, parentTransform.position + parentTransform.forward, Quaternion.identity);
        prefab.transform.rotation = parentTransform.rotation;
        PlayEarthquakeSound();
    }

    private void PlayEarthquakeSound()
    {
        FindObjectOfType<AudioManager>().Play("Earthquake");
    }

    public EarthquakeDamage GetEarthquakePrefab()
    {
        return earthquakePrefab.GetComponent<EarthquakeDamage>();
    }
}
