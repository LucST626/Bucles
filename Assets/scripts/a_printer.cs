using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class a_printer : MonoBehaviour
{
    [SerializeField] int cantidad = 0;
    Vector3 position;
    int numero;
    string nombre = "pepe";
    [SerializeField] int start;
    [SerializeField] float timeBetweenPrints;
    [SerializeField] GameObject prefab;
    [SerializeField] bool rotate;
    
    [SerializeField] Vector3 rotar;
    [SerializeField] List<a_printer> printerList;

    void Start()
    {
        StartCoroutine(Loop());
        //StartCoroutine(rotador());
    }

    //public IEnumerator rotador()
    //{
    //    while (true) 
    //    {
    //        if(rotate == true)
    //        transform.Rotate(rotar * Time.deltaTime);
    //        yield return null;
    //    }

    //}
    public IEnumerator eliminar()
    {
        while (printerList.Count > 0 ) 
        {
            Destroy(printerList[0]);
            printerList.RemoveAt(0);
            yield return null;
        }
    }
IEnumerator Loop()
    {
        for (int i = start; i < start + cantidad; i++)
         for (int j = start; j < start + cantidad; j++)
          for (int k = start; k < start + cantidad; k++)
          {
                if ((i == start && j == start) 
                    || 
                   (i == start && k == start)
                   ||
                   (j == start && k == start)
                    ||
                    (i == start + cantidad -1 && j == start + cantidad - 1)
                    ||
                    (j == start + cantidad -1 && k == start + cantidad - 1)
                    ||
                    (k == start + cantidad - 1 && i == start + cantidad - 1)
                    ||
                    (i == start && j == start + cantidad - 1)
                    ||
                    (i == start && k == start + cantidad - 1)
                    ||
                    (k == start && j == start + cantidad - 1)
                    ||
                    (i == start + cantidad - 1 && j == start)
                    ||
                    (i == start + cantidad - 1 && k == start)
                    ||
                    (k == start + cantidad - 1 && j == start)
                    )
                {
                    position = new Vector3( i, j, k);
                    numero++;
                    InstanciateTo();
                    yield return new WaitForSeconds(timeBetweenPrints);
                }
          }
    }

    public void InstanciateTo()
    {
        Vector3 rotPos = transform.TransformPoint(position);

        GameObject instantiated = Instantiate(prefab,
            rotPos,
            Quaternion.identity,
            transform);
        instantiated.name = nombre;
        instantiated.name += numero;
        print("Placing " + instantiated.name + position);
    }
}
