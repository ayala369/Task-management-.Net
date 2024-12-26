
using DalApi;
using DO;

//נותן לקלוט ערך ריק ומעדכן בערך ריק
//לעשות ירקרקים
//האם זה בעיה שאפשר להכניס תלות על משימה שלא קיימת
//  DalList1 דבר רשאשון שינינו את שם המחלקה ל 
namespace DalTest;
internal class Program
{
    //private static IDependency? s_dalDependency = new DependencyImplementation(); //stage 1
    //private static IEngineer? s_dalEngineer = new EngineerImplementation(); //stage 1
    //private static ITask? s_dalTask = new TaskImplementation(); //stage 1
    //private static readonly IDal s_dal = new DalList();//stage 2
    //static readonly IDal s_dal = new DalXml(); //stage 3
    static readonly IDal s_dal = Factory.Get; //stage 4



    public static void InfoOfEngineer(char x)
    {
            switch (x)
            {
            case '0':
                break;
                case 'a'://add
                    Console.WriteLine("enter Engineer's id to add");
                    int Id = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("enter Engineer's name");
                    string? Name = Console.ReadLine();
                    Console.WriteLine("enter Engineer's email");
                    string? Email = (Console.ReadLine());
                    Console.WriteLine("enter Engineer's level(0-for expert,1-for Junior,2-for Rookie)");
                    EngineerExperience? Level = (EngineerExperience)int.Parse(Console.ReadLine()!);
                    Console.WriteLine("enter Engineer's Cost");
                    double? Cost = double.Parse(Console.ReadLine()!);
                    Engineer e = new Engineer(Id, Name!, Email!, Level, Cost);
                    try
                    {
                        int result = s_dal!.Engineer.Create(e);
                        Console.WriteLine("the engineer was added");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;

                case 'b'://read by id
                    Console.WriteLine("enter engineer's id to read");
                    int id = int.Parse(Console.ReadLine()!);
                    try
                    {
                        Console.WriteLine(s_dal!.Engineer.Read(id));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                case 'c'://read all
                    Console.WriteLine("all the engineers:");
                var listReadAllEngineers = s_dal!.Engineer.ReadAll();
                    foreach (var item in listReadAllEngineers)
                        Console.WriteLine(item);
                    break;
                case 'd'://update
                    Console.WriteLine("enter id of engineer to update");
                    int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
                    try
                    {
                        Console.WriteLine(s_dal!.Engineer.Read(idUpdate));
                        int _id = idUpdate;
                        Console.WriteLine("enter Engineer's name");
                        string? _name = Console.ReadLine();
                        Console.WriteLine("enter Engineer's email");
                        string? _email = (Console.ReadLine());
                        Console.WriteLine("enter Engineer's level(0-for expert,1-for Junior,2-for Rookie)");
                        EngineerExperience? _level = (EngineerExperience)int.Parse(Console.ReadLine()!);
                        Console.WriteLine("enter Engineer's Cost");
                        double? _cost = double.Parse(Console.ReadLine()!);
                        Engineer eUpdate = new Engineer(_id, _name!, _email!, _level, _cost);
                    s_dal.Engineer.Update(eUpdate);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                case 'e'://delete a product
                    Console.WriteLine("enter id of engineer to delete");
                    int idDelete = int.Parse(Console.ReadLine()!);
                    try
                    {
                    s_dal!.Engineer.Delete(idDelete);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                default:
                    break;
            }
        //___________________________________________________________________________________________________
    }
    public static void InfoOfTask(char x)
    {
        switch (x)
        {
            case '0':
                break;
            case 'a'://add
                Console.WriteLine("enter task's description");
                string _description = Console.ReadLine()!;
                Console.WriteLine("enter task's alias");
                string _alias = Console.ReadLine()!;
                Console.WriteLine("enter task's engineerld");
                int _engineerld = int.Parse(Console.ReadLine()!);
                Console.WriteLine("enter task's milestone");
                bool _milestone = bool.Parse(Console.ReadLine()!);
                Console.WriteLine("enter task's date of created");
                DateTime _createdAt = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("enter task's date of start");
                DateTime? _start = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("enter task's date of scheduled");
                DateTime? _scheduledDate = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("enter task's date of deadline");
                DateTime? _deadline = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("enter task's date of complete");
                DateTime? _complete = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("enter task's deliverables");
                string? _deliverables = Console.ReadLine();
                Console.WriteLine("enter task's remarks");
                string? _remarks = Console.ReadLine();
                Console.WriteLine("enter task's level(0-for expert,1-for Junior,2-for Rookie)");
                EngineerExperience? _complexityLevel = (EngineerExperience)int.Parse(Console.ReadLine()!);
                DO.Task t  = new DO.Task(123,_description, _alias, _engineerld, _milestone, TimeSpan.FromDays(1), _createdAt, _start, _scheduledDate, _deadline, _complete, _deliverables, _remarks, _complexityLevel);
                try
                {
                    s_dal!.Task.Create(t);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            case 'b'://read by id
                Console.WriteLine("enter task's id to read");
                int id = int.Parse(Console.ReadLine()!);
                try
                {
                    Console.WriteLine(s_dal!.Task.Read(id));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            case 'c'://read all
                Console.WriteLine("all the tasks:");
                var listReadAllTasks = s_dal!.Task.ReadAll();
                foreach (var item in listReadAllTasks)
                    Console.WriteLine(item);
                break;
            case 'd'://update!!
                Console.WriteLine("enter id of task to update");
                int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
                try
                {
                    Console.WriteLine(s_dal?.Task.Read(idUpdate));
                    int _id = idUpdate;
                    Console.WriteLine("enter task's description");
                    string description = Console.ReadLine()!;
                    Console.WriteLine("enter task's alias");
                    string alias = Console.ReadLine()!;
                    Console.WriteLine("enter task's engineerld");
                    int engineerld = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("enter task's milestone");
                    bool milestone = bool.Parse(Console.ReadLine()!);
                    Console.WriteLine("enter task's date of created");
                    DateTime createdAt = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("enter task's date of start");
                    DateTime? start = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("enter task's date of scheduled");
                    DateTime? scheduledDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("enter task's date of deadline");
                    DateTime? deadline = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("enter task's date of complete");
                    DateTime? complete = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("enter task's deliverables");
                    string? deliverables = Console.ReadLine();
                    Console.WriteLine("enter task's remarks");
                    string? remarks = Console.ReadLine();
                    Console.WriteLine("enter task's level(0-for expert,1-for Junior,2-for Rookie)");
                    EngineerExperience? complexityLevel = (EngineerExperience)int.Parse(Console.ReadLine()!);
                    DO.Task tUpdate = new DO.Task(_id, description,alias, engineerld, milestone, TimeSpan.FromDays(1), createdAt, start, scheduledDate, deadline, complete, deliverables, remarks, complexityLevel);
                    s_dal!.Task.Update(tUpdate);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            case 'e'://delete an order
                Console.WriteLine("enter id of task to delete");
                int idDelete = int.Parse(Console.ReadLine()!);
                try
                {
                    s_dal?.Task.Delete(idDelete);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            default:
                break;
        }
    }
    //______________________________________________________________________________________

    public static void InfoOfDependency(char x)
    {
        switch (x)
        {
            case '0':
                break;
            case 'a'://add
                Console.WriteLine("enter dependent task's id");
                int _dependentTask = int.Parse(Console.ReadLine()!);
                Console.WriteLine("enter depends on task's id");
               int _dependsOnTask = int.Parse(Console.ReadLine()!);
                Dependency dep = new Dependency(121,_dependentTask,_dependsOnTask);
                try
                {
                    s_dal?.Dependency.Create(dep);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            case 'b'://read by id
                Console.WriteLine("enter dependency's id to read");
                int id = int.Parse(Console.ReadLine()!);
                try
                {
                    Console.WriteLine(s_dal?.Dependency.Read(id));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            case 'c'://read all
                Console.WriteLine("all the dependencys:");
                var listReadAllDependencys = s_dal!.Dependency.ReadAll();
                foreach (var item in listReadAllDependencys)
                    Console.WriteLine(item);
                break;
            case 'd'://update
                Console.WriteLine("enter id of dependency to update");
                int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
                try
                {
                    Console.WriteLine(s_dal?.Dependency.Read(idUpdate));
                    int _id = idUpdate;
                    Console.WriteLine("enter dependent task's id");
                    int dependentTask = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("enter depends on task's id");
                    int dependsOnTask = int.Parse(Console.ReadLine()!);
                    Dependency depUpdate = new Dependency(_id, dependentTask, dependsOnTask);
                    s_dal!.Dependency.Update(depUpdate);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            case 'e'://delete
                Console.WriteLine("enter dependency's id to delete");
                int idDelete = int.Parse(Console.ReadLine()!);
                try
                {
                    s_dal!.Dependency.Delete(idDelete);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                break;
            default:
                break;
        }
    }
    static void Main(string[] args)
    {
        try
        {
    
            Console.Write("Would you like to create Initial data? (Y/N)"); //stage 3
            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3
            if (ans == "Y")
            { //stage 3
              //Initialization.Do(s_dal); //stage 2
                s_dal.Reset();
             Initialization.Do(); //stage 4
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR RESET" + ex);
        }

        Console.WriteLine("for Engineer press1");
        Console.WriteLine("for Task press 2");
        Console.WriteLine("for Dependency press 3");
        Console.WriteLine("for exit press 0");
        int select = int.Parse(Console.ReadLine()!);
        char x;
        while (select != 0)
        {
            switch (select)
            {
                case 1:
                    Console.WriteLine("for exit press 0");//!!!!!!
                    Console.WriteLine("for add a Engineer press a");
                    Console.WriteLine("for read a Engineer press b");
                    Console.WriteLine("for read all Engineers press c");
                    Console.WriteLine("for update a Engineer press d");
                    Console.WriteLine("for delete a Engineer press e");
                    x = char.Parse(Console.ReadLine()!);
                    InfoOfEngineer(x);//doing this function 
                    break;
                case 2:
                    Console.WriteLine("for exit press 0");//!!!!!!
                    Console.WriteLine("for add a Task press a");
                    Console.WriteLine("for read a Task press b");
                    Console.WriteLine("for read all Tasks press c");
                    Console.WriteLine("for update a Task press d");
                    Console.WriteLine("for delete a Task press e");
                    x = char.Parse(Console.ReadLine()!);
                    InfoOfTask(x); //doing this function 
                    break;
                case 3:
                    Console.WriteLine("for exit press 0");//!!!!!!
                    Console.WriteLine("for add a dependency press a");
                    Console.WriteLine("for read dependency press b");
                    Console.WriteLine("for read all dependencys press c");
                    Console.WriteLine("for update a dependency press d");
                    Console.WriteLine("for delete a dependency press e");
                    x = char.Parse(Console.ReadLine()!);
                    InfoOfDependency(x);//doing this function 
                    
                    break;
                default:
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("enter a number:");
            Console.WriteLine("for Engineer press 1");
            Console.WriteLine("for Task press 2");
            Console.WriteLine("for Dependency press 3");
            Console.WriteLine("for exit press 0");
            select = int.Parse(Console.ReadLine()!);
        }

    }
}


