using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSwticher : MonoBehaviour
{
    [SerializeField] private AudioClip _lightSound;
    [SerializeField] private AudioClip _mediumSound;
    [SerializeField] private AudioClip _hardSound;

    private GameObject _player;
    private GameObject _enemy;


    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        
    }

    private void FindNearestEnemy()
    {

    }

    private void CheckDistanceToEnemy()
    {

    }
}
