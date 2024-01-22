using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField, Min(0)] private float _speed;
    [SerializeField] private Transform _route;
    [SerializeField] private Animator _animator;
    
    private Transform[] _points;
    private int _pointNumber;
    
    private void Start()
    {
        _points = new Transform[_route.childCount];

        for (int i = 0; i < _route.childCount; i++)
            _points[i] = _route.GetChild(i).transform;
        
        transform.LookAt(_points[_pointNumber]);
    }
    
    private void Update()
    {
        UpdateRoute();
        UpdateAnimator();
    }

    private void UpdateRoute()
    {
        Transform point = _points[_pointNumber];
        transform.position = Vector3.MoveTowards(transform.position , point.position, _speed * Time.deltaTime);

        if (transform.position == point.position)
            GoToNextPoint();
    }
    
    private void GoToNextPoint(){
        _pointNumber++;

        if (_pointNumber == _points.Length)
            _pointNumber = 0;

        Vector3 pointPosition = _points[_pointNumber].transform.position;
        transform.LookAt(new Vector3(pointPosition.x, transform.position.y, pointPosition.z));
    }
    
    private void UpdateAnimator()
    {
        _animator.SetFloat("Speed", _speed);
    }
}