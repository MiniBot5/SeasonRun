using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CarChanger
{
    private Car _currentCar = null;
    

    public Car ChangeCar(Car targetCar, Car currentCar)
    {
        return targetCar != currentCar ? targetCar : currentCar;
    }



}
public class Car
{
    public string Name;
    public bool NonSlip;
    public bool grassShield;
    public int ID;
    public Car(string name, bool nonSlip, bool grassShield, int ID) 
    {
    }
}
