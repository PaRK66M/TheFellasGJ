
using Unity.VisualScripting;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    bool beginLerp = false;
    private Vector3 targetpos = new Vector3(0, 0, -10);
    private Vector3 startpos = new Vector3(0,0,-10);

    float lerpDuration = 1f;
    float timeElapased = 0f;

    public int roomx = 0;
    public int roomy = 0;

    void Start()
    {
        camera.transform.position = new Vector3(0,0,-10);
    }

    // Update is called once per frame
    void Update()
    {
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
            //dont check to see if we can move the camera if we are currently in the process of moving it
            if (Input.GetKeyDown(KeyCode.A))
            {
                MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveUp();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                MoveDown();
            }
        }
    }

    void MoveLeft()
    {
        Vector2 screenSize = ScreenEdges().Abs();

        targetpos = new Vector3(camera.transform.position.x - screenSize.x, camera.transform.position.y, -10);
        beginLerp = true;
        roomx -= 1;

    }

    void MoveRight()
    {
        Vector2 screenSize = ScreenEdges().Abs();

        targetpos = new Vector3(camera.transform.position.x + screenSize.x, camera.transform.position.y, -10);
        beginLerp = true;

        roomx += 1;
    }

    void MoveUp()
    {
        Vector2 screenSize = ScreenEdges().Abs();

        targetpos = new Vector3(camera.transform.position.x, camera.transform.position.y + screenSize.y, -10);
        beginLerp = true;

        roomy += 1;
    }

    void MoveDown()
    {
        Vector2 screenSize = ScreenEdges().Abs();

        targetpos = new Vector3(camera.transform.position.x, camera.transform.position.y - screenSize.y, -10);
        beginLerp = true;

        roomy -= 1;
    }

    Vector2 ScreenEdges()
    {
        float frustrumHeight = 2f*camera.transform.position.z * Mathf.Tan(Mathf.Deg2Rad*(camera.fieldOfView * 0.5f));
        float frustrumWidth = frustrumHeight * camera.aspect;

        return new Vector2(frustrumWidth + 3.3f, frustrumHeight + 1.6f);
    }
}
