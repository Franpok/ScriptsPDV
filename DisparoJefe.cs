using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJefe : MonoBehaviour
{
    public GameObject proyectil;
    public Transform spawn;
    static System.Random random = new System.Random();
    public double siguiente = 1;
    public double actual = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawn = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        disparar();
    }
    public void disparar()
    {
        actual += Time.deltaTime;
        if (actual > siguiente)
        {
            siguiente += actual;
            Instantiate(proyectil, spawn.position, Quaternion.identity);
            siguiente -= actual;
            actual = 0;
        }
    }
}
