using UnityEngine;
using Random = UnityEngine.Random;

public enum OpeningDirection
{
    Top,
    Bottom,
    Left,
    Right
}

public class RoomSpawner : MonoBehaviour
{
    public OpeningDirection openingNeeded;

    private RoomTemplates _templates;
    private int _randomIndex;
    [SerializeField] private bool _spawned;

    private float _waitTime = 3f;

    private void Start()
    {
        _spawned = false;
        Destroy(gameObject, _waitTime);
        _templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", .1f);
    }

    private void Spawn()
    {
        if (!_spawned)
        {
            SpawnRandomRoom();
            _spawned = true;
        }
    }

    private void SpawnRandomRoom()
    {
        switch (openingNeeded)
        {
            case OpeningDirection.Top:
                _randomIndex = Random.Range(0, _templates.topRooms.Length);
                Instantiate(_templates.topRooms[_randomIndex], transform.position, Quaternion.identity);
                break;
            case OpeningDirection.Bottom:
                _randomIndex = Random.Range(0, _templates.bottomRooms.Length);
                Instantiate(_templates.bottomRooms[_randomIndex], transform.position, Quaternion.identity);
                break;
            case OpeningDirection.Left:
                _randomIndex = Random.Range(0, _templates.leftRooms.Length);
                Instantiate(_templates.leftRooms[_randomIndex], transform.position, Quaternion.identity);
                break;
            case OpeningDirection.Right:
                _randomIndex = Random.Range(0, _templates.rightRooms.Length);
                Instantiate(_templates.rightRooms[_randomIndex], transform.position, Quaternion.identity);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spawn Point"))
        {
            if (!other.GetComponent<RoomSpawner>()._spawned && !_spawned)
            {
                Debug.Log(gameObject.name);
                GameObject room = Instantiate(_templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            _spawned = true;
        }
    }
}