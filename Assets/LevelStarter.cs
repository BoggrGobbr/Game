using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    RoomTemplates templates;
    public Transform player;
    int levelCount = 0;
    private void Start()
    {
        templates = GetComponent<RoomTemplates>();
    }
    public void NewLevel()
    {
        levelCount++;
        if (player != null)
            player.parent = null;   
        if (templates.Rooms.Count != 0)
            DeleteExistingRooms();
        SpawnStartRoom();
    }

    void DeleteExistingRooms()
    {
        foreach(GameObject room in templates.Rooms)
        {
            Destroy(room);
        }
        templates.Rooms.Clear();

        foreach (GameObject room in templates.WallRooms)
        {
            Destroy(room);
        }
        templates.WallRooms.Clear();
    }

    void SpawnStartRoom()
    {
        GameObject chosenRoom;
        if (levelCount == 1)
        {
            int random = UnityEngine.Random.Range(0, templates.FirstLevelStartRooms.Length);
            chosenRoom = templates.FirstLevelStartRooms[random];
        }
        else
        {
            int random = UnityEngine.Random.Range(0, templates.OtherLevelStartRooms.Length);
            chosenRoom = templates.OtherLevelStartRooms[random];
        }
        GameObject startRoom = Instantiate(chosenRoom);
        templates.Rooms.Add(startRoom);

        if (startRoom.transform.Find("Player Spawn"))
            player.position = startRoom.transform.Find("Player Spawn").position;
       // Debug.Log(LevelScoreCounter.score);
    }
}
