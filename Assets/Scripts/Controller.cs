using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour{

    public MassParticle[] particles = new MassParticle[12];
    public List<Constraint> constraints = new List<Constraint>();

    [Range(0, 1)]
    public float damp = 0.5f;

    [Range(0, 100)]
    public float randomness = 1f;

    [Range (0,100)]
    public int num = 10;

    int oldNum = 10;

    public static Rectangle rec;

    private void Awake()
    {
        // rec = new Rectangle(Vector3.zero, 10, 10, 10, 10, 10, 10, 20, 0.1f);
        //  particles[0] = (new MassParticle(new Vector3(-5,0,0), 5));
        // particles[1] = (new MassParticle(new Vector3( 5,0,0), 5));

        // float t = (1.0f + Mathf.Sqrt(5.0f)) / 2.0f;

        // particles[0] = (new MassParticle(new Vector3(-1,  t,  0), 5));
        // particles[1] = (new MassParticle(new Vector3( 1,  t,  0), 5));
        // particles[2] = (new MassParticle(new Vector3(-1, -t,  0), 5));
        // particles[3] = (new MassParticle(new Vector3( 1, -t,  0), 5));

        // particles[4] = (new MassParticle(new Vector3( 0, -1,  t), 5));
        // particles[5] = (new MassParticle(new Vector3( 0,  1,  t), 5));
        // particles[6] = (new MassParticle(new Vector3( 0, -1, -t), 5));
        // particles[7] = (new MassParticle(new Vector3( 0,  1, -t), 5));

        // particles[8] = (new MassParticle(new Vector3( t,  0, -1), 5));
        // particles[9] = (new MassParticle(new Vector3( t,  0,  1), 5));
        // particles[10] = (new MassParticle(new Vector3(-t,  0, -1), 5));
        // particles[11] = (new MassParticle(new Vector3(-t,  0,  1), 5));
        // randomSetup();
    }




    private void FixedUpdate()
    {
        // rec.work();

        // if(oldNum != num){
        //     randomSetup();
        // }
        // foreach (DistanceConstraint constraint in constraints)
        // {
        //     constraint.work();
        //     constraint.changeDamp(damp);
        // }
    }

    /// <summary>
    /// Callback to draw gizmos that are and always drawn.
    /// </summary>
    private void OnDrawGizmos()
    {
        if (rec != null)
        {
            rec.Draw();
        }
        if(particles != null){
            foreach (MassParticle particle in particles)
            {
                if (particle != null)
                {
                    particle.Draw();
                }
            }

        }
        if(constraints != null){
            foreach (Constraint constraint in constraints){
                constraint.Draw();
            }
        }
    }


    void randomSetup(){

        particles = new MassParticle[num];
        constraints = new List<Constraint>();
        for(int i = 0; i < particles.Length; i++){
            particles[i] = new MassParticle(new Vector3(Random.Range(-randomness,randomness), Random.Range(-randomness,randomness), Random.Range(-randomness,randomness)), 5);

        }
        foreach (MassParticle particle in particles){
            foreach (MassParticle particle2 in particles){
                if (particle2 != particle){
                    bool found = false;
                    Constraint temp = new DistanceConstraint(particle2, particle, 5f, damp*Random.Range(0.0f,1f));
                    foreach (Constraint constraint in constraints)
                    {
                        if (constraint.Equals(temp)){
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        constraints.Add(temp);
                    }
                }

            }

        }
        oldNum = num;
    }


}