using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _originPoint;

    [SerializeField] private float _speed;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private int _distanceOfPatrol;

    private Transform player;

    private bool isMovingRight;

    private bool isChill = false;
    private bool isAngry = false;
    private bool isComeback = false;


    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        CheckDistanceAndSetEnemyState();
    }

    private void CheckDistanceAndSetEnemyState()
    {
        if (Vector2.Distance(transform.position, _originPoint.position) < _distanceOfPatrol && isAngry == false)
        {
            isChill = true;
        }

        if (Vector2.Distance(transform.position, player.position) < _stoppingDistance)
        {
            isAngry = true;
            isChill = false;
            isComeback = false;
        }
        if (Vector2.Distance(transform.position, player.position) > _stoppingDistance)
        {
            isComeback = true;
            isAngry = false;
        }

        if (isChill)
        {
            Chill();
        }
        else if (isAngry)
        {
            Angry();
        }
        else if (isComeback)
        {
            Comeback();
        }
    }

    private void Chill()
    {
        if (transform.position.x > _originPoint.position.x + _distanceOfPatrol)
        {
            isMovingRight = false;
        }
        else if (transform.position.x < _originPoint.position.x - _distanceOfPatrol)
        {
            isMovingRight = true;
        }

        if (isMovingRight)
        {
            transform.position = new Vector2(transform.position.x + _speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - _speed * Time.deltaTime, transform.position.y);
        }
    }

    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
    }

    private void Comeback()
    {
        transform.position = Vector2.MoveTowards(transform.position, _originPoint.position, _speed * Time.deltaTime);
    }
}
