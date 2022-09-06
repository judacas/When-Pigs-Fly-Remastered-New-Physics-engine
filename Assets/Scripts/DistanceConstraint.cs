using UnityEngine;
public class DistanceConstraint : Constraint{
    /// <summary>
    /// targetDistance
    /// </summary>
    public float td, damp;


    public DistanceConstraint(MassParticle a, MassParticle b) {
        this.a = a;
        this.b = b;
        this.td = (a.pos - b.pos).magnitude;
        damp = 1f;
        // Debug.Log(this);

    }

    // //todo: if need be make game run faster by avoiding square roots with distances and stuff
    public DistanceConstraint(MassParticle a, MassParticle b, float dampeningFactor) {
        this.a = a;
        this.b = b;
        this.td = (a.pos - b.pos).magnitude;
        this.damp = dampeningFactor;
        // Debug.Log(this);

    }

    public DistanceConstraint(MassParticle a, MassParticle b, float targetDistance, float dampeningFactor) {
        this.a = a;
        this.b = b;
        this.td = targetDistance;
        this.damp = dampeningFactor;
        // Debug.Log(this);

    }

    // //todo: right now returns true so later if returns false then we know we didn't move a or b and don't have to calculate distance next time unless some other constraint changed them
    public  override  bool work(){
        if (a != null && b != null)
        {
            float currentDistance = (b.pos - a.pos).magnitude;
            // Debug.Log("working on constraint");
            if (currentDistance != td)
            {
                float fix = (currentDistance - td)/2;
                Vector3 dirNorm = (b.pos - a.pos)/currentDistance;
                // Debug.Log("constraint needs work for " + fix + this);
                if(Mathf.Abs(fix/td)<0.005f){
                    a.pos += dirNorm * fix;
                    b.pos -= dirNorm * fix;    
                }
                else
                {
                    a.pos += dirNorm * fix * damp;
                    b.pos -= dirNorm * fix * damp;
                }
                return true;
            }
            else{
                // Debug.Log("constraint is already satisfied" + this);
                return false;

            }    
        }
        else{
            // Debug.Log("Something is null while working on constraint" + this);
            return false;

        }

    }


    public override string ToString(){
        return "Constraint from" + a + " to " + b;
    }

    public void changeDamp(float damp){
        this.damp = damp;
    }

}