using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Vector3 camOriginalPos;
    [SerializeField]public MouseLook mouseLook;
    public LayerMask layerMask;
    public int oldCullingMask;
    [SerializeField] private GridManager gm;
    public bool isMapOn;
    public static CameraManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        camOriginalPos = this.gameObject.transform.position;
        oldCullingMask = Camera.main.cullingMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMapOn = true;
            gm._tileParent.gameObject.SetActive(true);
            this.gameObject.transform.localPosition = new Vector3(1, 1 ,- 10);
            mouseLook.enabled = false;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            Camera.main.cullingMask = layerMask;
            player.GetComponent<PlayerController>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Camera.main.cullingMask = oldCullingMask;
        }

    }
}
