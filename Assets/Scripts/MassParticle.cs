using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassParticle
{
    public Vector3 pos;
    static float radius = 1f;
    public float mass;

    Color color;
    public int[] constraintIndecies;




    /// <param name="pos">Position of particle</param>
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public MassParticle(Vector3 pos, float mass){
        this.pos = pos;
        this.mass = mass;
        // Debug.Log("made particle at " + pos);
        color = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));
    }


    public void Draw()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(pos, radius);
        // Debug.Log("drawing sphere at " + pos);
    }

    public void Draw(Vector3 offset, Vector3 scale)
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(new Vector3(pos.x * scale.x, pos.y * scale.y, pos.z * scale.z) + offset, radius);
        // Debug.Log("drawing sphere at " + pos);
    }

    public override string ToString(){
        return ("MassParticle at (" + pos);
    }

    public bool Equals(MassParticle other){
        return pos == other.pos && mass == other.mass;

    }
}