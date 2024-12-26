namespace DalTest;
using DO;
using DalApi;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using Dal;
public static class Initialization

{//A private, static, resettable field of the type of any of the interfaces we defined !

    const int MIN_ID = 0;
    //stage1
    //private static IDependency? s_dalDependency=null;
    //private static IEngineer? s_dalEngineer = null;
    //private static ITask? s_dalTask = null;
    private static IDal? s_dal; //stage 2
    private static readonly Random s_rand = new();//Initialize the random field

    private static void createEngineers()//private static create method to initialize the list.
    {
        (string name, string email)[] engineerNames =
        {//An array from which we will extract the details
        ("Dani Levi","DaniLevi@gmail.com"),
        ("Eli Amar","EliAmar@gmail.com"),
        ("Yair Cohen","YairCohen@gmail.com"),
        ("Ariela Levin","ArielLevin@gmail.com"),
        ("Dina Klein", "DinaKlein@gmail.com"),
        ("Sara kol","Sarakol@gmail.com"),
        ("Shifra lof","Shifralof@gmail.com"),
        ("Shana jo","Shanajo@gmail.com")
    };

        foreach (var _engi in engineerNames)
        {
            EngineerExperience level;
            int _id;
            do
                _id = s_rand.Next(200000000, 400000000);//ID lottery
            while (s_dal!.Engineer!.Read(_id) != null);
            Enum.TryParse<EngineerExperience>((s_rand.Next(0, 3)).ToString(), out level);//Level lottery

            double cost = s_rand.Next(100000, 2000000);//Lottery cost per hour

            Engineer newEng = new(_id, _engi.name, _engi.email, level, cost);

            s_dal!.Engineer!.Create(newEng);//Creating a new engineer
        }
    }

    private static void createTasks()//private static create method to initialize the list.
    {
        (string description, string alias)[] engineerTasks =
        {//An array from which we will extract the details
            ("Making a diagram for the project", "Diagram"),
            ("Distribution of duties to employees", "Jobs"),
            ("Determining team meeting times", "Meetings"),
            ("Planning the Project Phases", "Phases"),
            ("measurement of lengths", "measurement"),
            ("Planning work in the field", "Planning"),
            ("Customer Service Management", "Customers"),
            ("Account Management", "Accounts"),
            ("Planning working hours", "Hours"),
            ("Lighting Installation", "Lighting"),
            ("room flooring", "flooring"),

    };

        foreach (var _task in engineerTasks)
        {
            int id = 0;
            int x;
            x = s_rand.Next(0, 10); //Random number draw
            bool _miles = (x % 2) == 0 ? true : false;//Milestone lottery
            int Engineerld = 0;
            DateTime CreatedAt = DateTime.Now;//Production date
            DateTime Start = CreatedAt.AddDays(s_rand.Next(0, 5));//Start Date lottery
            DateTime ScheduledDate = Start.AddDays(s_rand.Next(20, 60));//Estimated completion date lottery
            DateTime Deadline = ScheduledDate.AddDays(s_rand.Next(0, 6));//Final date for completion lottery
            DateTime Complete = Start.AddDays(s_rand.Next(10, 45));// Actual end date lottery

            string? Deliverables = null;//Initialize the product description with NULL
            string? Remarks = null;//Initialize comments with NULL
            EngineerExperience ComplexityLevel;//Difficulty level lottery
            Enum.TryParse<EngineerExperience>((s_rand.Next(0, 3)).ToString(), out ComplexityLevel);//הגרלת רמה
            Task newTask = new(id, _task.description, _task.alias, Engineerld, _miles,TimeSpan.FromDays(1), CreatedAt,  Start, ScheduledDate, Deadline, Complete, Deliverables, Remarks, ComplexityLevel);
            s_dal!.Task!.Create(newTask);//Creating a new task
        }
    }
    private static void createDependencys()//private static create method to initialize the Dependencys's list.
    {
        int sumOfTasks = s_dal!.Task!.ReadAll().Count();//Saving the number of existing tasks

        for (int depTaskId = 0; depTaskId < sumOfTasks; depTaskId++)//A loop that goes through all the tasks
        {
            int numOfDep = s_rand.Next(0, 3);// Lottery number of dependent tasks
            for (int i = depTaskId; i < depTaskId + numOfDep; i++)//For each task in the list
            {
                int depTask = s_rand.Next(depTaskId + 1, sumOfTasks);//The draw of the dependency tasks
                Dependency newDependency = new(0, depTaskId, depTask);
                s_dal!.Dependency!.Create(newDependency);//Creating a new dependency
            }
        }
    }
   
    //public static void Do(IDal dal) //stage 2
    public static void Do() //stage 4
    {

        //s_dalStudent = dalStudent ?? throw new NullReferenceException("DAL object can not be null!"); //stage 1
        //s_dalCourse = dalCourse ?? throw new NullReferenceException("DAL object can not be null!"); //stage 1
        //s_dalLink = dalStudentInCourse ?? throw new NullReferenceException("DAL object can not be null!"); //stage 1
        //s_dal = dal ?? throw new NullReferenceException("DAL object can not be null!"); //stage 2
        s_dal = DalApi.Factory.Get; //stage 4
        s_dal.Reset();
        createEngineers();
        createTasks();
        createDependencys();
    }
   // stage1
    //    public static void Do(IDependency? dalDependency,IEngineer? dalEngineer,ITask? dalTask)
    //    {
    //        //Defining a parameter for each interface type, and placing the parameters (+throw an error)
    //        s_dalDependency = dalDependency ?? throw new NullReferenceException("DAL can not be null!");
    //        s_dalEngineer = dalEngineer ?? throw new NullReferenceException("DAL can not be null!");
    //        s_dalTask = dalTask ?? throw new NullReferenceException("DAL can not be null!");
    //        //Calling the private methods
    //        createEngineers();
    //        createTasks();
    //        createDependencys();
    //    }
    //}
}
