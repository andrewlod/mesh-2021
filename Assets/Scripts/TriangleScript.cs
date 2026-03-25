using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Triangle
{
    public Vector3[] coords = new Vector3[3];

    public Triangle(Vector3 a, Vector3 b, Vector3 c)
    {
        coords[0] = a;
        coords[1] = b;
        coords[2] = c;
    }
}

public class TriangleScript : MonoBehaviour
{

    public int depth = 8;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
        List<Vector3> vertices = new List<Vector3>();
        List<int> tris = new List<int>();
        List<Triangle> triangles = new List<Triangle>();
        triangles.Add(new Triangle(
            new Vector3(0, 1, 0),
            new Vector3(-1,-1,0),
            new Vector3(1,-1,0)
        ));

        for(int i = 1; i < depth; i++)
        {
            List<Triangle> newTriangles = new List<Triangle>();
            foreach(Triangle t in triangles)
            {
                Vector3 t01 = (t.coords[0] + t.coords[1]) / 2f;
                Vector3 t02 = (t.coords[0] + t.coords[2]) / 2f;
                Vector3 t12 = (t.coords[1] + t.coords[2]) / 2f;
                newTriangles.Add(new Triangle(t.coords[0], t01, t02));
                newTriangles.Add(new Triangle(t01, t.coords[1], t12));
                newTriangles.Add(new Triangle(t02, t12, t.coords[2]));
            }
            triangles = newTriangles;
        }
        int j = 0;

        foreach(Triangle t in triangles)
        {
            vertices.Add(t.coords[0]);
            vertices.Add(t.coords[1]);
            vertices.Add(t.coords[2]);
            tris.Add(j++);
            tris.Add(j++);
            tris.Add(j++);
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = tris.ToArray();
        /*
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
        */
        gameObject.AddComponent<MeshRenderer>();
        Renderer renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Custom/ColorShader"));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
