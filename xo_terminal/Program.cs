using System;
class Program
{
    public static void Main(string[] args)
    {
        Model model = new Model();
        View view = new View(model);
        Controller controller = new Controller(model, view);
        controller.StartUp();
        
    }
}