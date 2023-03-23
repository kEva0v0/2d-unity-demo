using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

    }

    // Camera Update should always called in this function
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 6, -7);
    }
}
