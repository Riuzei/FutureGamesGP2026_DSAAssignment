using System;
using System.Collections.Generic;

[Serializable]
public class Employee 
{
    public string Name;
    public int EmployeeId;
    public bool HasEngineRoomClearance;
    public string LastEntranceInEngineRoom;
    public string LastExitFromEngineRoom;
}
[Serializable]
public class EmployeesArray 
{
    public Employee[] Employees;

}
public class EmployeeEntranceComparer : IComparer<Employee>
{
    public int Compare(Employee x, Employee y)
    {
        return x.LastEntranceInEngineRoom.CompareTo(y.LastEntranceInEngineRoom);
    }
}