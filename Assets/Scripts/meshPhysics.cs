using System.Data;
using UnityEngine;
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class meshPhysics : MonoBehaviour
{

    Vector3[] vertices;
    int[] tris, vertIndexes;
    MeshFilter meshFilter;

    public float mass;

    public float dampeningFactor;

    public DistanceConstraint[] constraints;

    public MassParticle[] particles;

    public void Start(){
        mass = 5;
        dampeningFactor = 0.5f;
        meshFilter = gameObject.GetComponent<MeshFilter>();
        fixMesh();
        makeRigidBody();
    }

    public void FixedUpdate(){
        for (int i = 0; i < 20; i++)
        {
            work();   
        }
        particles[InputController.index].pos += InputController.movement * 0.1f;
    }


    public void work(){
        if(constraints != null){
            foreach (Constraint constraint in constraints){
                if (constraint != null)
                {
                    constraint.work();
                }
            }
        }
    }



    //in order for particle to not move it must be attached to at least 3 other noncoplanar-vertices
    //with 3 vertices they will always be coplanar (this is including the og, so 3 total, by connecting to 3 more you have 4 total so may not be coplanar)
    public void makeRigidBody()
    {
        particles = new MassParticle[vertices.Length];
        for (int i = 0; i < particles.Length; i++)
        {
            particles[i] = new MassParticle(vertices[i], mass);
        }
        Vector2[] edges = new Vector2[tris.Length];
        bool isFound;
        Vector2 temp;
        int index = 0;
        for (int i = 0; i < tris.Length; i++)
        {
            if (i % 3 == 2)
            {
                temp = new Vector2(tris[i], tris[i - 2]);
            }
            else
            {
                temp = new Vector2(tris[i], tris[i + 1]);
            }
            isFound = false;
            for (int j = 0; j < index; j++)
            {
                if (temp.Equals(edges[i]))
                {
                    isFound = true;
                    break;
                }
            }
            if (!isFound)
            {
                edges[index] = temp;
                index++;
            }
        }
        constraints = new DistanceConstraint[edges.Length];
        for(int i = 0; i < constraints.Length; i++)
        {
            constraints[i] = new DistanceConstraint(particles[(int)edges[i].x], particles[(int)edges[i].y], dampeningFactor);
        }
        
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
        Debug.Log($"num of tris: " + tris.Length/3);
        Debug.Log($"num of verts: " + vertices.Length);
         
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

    private void OnDrawGizmos()
    {
        if(particles != null){
            foreach (MassParticle particle in particles)
            {
                if (particle != null)
                {
                    particle.Draw(transform.position, transform.localScale);
                }
            }

        }
        if(constraints != null){
            foreach (Constraint constraint in constraints){
                if (constraint != null)
                {
                    constraint.Draw(transform.position, transform.localScale);
                }
            }
        }
    }
}