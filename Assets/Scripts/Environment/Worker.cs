using System;

[Serializable]
public class Worker 
{
    public string name;
    public int employeeId;
    public bool hasEngineRoomClearance;
    public string lastEntranceInEngineRoom;
    public string lastExitFromEngineRoom;
}
[Serializable]
public class WorkersArray 
{
    public Worker[] workers;

}