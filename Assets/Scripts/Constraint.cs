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
}