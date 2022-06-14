using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotProgramOrder
{
    // types: 1 = Waypoint, 2 = Wait, 3 = Set
    int type;

    int orderIndex;
    List<Quaternion> jointRotationValues;
    float waitTime = 0;


    public RobotProgramOrder(int type, int orderIndex, List<Quaternion> jointValues)
    {
        this.Type = type;
        this.OrderIndex = orderIndex;
        this.JointRotationValues = jointValues;
    }
    public int Type { get => type; set => type = value; }
    public int OrderIndex { get => orderIndex; set => orderIndex = value; }
    public List<Quaternion> JointRotationValues { get => jointRotationValues; set => jointRotationValues = value; }
    public float WaitTime { get => waitTime; set => waitTime = value; }
}
