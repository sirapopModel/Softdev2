using System;
class Program
{
    public static void Main(string[] args)
    {
        Model Model = new Model();
        View View = new View();
        Controller Controller = new Controller(Model, View);
        Controller.StartUp();
        
    }
}