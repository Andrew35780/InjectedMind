using UnityEngine;

public class SoundSwticher : MonoBehaviour
{
    [SerializeField] private AudioClip _farSound;
    [SerializeField] private AudioClip _mediumSound;
    [SerializeField] private AudioClip _closeSound;

    [SerializeField] private float _distanceToStartFarSound = 10f;
    [SerializeField] private float _distanceToStartMediumSound = 6f;
    [SerializeField] private float _distanceToStartCloseSound = 3f;

    private AudioSource audioSource;
        
    private Transform _player;
    private Transform _enemy;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _player = FindObjectOfType<PlayerMovement>().transform;
        _enemy = FindObjectOfType<EnemyController>().transform;
    }

    private void Update() => CheckDistanceToEnemy();

    private void CheckDistanceToEnemy()
    {
        float distanceBwEnemyAndPlayer = Vector2.Distance(_player.transform.position, _enemy.transform.position);

        if (distanceBwEnemyAndPlayer <= _distanceToStartFarSound && distanceBwEnemyAndPlayer > _distanceToStartMediumSound)
            ChangeAndStartAudioClip(_farSound);
        else if (distanceBwEnemyAndPlayer <= _distanceToStartMediumSound && distanceBwEnemyAndPlayer > _distanceToStartCloseSound)
            ChangeAndStartAudioClip(_mediumSound);
        else if (distanceBwEnemyAndPlayer <= _distanceToStartCloseSound)
            ChangeAndStartAudioClip(_closeSound);
        else if (distanceBwEnemyAndPlayer > _distanceToStartFarSound)
            audioSource.Pause();
        else
            print($"Unespected distance: {distanceBwEnemyAndPlayer}");
    }

    private void ChangeAndStartAudioClip(AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
