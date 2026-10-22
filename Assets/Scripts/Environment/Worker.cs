using System;

[Serializable]
public class Worker 
{
    public string name;
    public int id;
    public string lastEntranceInEngineRoom;

}
[Serializable]
public class WorkersArray 
{
    public Worker[] workers;

}