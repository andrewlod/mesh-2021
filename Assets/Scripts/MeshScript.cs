using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
        mesh.vertices = new Vector3[] {
            new Vector3(-2,0,-3), //0
            new Vector3(-2,4,-3), //1
            new Vector3(2,4,-3),  //2
            new Vector3(2,0,-3),  //3
            new Vector3(-2,4,1), //4
            new Vector3(2,4,1), //5
            new Vector3(2,0,1), //6
            new Vector3(2,4,1), //7
            new Vector3(2,4,-3),  //8
            new Vector3(2,0,-3),  //9
            new Vector3(-2,4,-3), //10
            new Vector3(2,4,-3),  //11
            new Vector3(-2,4,1), //12
        };
        mesh.triangles = new int[] { 0, 1, 2,
            2, 3, 0,
            11, 12, 5,
            10, 12, 11,
            6, 9, 8,
            7, 6, 8
        };
        mesh.colors = new Color[]
        {
            new Color(1,0,0,1),
            new Color(1,0,0,1),
            new Color(1,0,0,1),
            new Color(1,0,0,1),
            new Color(0,1,0,1),
            new Color(0,1,0,1),
            new Color(0,0,1,1),
            new Color(0,0,1,1),
            new Color(0,0,1,1),
            new Color(0,0,1,1),
            new Color(0,1,0,1),
            new Color(0,1,0,1),
            new Color(0,1,0,1)
        };
        gameObject.AddComponent<MeshRenderer>();
        Renderer renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Custom/ColorShader"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
