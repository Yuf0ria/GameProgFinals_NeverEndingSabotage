using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartToOffice : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Office");
    }
}
