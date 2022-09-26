using Godot;
using System;

public class Moha : KinematicBody
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public string PlayerName = "taha";
    public int score = 100;
    public  Vector3 velocity = new Vector3(0,0,0);
    public const int Speed = 5;   
    public const float RotationAngle = 0.1F;
    public override void _Ready(){
        GD.Print("Welcome " + PlayerName);   
    }
    public override void _PhysicsProcess(float delta){
        if(Input.IsActionPressed("ui_right") && Input.IsActionPressed("ui_left")){
            velocity.x = 0;
        }
        else if(Input.IsActionPressed("ui_right")){
            velocity.x = -Speed;
            GetNode<MeshInstance>("MeshInstance").RotateZ(RotationAngle);
        }
        else if(Input.IsActionPressed("ui_left")){
            velocity.x = Speed;
            GetNode<MeshInstance>("MeshInstance").RotateZ(-RotationAngle);
        }
        else {
            velocity.x = Mathf.Lerp(velocity.x,0,0.1F);
        }
        if(Input.IsActionPressed("ui_up") && Input.IsActionPressed("ui_down")){
            velocity.z = 0;
        }
        else if(Input.IsActionPressed("ui_up")){
            velocity.z = Speed;
            GetNode<MeshInstance>("MeshInstance").RotateX(RotationAngle);

        }
        else if(Input.IsActionPressed("ui_down")){
            velocity.z = -Speed;
            GetNode<MeshInstance>("MeshInstance").RotateX(-RotationAngle);
        }
        else {
            velocity.z = Mathf.Lerp(velocity.z,0,0.1F);
        }
        MoveAndSlide(velocity);
    }
    public void _on_Enemy_body_entered(Node body){
        if(body.Name.Equals("Moha")){
            GD.Print("Hit");
            GetTree().ChangeScene("res://GameOver.tscn");
        }

    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
