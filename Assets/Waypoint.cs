using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public GameObject[] waypoints; // Lista criada
    int currentWP = 0; // zerar a lista

    float speed = 3.0f; // velocidade
    float accuracy = 1.0f; // raio de cada ponto do objeto
    float rotSpeed = 1.0f; // rotação da saida do objeto ao outro

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint"); // Iniciou procurando objetos com TAG waypoint 
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0) return; // se waypoint for 0 retorne 
        Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, this.transform.position.y, waypoints[currentWP].transform.position.z); // Vector 3 irá enxergar a posição dos points

        Vector3 direction = lookAtGoal - this.transform.position; // dirigir a direção do objeto
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed); // rotação em direção de um objeto ao outro

        if (direction.magnitude < accuracy) // se direção for menor que accuracy(raio) faça:
        {
            currentWP++; // adiciona 1 na lista
            if (currentWP >= waypoints.Length) // se currentWP for maior ou igual ao tamanho do array irá ser = 0
            {
                currentWP = 0;
            }
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime); 
    }
}