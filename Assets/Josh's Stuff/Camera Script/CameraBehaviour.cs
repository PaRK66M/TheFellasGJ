
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.VFX;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    bool beginLerp = false;
    private Vector3 targetpos = new Vector3(0, 0, -10);
    private Vector3 startpos = new Vector3(0,0,-10);

    float lerpDuration = 1f;
    float timeElapased = 0f;

    public int room = 1;
    
    Vector3 room1 = new Vector3(-399.4f, -191f, -10f);
    Vector3 room2 = new Vector3(-378.4f, -191f, -10f);
    Vector3 room3 = new Vector3(-357.5f, -191f, -10f);
    Vector3 room4 = new Vector3(-335.5f, -191f, -10f);
    Vector3 room5 = new Vector3(-315.5f, -191f, -10f);
    Vector3 room6 = new Vector3(-294.5f, -191f, -10f);
    Vector3 room7 = new Vector3(-273.4f, -191f, -10f);
    Vector3 room8 = new Vector3(-273.4f, -181f, -10f);

    public int targetroom = 1;

    void Start()
    {
        camera.transform.position = room1;
        startpos = room1;
        targetpos = room1;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("cam updating");
        if (beginLerp)
        {
            if (timeElapased < lerpDuration)
            {
                float lerpValue = timeElapased/lerpDuration;
                lerpValue = Mathf.Sin(lerpValue * Mathf.PI * 0.5f);
                camera.transform.position = new Vector3(Mathf.Lerp(startpos.x, targetpos.x, lerpValue), Mathf.Lerp(startpos.y, targetpos.y, timeElapased/lerpDuration), -10);
                timeElapased += Time.deltaTime;
            }
            else
            {
                camera.transform.position = targetpos;
                startpos = targetpos;
                timeElapased = 0f;
                beginLerp = false;
            }
        }
        else
        {
            //Debug.Log("cam checking for input");
            //dont check to see if we can move the camera if we are currently in the process of moving it
            if (targetroom > room)
            {
                //Debug.Log("targetroom big");
                if (targetroom < 8)
                {
                    MoveRight();
                }
                if (targetroom == 8)
                {
                    MoveUp();
                }
            }
            if (targetroom < room)
            {
                if (room < 8)
                {
                    MoveLeft();
                }
                if (room == 8)
                {
                    MoveDown();
                }
            }
        }
    }

    public void MoveLeft()
    {
        room -= 1;

        targetpos = GetRoomCoords(room);
        beginLerp = true;
    }

    public void MoveRight()
    {
        //Console.Write("moving right");
        room += 1;

        targetpos = GetRoomCoords(room);
        beginLerp = true;


        
    }

    public void MoveUp()
    {
        room += 1;

        targetpos = GetRoomCoords(room);
        beginLerp = true;

        
    }

    public void MoveDown()
    {
        room -= 1;

        targetpos = GetRoomCoords(room);
        beginLerp = true;

        
    }

    Vector3 GetRoomCoords(int room)
    {
        switch (room)
        {
            case 1:
            {
                return room1;
                break;
            }
            case 2:
            {
                return room2;
                break;
            }
            case 3:
            {
                return room3;
                break;
            }
            case 4:
            {
                return room4;
                break;
            }
            case 5:
            {
                return room5;
                break;
            }
            case 6:
            {
                return room6;
                break;
            }
            case 7:
            {
                return room7;
                break;
            }
            case 8:
            {
                return room8;
                break;
            }
            default:
            {
                return room1;
                break;
            }
        }
    }

    Vector2 ScreenEdges()
    {
        float frustrumHeight = 2f*camera.transform.position.z * Mathf.Tan(Mathf.Deg2Rad*(camera.fieldOfView * 0.5f));
        float frustrumWidth = frustrumHeight * camera.aspect;

        return new Vector2(frustrumWidth + 3.3f, frustrumHeight + 1.6f);
    }
}
