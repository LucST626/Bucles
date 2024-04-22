using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class bucles_while : MonoBehaviour
{
    [SerializeField] Transform ObjectToMove;
    [SerializeField] Transform[] points;
    [SerializeField] Color[] colors;
    [SerializeField] float duaracionAnim;
    
    //[SerializeField] Transform From;
    int indexPointFrom;
    int indexPointTo;
   

    float elapsedTime;

    void Start()
    {
        StartCoroutine(AnimacionLinearInterpolarizada());
    }

    public IEnumerator AnimacionLinearInterpolarizada()
    {
        while (true)
        {
            elapsedTime = 0;

            while (elapsedTime < duaracionAnim)
            {
                elapsedTime += Time.deltaTime;

                ObjectToMove.position = Vector3.LerpUnclamped(
                points[indexPointFrom].position, 
                points[indexPointTo].position, 
                elapsedTime / duaracionAnim
                );
                ObjectToMove.rotation = Quaternion.LerpUnclamped(
                points[indexPointFrom].rotation,
                points[indexPointTo].rotation,
                elapsedTime / duaracionAnim
                );

                yield return null;
            }
            UpdateIndex();
        }
    }
    void UpdateIndex()
    {
        indexPointFrom = indexPointTo;
        indexPointTo = (indexPointTo + 1) % points.Length;
    }
}






/*
 * Interpolaciones lineales
 *  
 */

//public IEnumerator PrimerPrinteador()
//{
//    while (frameCount <= frameDuration)
//    {
//        frameCount++;
//        print(frameCount);
//        yield return null;
//    }
//}

//public IEnumerator SegundoPrinteador()
//{
//    while (true)
//    {
//        while (seconds <= secondDuration)
//        {
//            seconds += Time.deltaTime;
//            ObjectToMove.transform.position = new Vector3 (seconds, 0, 0);
//            yield return null;
//        }
//        seconds = 0;
//        ObjectToMove.transform.position = new Vector3(0, 0, 0);
//        yield return null;
//    }
//}