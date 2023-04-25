using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRef : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainPlayer;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.localPosition = new Vector3(mainPlayer.transform.position.x, mainPlayer.transform.position.z,0);
    }
}
