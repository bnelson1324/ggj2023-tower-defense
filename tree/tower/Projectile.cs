using Godot;
using roottowerdefense.enemy;

namespace roottowerdefense.tree.tower;

public partial class Projectile : Area2D
{
    private int _damage;
    private float _aoeRadius;
    private float _velocity;

    public override void _Ready()
    {
        AreaEntered += (other) =>
        {
            var otherParent = other.GetParent();
            if (otherParent is Enemy enemy)
            {
                enemy.Health -= _damage;
                // todo: implement damaging all enemies in aoeRadius if aoeRadius != 0
                QueueFree();
            }
        };

    }

    public override void _Process(double delta)
    {
        GlobalPosition += GlobalTransform.X * _velocity * (float)delta;
    }

    public void Launch(int damage, float velocity, float aoeRadius)
    {
        _damage = damage;
        _velocity = velocity;
        _aoeRadius = aoeRadius;
    }
}
