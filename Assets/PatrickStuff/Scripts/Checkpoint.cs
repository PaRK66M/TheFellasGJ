
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float spawnScale;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    public int room;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().CheckpointSave(spawnPoint.position, Vector3.one * spawnScale);
            cam.GetComponent<CameraBehaviour>().targetroom = room;
            Debug.Log("updated cam rooms");
        }
        
    }
}
