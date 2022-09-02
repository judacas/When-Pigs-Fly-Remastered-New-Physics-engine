using System;
using UnityEngine;

public class Rectangle
{
    MassParticle[][][] particles;
    DistanceConstraints[][][][] distConsts;
    public float mass;

    public int width, height, depth;

    //also add one where the distance between particles is not always 1f
    public Rectangle(Vector3 pos, int x, int y, int z, int width, int height, int depth, float mass)
    {
        Debug.Log($"Made Rectangle");
        this.width = width; 
        this.height = height;
        this.depth = depth;
        this.mass = mass;
        float mpp = mass / (this.width * this.height * this.depth);
        particles = new MassParticle[x][y][z];
        distConsts = new DistanceConstraint[x][y][z][3];
        setUpParticles();
        setUpDistanceConstraints();

    }

    public void setUpParticles(){
        for (int i = 0; i < particles.Length; i++)
        {
            for (int j = 0; j < particles[i].Length; j++)
            {
                for(int k = 0; k < particles[i][j].Length; k++){
                    particles[i][j][k] = new MassParticle(pos + Vector3.right * i * w + Vector3.up * j * h + Vector3.forward * k * d, mpp);
                }
            }
        }
    }

    public void setUpDistanceConstraints()
    {
        float horizontalDistance = width / x;
        float verticalDistance = height / y;
        float depthDistance = depth / z;
        float xyDiagonalDistance = MathF.Sqrt(MathF.Pow(horizontalDistance, 2) + MathF.Pow(verticalDistance, 2));
        float xzDiagonalDistance = MathF.Sqrt(MathF.Pow(horizontalDistance, 2) + MathF.Pow(depthDistance, 2));
        float xyzDiagonalDistance = MathF.Sqrt(MathF.Pow(horizontalDistance, 2) + MathF.Pow(verticalDistance, 2) + MathF.Pow(depthDistance, 2));
        for (int i = 0; i < particles.Length - 1; i++)
        {
            for (int j = 0; j < particles[i].Length - 1; j++)
            {
                for (int k = 0; k < particles[i][j].Length; k++)
                {
                    distConsts[i][j][k][0] = new DistanceConstraint(particles[i][j][k], particles[i+1][j][k], )
                }
            }
        }
    }

    public void Draw(){
        for (int i = 0; i < particles.Length; i++)
        {
            for (int j = 0; j < particles[i].Length; j++)
            {
                for(int k = 0; k < particles[i][j].Length; k++){
                    particles[i][j][k].Draw();
                }
            }
        }
    }
}