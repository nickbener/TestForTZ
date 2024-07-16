using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenerer : MonoBehaviour
{
    public void Scene(int _num)
    {
        SceneManager.LoadScene(_num);
    }
}
