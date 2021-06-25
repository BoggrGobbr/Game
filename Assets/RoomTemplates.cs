using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    LevelStarter game;
    [SerializeField] int roomAmount; public int RoomAmount { get { return roomAmount; } }

    [SerializeField] GameObject[] bottomRooms;
    public GameObject[] BottomRooms { get { return bottomRooms; } }

    [SerializeField] GameObject[] topRooms;
    public GameObject[] TopRooms { get { return topRooms; } }

    [SerializeField] GameObject[] leftRooms;
    public GameObject[] LeftRooms { get { return leftRooms; } }

    [SerializeField] GameObject[] rightRooms;
    public GameObject[] RightRooms { get { return rightRooms; } }

    [SerializeField] List<GameObject> rooms; public List<GameObject> Rooms { get { return rooms; } }
    [SerializeField] List<GameObject> wallRooms; public List<GameObject> WallRooms { get { return wallRooms; } }

    [SerializeField] GameObject wallRoom; public GameObject WallRoom { get { return wallRoom; } }

    [SerializeField] GameObject[] endRooms;
    public GameObject[] EndRooms { get { return endRooms; } }

    [SerializeField] GameObject[] firstLevelStartRooms;
    public GameObject[] FirstLevelStartRooms { get { return firstLevelStartRooms; } }

    [SerializeField] GameObject[] otherLevelStartRooms;
    public GameObject[] OtherLevelStartRooms { get { return otherLevelStartRooms; } }

    private void Start()
    {
        game = GetComponent<LevelStarter>();
        game.NewLevel();
        game.player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

}
