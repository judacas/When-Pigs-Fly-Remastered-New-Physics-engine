using UnityEngine;

public class Rectangle
{
    MassParticle[,,] particles;
    DistanceConstraint[,,,] distConsts;
    public float mass, damp, mpp;

    public int width, height, depth;

    public Vector3 position;

    //also add one where the distance between particles is not always 1f
    public Rectangle(Vector3 position, int x, int y, int z, int width, int height, int depth, float mass, float damp)
    {
        Debug.Log($"Made Rectangle");
        this.position = position;
        this.width = width; 
        this.height = height;
        this.depth = depth;
        this.mass = mass;
        this.mpp = mass / (this.width * this.height * this.depth);
        this.damp = damp;
        particles = new MassParticle[x,y,z];
        distConsts = new DistanceConstraint[x,y,z,27];
        setUpParticles();
        setUpDistanceConstraints();

    }

    public void setUpParticles(){
        for (int i = 0; i < particles.GetLength(0); i++)
        {
            for (int j = 0; j < particles.GetLength(1); j++)
            {
                for(int k = 0; k < particles.GetLength(2); k++){
                    particles[i,j,k] = new MassParticle(position + Vector3.right * i * width + Vector3.up * j * height + Vector3.forward * k * depth, mpp);
                }
            }
        }
    }

    public void setUpDistanceConstraints()
    {
        // float horizontalDistance = width / x;
        // float verticalDistance = height / y;
        // float depthDistance = depth / z;
        // float xyDiagonalDistance = MathF.Sqrt(MathF.Pow(horizontalDistance, 2) + MathF.Pow(verticalDistance, 2));
        // float xzDiagonalDistance = MathF.Sqrt(MathF.Pow(horizontalDistance, 2) + MathF.Pow(depthDistance, 2));
        // float xyzDiagonalDistance = MathF.Sqrt(MathF.Pow(horizontalDistance, 2) + MathF.Pow(verticalDistance, 2) + MathF.Pow(depthDistance, 2));
        for (int i = 0; i < particles.GetLength(0); i++)
        {
            for (int j = 0; j < particles.GetLength(1); j++)
            {
                for (int k = 0; k < particles.GetLength(2); k++)
                {


                    int count = 0;
                    for (int a = Mathf.Max(i-1, 0); a < Mathf.Min(i+1, particles.GetLength(0)); a++)
                    {
                        for (int b = Mathf.Max(j-1, 0); b < Mathf.Min(j+1, particles.GetLength(0)); b++)
                        {
                            for (int c = Mathf.Max(k-1, 0); c < Mathf.Min(k+1, particles.GetLength(0)); c++)
                            {
                                distConsts[i,j,k,count] = new DistanceConstraint(particles[i,j,k], particles[a,b,c], damp);
                                count++;
                            }
                        }
                    }


                }
            }
        }
    }

    public void Draw(){
        // Debug.Log($"DrawingRectangle");
        for (int i = 0; i < particles.GetLength(0); i++)
        {
            for (int j = 0; j < particles.GetLength(1); j++)
            {
                for(int k = 0; k < particles.GetLength(2); k++){
                    particles[i,j,k].Draw();
                    for (int x = 0; x < distConsts.GetLength(3); x++)
                    {
                        if (distConsts[i, j, k, x] != null)
                        {
                            distConsts[i, j, k, x].Draw();
                        }
                    }
                }
            }
        }
    }
}