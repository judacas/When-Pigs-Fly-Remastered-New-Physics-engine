using UnityEngine;
public abstract class Constraint{
    public MassParticle a, b;
    Color color = new Color(Random.Range(0F,1F), Random.Range(0, 1F), Random.Range(0, 1F));


    public abstract bool work();

    public bool Equals(Constraint other){
        return ((this.a.Equals(other.a)) && (this.b.Equals(other.b))) || (this.a.Equals(other.b) && (this.b.Equals(other.a)));
    }

    public void Draw(){
        Gizmos.color = color;
        Gizmos.DrawLine(a.pos, b.pos);
    }
    public void Draw(Vector3 offset, Vector3 scale){
        Gizmos.color = color;
        Gizmos.DrawLine(new Vector3(a.pos.x * scale.x, a.pos.y * scale.y, a.pos.z * scale.z) + offset, new Vector3(b.pos.x * scale.x, b.pos.y * scale.y, b.pos.z * scale.z) + offset);
    }
}