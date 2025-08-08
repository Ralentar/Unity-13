using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _route;
    [SerializeField] private Transform[] _waypoints;

    private float _speed = 5;
    private int _waypointIndex;

    private void Awake()
    {
        _waypoints = new Transform[_route.childCount];

        for (int i = 0; i < _route.childCount; i++)
            _waypoints[i] = _route.GetChild(i).GetComponent<Transform>();
    }
    private void Start()
    {
        TurnToTarget();
    }

    private void Update()
    {
        Vector3 targetWaypoint = _waypoints[_waypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, _speed * Time.deltaTime);

        if (transform.position == targetWaypoint)
        {
            _waypointIndex = ++_waypointIndex % _waypoints.Length;
            TurnToTarget();
        }
    }

    private void TurnToTarget()
    {
        transform.forward = _waypoints[_waypointIndex].position - transform.position;
    }
}