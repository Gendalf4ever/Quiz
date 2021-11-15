using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main instance;
    public LoadData loadData;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        loadData = GetComponent<LoadData>();
    }
}
