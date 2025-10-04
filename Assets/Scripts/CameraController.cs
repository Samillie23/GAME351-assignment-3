using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class CameraController : MonoBehaviour
{
    public CinemachineFreeLook orbitcam;
    public GameObject playermodel;
    private string XAxisName = "Mouse X";
    private string YAxisName = "Mouse Y";


    // Start is called before the first frame update
    void Start()
    {
        orbitcam.m_XAxis.m_InputAxisName = "";
        orbitcam.m_YAxis.m_InputAxisName = "";
    }

    // Update is called once per frame
    void Update()
    {
        Swap();
        Reset();
        Rotate();
    }

    void Swap()
    {
        if (Input.GetKeyDown("t"))
        {
            orbitcam.enabled = !orbitcam.enabled;
            playermodel.GetComponent<Renderer>().enabled = !playermodel.GetComponent<Renderer>().enabled;
        }
    }

    void Reset()
    {
        if (Input.GetKey("r"))
        {
            orbitcam.m_XAxis.Value = 0f;
            orbitcam.m_YAxis.Value = .5f;
        }
    }

    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            orbitcam.m_XAxis.m_InputAxisValue = Input.GetAxis(XAxisName);
            orbitcam.m_YAxis.m_InputAxisValue = Input.GetAxis(YAxisName);
        }
        else
        {
            orbitcam.m_XAxis.m_InputAxisValue = 0;
            orbitcam.m_YAxis.m_InputAxisValue = 0;
        }
    }
}
