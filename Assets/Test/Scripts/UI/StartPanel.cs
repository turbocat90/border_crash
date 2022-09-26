using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    public void CloseStartPanel(GameObject startPanel)
    {
        Destroy(startPanel);
    }
}
