using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class meshData : MonoBehaviour
{

    public void Start()
    {

        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
        Vector3[] vertices = meshFilter.mesh.vertices;
        Debug.Log("Vertices length is " + meshFilter.mesh.vertices.Length);
        for(int i = 0; i < vertices.Length; i++){
            Debug.Log(vertices[i]);
        }
        Debug.Log("kwjefhkljsfhwekljfhwekljfhwekljfh");
        int[] tris = meshFilter.mesh.triangles;
        Debug.Log("tris length is " + meshFilter.mesh.triangles.Length);
        // for(int i = 0; i < tris.Length; i+=3){
        //     Debug.Log(tris[i].ToString() + " " + tris[i].ToString() + " " + tris[i+2].ToString());
        // }
        for(int i = 0; i < meshFilter.mesh.triangles.Length; i++){
            Debug.Log(meshFilter.mesh.triangles[i]);
        }
    }
}