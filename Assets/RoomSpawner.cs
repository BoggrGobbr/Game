using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    RoomTemplates templates;
    [SerializeField] private EndPointTypes type;
    [SerializeField] GameObject spawnedRoom = null; public GameObject SpawnedRoom {  get { return spawnedRoom; } }
    int random;
    private bool spawned; public bool Spawned {get { return spawned;} }
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<RoomTemplates>();
        Invoke("Spawn",0.1f);
    }

    void Spawn()
    {
        GameObject chosenRoom = null;
        if (!spawned && templates.Rooms.Count < templates.RoomAmount)
        {
            if (templates.Rooms.Count == templates.RoomAmount - 1)
            {
                random = UnityEngine.Random.Range(0, templates.EndRooms.Length);
                chosenRoom = templates.EndRooms[random];
            }
            else
            {
                switch (type)
                {
                    case EndPointTypes.Bottom:
                        random = UnityEngine.Random.Range(0, templates.TopRooms.Length);
                        chosenRoom = templates.TopRooms[random];
                        break;
                    case EndPointTypes.Top:
                        random = UnityEngine.Random.Range(0, templates.BottomRooms.Length);
                        chosenRoom = templates.BottomRooms[random];
                        break;
                    case EndPointTypes.Left:
                        random = UnityEngine.Random.Range(0, templates.RightRooms.Length);
                        chosenRoom = templates.RightRooms[random];
                        break;
                    case EndPointTypes.Right:
                        random = UnityEngine.Random.Range(0, templates.LeftRooms.Length);
                        chosenRoom = templates.LeftRooms[random];
                        break;
                }

            }
            spawnedRoom = Instantiate(chosenRoom, transform.position, Quaternion.identity);
            templates.Rooms.Add(spawnedRoom);
        }
        else
        {
            chosenRoom = templates.WallRoom;
            spawnedRoom = Instantiate(chosenRoom, transform.position, Quaternion.identity);
            templates.WallRooms.Add(spawnedRoom);
        }

        
        spawned = true;
        Debug.Log("room " + transform.parent.name + " spawned a room at " + name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint") && !spawned)
        {
            Debug.Log(transform.parent.name + " : spawned = " + spawned + collision.transform.parent.name + " : spawned = " + collision.GetComponent<RoomSpawner>().Spawned);
            if (!collision.GetComponent<RoomSpawner>().Spawned)
            {
                StartCoroutine(Wait(collision));
            }
            Debug.Log("ENDPOINT COLLISION BETWEEN " + GetComponent<Transform>().parent.name + " and " + collision.GetComponent<Transform>().parent.name);
            Destroy(gameObject);
            
        }
        

    }

    IEnumerator Wait(Collider2D collision)
    {
        yield return new WaitForFixedUpdate();
        if (collision != null)
            Destroy(collision.gameObject);
        GameObject wallRoom = Instantiate(templates.WallRoom, transform.position, Quaternion.identity);
        templates.WallRooms.Add(wallRoom);
    }

    public enum EndPointTypes
    {
        Bottom,
        Top,
        Left,
        Right
    }
}
