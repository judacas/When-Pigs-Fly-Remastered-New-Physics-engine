using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class meshPhysics : MonoBehaviour
{

    Vector3[] vertices;
    int[] tris, vertIndexes;
    MeshFilter meshFilter;

    public void Start(){
        meshFilter = gameObject.GetComponent<MeshFilter>();
        // makeRigidBody();
        fixMesh();
    }


//so for some reason sometimes these mfers have duplicate vertices so uhm yeah check for that next time :)
//WHY TF ARE THERE DUPLICATE VERTICES IN THE BASIC CUBE OMFG I JUST WASTED SO MUCH TIME TO FIGURE THAT OUT
    public void makeRigidBody(){
        Debug.Log("sldkfjdslk");
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        vertices = meshFilter.mesh.vertices;
        Debug.Log("verts: " + vertices.Length);
        tris = meshFilter.mesh.triangles;
        Debug.Log("tries: " + tris.Length);
        MassParticle[] particles = new MassParticle[vertices.Length];
        Vector2[] edges = new Vector2[tris.Length];
        bool isFound;
        Vector2 temp;
        int index = 0;
        for (int i = 0; i < tris.Length; i++){
            if(i%3 == 2){
                temp = new Vector2(i, i-2);
            }
            else{
                temp = new Vector2(i, i+1);
            }
            isFound = false;
            foreach(Vector2 x in edges)
            {
                if(temp.Equals(x))
                {
                    isFound = true;
                    break;
                }
            }
            if(!isFound){
                edges[index] = temp;
                index++;
            }
        }
        foreach (Vector3 x in vertices)
        {
            Debug.Log(x);
        }
        Debug.Log(edges.Length);
    }


    public void fixMesh(){
        
        Vector3[] temp = meshFilter.mesh.vertices;
        tris = meshFilter.mesh.triangles;
        for (int i = 0; i < temp.Length; i++)
        {
            for (int j = temp.Length-1; j > i; j--)
            {
                if(temp[j] == temp[i]){
                    temp[j] = temp[0];
                    for (int k = 0; k < tris.Length; k++)
                    {
                        if(tris[k] == j)
                        {
                            tris[k] = i;
                        }
                    }
                }
            }        
        }
        int count = -1;
        for (int i = 0; i < temp.Length; i++)
        {   
            if (temp[i] == temp[0])
            {
                count++;
            }
        }
        vertices = new Vector3[temp.Length - count];
        vertIndexes = new int[vertices.Length];
        int index = 1;
        vertices[0] = temp[0];
        for (int i = 1; i < vertices.Length; i++){
            while(temp[index] == temp[0]){
                index++;
            }
            vertices[i] = temp[index];
            vertIndexes[i] = index;
            index++;
        }

        for (int i = 0; i < tris.Length; i++)
        {
            if(tris[i] > vertices.Length){
                for (int j = 0; j < vertIndexes.Length; j++)
                {
                    if(tris[i] == vertIndexes[j]){
                        tris[i] = j;
                        break;
                    }
                }
            }
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Debug.Log(vertices[i]);
            Debug.Log(vertIndexes[i]);
        }
        Debug.Log($"printing tris");
        for (int i = 0; i < tris.Length; i++)
        {
            Debug.Log(tris[i]);
        }
        Debug.Log($"num of tris" + tris.Length/3);
        Debug.Log($"num of verts" + vertices.Length);
         
    }
    public void makeMesh()
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        // meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

        Vector3[] vertices = new Vector3[12]
        {
            new Vector3(-1,  t,  0),
            new Vector3( 1,  t,  0),
            new Vector3(-1, -t,  0),
            new Vector3( 1, -t,  0),

            new Vector3( 0, -1,  t),
            new Vector3( 0,  1,  t),
            new Vector3( 0, -1, -t),
            new Vector3( 0,  1, -t),

            new Vector3( t,  0, -1),
            new Vector3( t,  0,  1),
            new Vector3(-t,  0, -1),
            new Vector3(-t,  0,  1)
        };
        mesh.vertices = vertices;

        int[] tris = new int[12*3]
        {
            0,1,2,
            1,2,3,
            2,3,4,
            3,4,5,
            4,5,6,
            5,6,7,
            6,7,8,
            7,8,9,
            8,9,10,
            9,10,11,
            10,11,0,
            11,0,1,

        };
        mesh.triangles = tris;

        mesh.RecalculateNormals();
        meshFilter.mesh = mesh;
    }
}