using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//using System;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;

[RequireComponent(typeof(NavMeshAgent))]

public class SphereManager : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    protected int index = -1;

    //public Material[] material;
    public Material m_material;
    //public Material red;
    //private Renderer rend;
    private bool isGreen = true;

    protected NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        NextDestination();

        //rend = GetComponent<Renderer>();
        //rend.sharedMaterial = material[0];
        m_material = GetComponent<Renderer>().material;
        print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);


    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            NextDestination();

        }
    }

    private void NextDestination()
    {
        if (isGreen == true)
        {
            isGreen = false;
            Debug.Log(isGreen);
            m_material.color = Color.green;
            //rend.sharedMaterial = material[1];
        }
        else
        {
            isGreen = true;
            m_material.color = Color.red;
        }

        int oldIndex = index;
        while (oldIndex == index)
        {
            index = Random.Range(0, targets.Count);
        }
        agent.SetDestination(targets[index].position);


    }

    //[Serializable]
    //class GameData
    //{
    //    public float position;
    //    public string color;
    //}

    //public void Save()
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Create(Application.persistentDataPath +“/ gameInfo.dat”);
    //    GameData data = new GameData();
    //    data.position = position;
    //    data.color = color;
    //    bf.Serialize(file, data);
    //    file.Close();
    //}

}
