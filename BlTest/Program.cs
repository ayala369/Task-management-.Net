//using BlApi;
//using DalApi;
//using DO;
//namespace BlTest
//{
//    internal class Program
//    {
//        //static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
//        static readonly IBl s_bl = BlApi.Factory.Get(); //stage 4

//        public static void InfoOfEngineer(char x)
//        {
//            switch (x)
//            {
//                case '0':
//                    break;
//                case 'a'://add
//                    Console.WriteLine("enter Engineer's id to add");
//                    int Id = int.Parse(Console.ReadLine()!);
//                    Console.WriteLine("enter Engineer's name");
//                    string? Name = Console.ReadLine();
//                    Console.WriteLine("enter Engineer's email");
//                    string? Email = (Console.ReadLine());
//                    Console.WriteLine("enter Engineer's level(0-for expert,1-for Junior,2-for Rookie)");
//                    EngineerExperience? Level = (EngineerExperience)int.Parse(Console.ReadLine()!);
//                    Console.WriteLine("enter Engineer's Cost");
//                    double? Cost = double.Parse(Console.ReadLine()!);
//                    Engineer e = new Engineer(Id, Name!, Email!, Level, Cost);
//                    try
//                    {
//                        int result = s_bl!.Engineer.Create(e);
//                        Console.WriteLine("the engineer was added");
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;

//                case 'b'://read by id
//                    Console.WriteLine("enter engineer's id to read");
//                    int id = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        Console.WriteLine(s_bl!.Engineer.Read(id));
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'c'://read all
//                    Console.WriteLine("all the engineers:");
//                    var listReadAllEngineers = s_bl!.Engineer.ReadAll();
//                    foreach (var item in listReadAllEngineers)
//                        Console.WriteLine(item);
//                    break;
//                case 'd'://update
//                    Console.WriteLine("enter id of engineer to update");
//                    int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
//                    try
//                    {
//                        Console.WriteLine(s_bl!.Engineer.Read(idUpdate));
//                        int _id = idUpdate;
//                        Console.WriteLine("enter Engineer's name");
//                        string? _name = Console.ReadLine();
//                        Console.WriteLine("enter Engineer's email");
//                        string? _email = (Console.ReadLine());
//                        Console.WriteLine("enter Engineer's level(0-for expert,1-for Junior,2-for Rookie)");
//                        EngineerExperience? _level = (EngineerExperience)int.Parse(Console.ReadLine()!);
//                        Console.WriteLine("enter Engineer's Cost");
//                        double? _cost = double.Parse(Console.ReadLine()!);
//                        Engineer eUpdate = new Engineer(_id, _name!, _email!, _level, _cost);
//                        s_bl.Engineer.Update(eUpdate);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'e'://delete a product
//                    Console.WriteLine("enter id of engineer to delete");
//                    int idDelete = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        s_bl!.Engineer.Delete(idDelete);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                default:
//                    break;
//            }
//            //___________________________________________________________________________________________________
//        }
//        public static void InfoOfTask(char x)
//        {
//            switch (x)
//            {
//                case '0':
//                    break;
//                case 'a'://add
//                    Console.WriteLine("enter task's description");
//                    string _description = Console.ReadLine()!;
//                    Console.WriteLine("enter task's alias");
//                    string _alias = Console.ReadLine()!;
//                    Console.WriteLine("enter task's engineerld");
//                    int _engineerld = int.Parse(Console.ReadLine()!);
//                    Console.WriteLine("enter task's milestone");
//                    bool _milestone = bool.Parse(Console.ReadLine()!);
//                    Console.WriteLine("enter task's date of created");
//                    DateTime _createdAt = Convert.ToDateTime(Console.ReadLine());
//                    Console.WriteLine("enter task's date of start");
//                    DateTime? _start = Convert.ToDateTime(Console.ReadLine());
//                    Console.WriteLine("enter task's date of scheduled");
//                    DateTime? _scheduledDate = Convert.ToDateTime(Console.ReadLine());
//                    Console.WriteLine("enter task's date of deadline");
//                    DateTime? _deadline = Convert.ToDateTime(Console.ReadLine());
//                    Console.WriteLine("enter task's date of complete");
//                    DateTime? _complete = Convert.ToDateTime(Console.ReadLine());
//                    Console.WriteLine("enter task's deliverables");
//                    string? _deliverables = Console.ReadLine();
//                    Console.WriteLine("enter task's remarks");
//                    string? _remarks = Console.ReadLine();
//                    Console.WriteLine("enter task's level(0-for expert,1-for Junior,2-for Rookie)");
//                    EngineerExperience? _complexityLevel = (EngineerExperience)int.Parse(Console.ReadLine()!);
//                    DO.Task t = new DO.Task(123, _description, _alias, _engineerld, _milestone, TimeSpan.FromDays(1), _createdAt, _start, _scheduledDate, _deadline, _complete, _deliverables, _remarks, _complexityLevel);
//                    try
//                    {
//                        s_bl!.Task.Create(t);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'b'://read by id
//                    Console.WriteLine("enter task's id to read");
//                    int id = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        Console.WriteLine(s_bl!.Task.Read(id));
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'c'://read all
//                    Console.WriteLine("all the tasks:");
//                    var listReadAllTasks = s_bl!.Task.ReadAll();
//                    foreach (var item in listReadAllTasks)
//                        Console.WriteLine(item);
//                    break;
//                case 'd'://update!!
//                    Console.WriteLine("enter id of task to update");
//                    int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
//                    try
//                    {
//                        Console.WriteLine(s_bl?.Task.Read(idUpdate));
//                        int _id = idUpdate;
//                        Console.WriteLine("enter task's description");
//                        string description = Console.ReadLine()!;
//                        Console.WriteLine("enter task's alias");
//                        string alias = Console.ReadLine()!;
//                        Console.WriteLine("enter task's engineerld");
//                        int engineerld = int.Parse(Console.ReadLine()!);
//                        Console.WriteLine("enter task's milestone");
//                        bool milestone = bool.Parse(Console.ReadLine()!);
//                        Console.WriteLine("enter task's date of created");
//                        DateTime createdAt = Convert.ToDateTime(Console.ReadLine());
//                        Console.WriteLine("enter task's date of start");
//                        DateTime? start = Convert.ToDateTime(Console.ReadLine());
//                        Console.WriteLine("enter task's date of scheduled");
//                        DateTime? scheduledDate = Convert.ToDateTime(Console.ReadLine());
//                        Console.WriteLine("enter task's date of deadline");
//                        DateTime? deadline = Convert.ToDateTime(Console.ReadLine());
//                        Console.WriteLine("enter task's date of complete");
//                        DateTime? complete = Convert.ToDateTime(Console.ReadLine());
//                        Console.WriteLine("enter task's deliverables");
//                        string? deliverables = Console.ReadLine();
//                        Console.WriteLine("enter task's remarks");
//                        string? remarks = Console.ReadLine();
//                        Console.WriteLine("enter task's level(0-for expert,1-for Junior,2-for Rookie)");
//                        EngineerExperience? complexityLevel = (EngineerExperience)int.Parse(Console.ReadLine()!);
//                        DO.Task tUpdate = new DO.Task(_id, description, alias, engineerld, milestone, TimeSpan.FromDays(1), createdAt, start, scheduledDate, deadline, complete, deliverables, remarks, complexityLevel);
//                        s_bl!.Task.Update(tUpdate);

//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'e'://delete an order
//                    Console.WriteLine("enter id of task to delete");
//                    int idDelete = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        s_bl?.Task.Delete(idDelete);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                default:
//                    break;
//            }
//        }
//        //______________________________________________________________________________________

//        public static void InfoOfDependency(char x)
//        {
//            switch (x)
//            {
//                case '0':
//                    break;
//                case 'a'://add
//                    Console.WriteLine("enter dependent task's id");
//                    int _dependentTask = int.Parse(Console.ReadLine()!);
//                    Console.WriteLine("enter depends on task's id");
//                    int _dependsOnTask = int.Parse(Console.ReadLine()!);
//                    Dependency dep = new Dependency(121, _dependentTask, _dependsOnTask);
//                    try
//                    {
//                        s_bl?.Dependency.Create(dep);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'b'://read by id
//                    Console.WriteLine("enter dependency's id to read");
//                    int id = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        Console.WriteLine(s_bl?.Dependency.Read(id));
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'c'://read all
//                    Console.WriteLine("all the dependencys:");
//                    var listReadAllDependencys = s_bl!.Dependency.ReadAll();
//                    foreach (var item in listReadAllDependencys)
//                        Console.WriteLine(item);
//                    break;
//                case 'd'://update
//                    Console.WriteLine("enter id of dependency to update");
//                    int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
//                    try
//                    {
//                        Console.WriteLine(s_bl?.Dependency.Read(idUpdate));
//                        int _id = idUpdate;
//                        Console.WriteLine("enter dependent task's id");
//                        int dependentTask = int.Parse(Console.ReadLine()!);
//                        Console.WriteLine("enter depends on task's id");
//                        int dependsOnTask = int.Parse(Console.ReadLine()!);
//                        Dependency depUpdate = new Dependency(_id, dependentTask, dependsOnTask);
//                        s_bl!.Dependency.Update(depUpdate);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'e'://delete
//                    Console.WriteLine("enter dependency's id to delete");
//                    int idDelete = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        s_bl!.Dependency.Delete(idDelete);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                default:
//                    break;
//            }
//        }
//        static void Main(string[] args)
//        {
//            try
//            {

//                Console.Write("Would you like to create Initial data? (Y/N)"); //stage 3
//                string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3
//                if (ans == "Y")
//                {
//                    DalTest.Initialization.Do();
//                    ////////
//                    //s_bl.Reset();
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("ERROR RESET" + ex);
//            }

//            Console.WriteLine("for Engineer press1");
//            Console.WriteLine("for Task press 2");
//            Console.WriteLine("for Milestone press 3");
//            Console.WriteLine("for exit press 0");
//            int select = int.Parse(Console.ReadLine()!);
//            char x;
//            while (select != 0)
//            {
//                switch (select)
//                {
//                    case 1:
//                        Console.WriteLine("for exit press 0");//!!!!!!
//                        Console.WriteLine("for add a Engineer press a");
//                        Console.WriteLine("for read a Engineer press b");
//                        Console.WriteLine("for read all Engineers press c");
//                        Console.WriteLine("for update a Engineer press d");
//                        Console.WriteLine("for delete a Engineer press e");
//                        x = char.Parse(Console.ReadLine()!);
//                        InfoOfEngineer(x);//doing this function 
//                        break;
//                    case 2:
//                        Console.WriteLine("for exit press 0");//!!!!!!
//                        Console.WriteLine("for add a Task press a");
//                        Console.WriteLine("for read a Task press b");
//                        Console.WriteLine("for read all Tasks press c");
//                        Console.WriteLine("for update a Task press d");
//                        Console.WriteLine("for delete a Task press e");
//                        x = char.Parse(Console.ReadLine()!);
//                        InfoOfTask(x); //doing this function 
//                        break;
//                    case 3:
//                        Console.WriteLine("for exit press 0");//!!!!!!
//                        Console.WriteLine("for add a Milestone press a");
//                        Console.WriteLine("for read Milestone press b");
//                        Console.WriteLine("for update a Milestone press c");
//                        x = char.Parse(Console.ReadLine()!);
//                        InfoOfDependency(x);//doing this function 

//                        break;
//                    default:
//                        break;
//                }
//                Console.WriteLine("");
//                Console.WriteLine("enter a number:");
//                Console.WriteLine("for Engineer press 1");
//                Console.WriteLine("for Task press 2");
//                Console.WriteLine("for Milestone press 3");
//                Console.WriteLine("for exit press 0");
//                select = int.Parse(Console.ReadLine()!);
//            }

//        }
//    }
//}

///*using DalApi;
//using DalTest;


//namespace BlTest
//{
//    internal class Program
//    {
//        static readonly BlApi.IBl s_bl = BlApi.Factory.Get();
//        static void InfoOfTask(char x)
//        {
//            switch (x)
//            {
//                case 'a': break;
//                case 'b'://add                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            t = new Task();
//                    Console.WriteLine("enter task alias");
//                    string alias = Console.ReadLine()!;
//                    Console.WriteLine("enter task's description");
//                    string description = Console.ReadLine()!;
//                    Console.WriteLine("enter task's Deliverables");
//                    string deliverables = Console.ReadLine()!;
//                    Console.WriteLine("enter task's Remarks");
//                    string remarks = Console.ReadLine()!;
//                    Console.WriteLine("enter task's EngineerExperience required");
//                    Console.WriteLine("enter engineer's level from 0- to 4");
//                    int? level = int.Parse(Console.ReadLine()!);
//                    BO.EngineerExperience enLevel;
//                    bool b = Enum.TryParse<BO.EngineerExperience>(level.ToString(), out enLevel);
//                    if (!b)
//                        throw new Exception("I tell you to put between 0 to 4");
//                    BO.Task task = new BO.Task()
//                    {
//                        Id = 4,
//                        Description = description,
//                        Alias = alias,
//                        CreatedAtDate = DateTime.Now,
//                        Status = 0,
//                        Dependencies = null,
//                        Milestone = null,
//                        BaselineStartDate = null,
//                        StartDate = null,
//                        ForecastDate = null,
//                        DeadlineDate = null,
//                        CompleteDate = null,
//                        Deliverables = deliverables,
//                        Remarks = remarks,
//                        Engineer = null,
//                        ComplexityLevel = enLevel
//                    };
//                    try
//                    {
//                        int result = s_bl.Task.Create(task);
//                        Console.WriteLine("the task was added");
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'c'://read by id
//                    Console.WriteLine("enter tasks's id to read");
//                    int id = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        Console.WriteLine(s_bl.Task.Read(id)!.ToString());
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'd'://read all
//                    Console.WriteLine("all the tasks:");
//                    var arrReadAllTasks = s_bl.Task.ReadAll();
//                    foreach (var item in arrReadAllTasks)
//                        Console.WriteLine(item.ToString());
//                    break;
//                case 'e'://update
//                    Console.WriteLine("enter id of task to update");
//                    int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
//                    try
//                    {
//                        Console.WriteLine("enter task alias");
//                        string ualias = Console.ReadLine()!;
//                        Console.WriteLine("enter task's description");
//                        string udescription = Console.ReadLine()!;
//                        Console.WriteLine("enter task's Deliverables");
//                        string udeliverables = Console.ReadLine()!;
//                        Console.WriteLine("enter task's Remarks");
//                        string uremarks = Console.ReadLine()!;
//                        Console.WriteLine("enter task's EngineerExperience required");
//                        Console.WriteLine("enter engineer's level from 0- to 4");
//                        int? ulevel = int.Parse(Console.ReadLine()!);
//                        BO.EngineerExperience uenLevel;
//                        bool bo = Enum.TryParse<BO.EngineerExperience>(ulevel.ToString(), out uenLevel);
//                        if (!bo)
//                            throw new Exception("I tell you to put between 0 to 4");
//                        BO.Task utask = new BO.Task()
//                        {
//                            Id = 4,
//                            Description = udescription,
//                            Alias = ualias,
//                            CreatedAtDate = DateTime.Now,
//                            Status = 0,
//                            //DependenceList = null,
//                            //Milestone = null,
//                            //BaselineStartDate = null,
//                            //StartDate = null,
//                            //ForecastDate = null,
//                            //DeadlineDate = null,
//                            //CompleteDate = null,
//                            Deliverables = udeliverables,
//                            Remarks = uremarks,
//                            //Engineer = null,
//                            ComplexityLevel = uenLevel
//                        };
//                        s_bl.Task.Update(utask);

//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                //case 'f'://delete a task
//                //    Console.WriteLine("enter id of task to delete");
//                //    int idDelete = int.Parse(Console.ReadLine()!);
//                //    try
//                //    {
//                //        s_bl.Task.Delete(idDelete);
//                //    }
//                //    catch (Exception ex)
//                //    {
//                //        Console.WriteLine(ex);
//                //    }
//                //    break;
//                default:
//                    break;
//            }
//        }


//        public static void InfoOfEngineers(char x)
//        {
//            switch (x)
//            {
//                case 'a': break;
//                case 'b'://add                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            t = new Task();
//                    Console.WriteLine("enter engineer's id to add");
//                    int id = int.Parse(Console.ReadLine()!);
//                    Console.WriteLine("enter engineer's name");
//                    string name = Console.ReadLine()!;
//                    Console.WriteLine("enter engineer's email");
//                    string email = Console.ReadLine()!;
//                    Console.WriteLine("enter engineer's level 0- to 4");
//                    BO.EngineerExperience engineerLevel;
//                    int? level = int.Parse(Console.ReadLine()!);
//                    bool b = Enum.TryParse<BO.EngineerExperience>(level.ToString(), out engineerLevel);
//                    if (!b)
//                        throw new Exception("error in parameter");
//                    Console.WriteLine("enter engineer's cost");
//                    double cost = double.Parse(Console.ReadLine()!);
//                    BO.Engineer myEngineer = new BO.Engineer() { Id = id, Name = name, Email = email, Level = engineerLevel, Cost = cost };
//                    try
//                    {
//                        int result = s_bl.Engineer.Create(myEngineer);
//                        Console.WriteLine("the engineer was added");
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'c'://read by id
//                    Console.WriteLine("enter engineer's id to read");
//                    int idRead = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        Console.WriteLine(s_bl.Engineer.Read(idRead)!.ToString());
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'd'://read all
//                    Console.WriteLine("all the engineers:");
//                    var arrReadAllEngineers = s_bl.Engineer.ReadAll();
//                    foreach (var item in arrReadAllEngineers)
//                        Console.WriteLine(item.ToString());
//                    break;
//                case 'e'://update
//                    Console.WriteLine("enter id of engineer to update");
//                    int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
//                    try
//                    {
//                        Console.WriteLine("enter engineer's name");
//                        string uname = Console.ReadLine()!;
//                        Console.WriteLine("enter engineer's email");
//                        string uemail = Console.ReadLine()!;
//                        Console.WriteLine("enter engineer's level from 0- to 4");
//                        int? ulevel = int.Parse(Console.ReadLine()!);
//                        BO.EngineerExperience uenLevel;
//                        bool bo = Enum.TryParse<BO.EngineerExperience>(ulevel.ToString(), out uenLevel);
//                        if (!bo)
//                            throw new Exception("I tell you to put between 0 to 4");
//                        // enLevel = (EngineerExperience)level;
//                        Console.WriteLine("enter engineer's cost");
//                        double ucost = double.Parse(Console.ReadLine()!);
//                        BO.Engineer upEngineer = new BO.Engineer() { Id = idUpdate, Name = uname, Email = uemail, Level = uenLevel, Cost = ucost };
//                        s_bl.Engineer.Update(upEngineer);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                case 'f'://delete a engineer
//                    Console.WriteLine("enter id of engineer to delete");
//                    int idDelete = int.Parse(Console.ReadLine()!);
//                    try
//                    {
//                        //s_bl.Engineer.Delete(idDelete);
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine(ex);
//                    }
//                    break;
//                default:
//                    break;
//            }
//        }
//        //public static void InfoOfDependencies(char x)
//        //{
//        //    switch (x)
//        //    {
//        //        case 'a': break;
//        //        case 'b'://add                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            t = new Task();
//        //            Console.WriteLine("enter  dependent task id");
//        //            int tId = int.Parse(Console.ReadLine()!);
//        //            Console.WriteLine("enter task befor id");
//        //            int tIdBefor = int.Parse(Console.ReadLine()!);
//        //            DO.Dependency d = new(4, tId, tIdBefor);
//        //            try
//        //            {

//        //                int result = s_dal!.Dependency.Create(d);
//        //                Console.WriteLine("the dependency was added");
//        //            }
//        //            catch (Exception ex)
//        //            {
//        //                Console.WriteLine(ex);
//        //            }
//        //            break;
//        //        case 'c'://read by id
//        //            Console.WriteLine("enter dependency id to read");
//        //            int id = int.Parse(Console.ReadLine()!);
//        //            try
//        //            {
//        //                Console.WriteLine(s_dal.Dependency.Read(id));
//        //            }
//        //            catch (Exception ex)
//        //            {
//        //                Console.WriteLine(ex);
//        //            }
//        //            break;
//        //        case 'd'://read all
//        //            Console.WriteLine("all the dependencies:");
//        //            var arrReadAllDepdndencies = s_dal.Dependency.ReadAll();
//        //            foreach (var item in arrReadAllDepdndencies)
//        //                Console.WriteLine(item);
//        //            break;
//        //        case 'e'://update
//        //            Console.WriteLine("enter id of dependency to update");
//        //            int idUpdate = int.Parse(Console.ReadLine()!);//search of the id to update
//        //            try
//        //            {
//        //                Console.WriteLine("enter  dependent task id");
//        //                int dId = int.Parse(Console.ReadLine()!);
//        //                Console.WriteLine("enter task befor id");
//        //                int dIdBefor = int.Parse(Console.ReadLine()!);
//        //                DO.Dependency depend = new(idUpdate, dId, dIdBefor);
//        //                //Console.WriteLine("enter created date");
//        //                //Console.WriteLine("enter product's category(0-for cups,1-for cakes,2-for cookies)");
//        //                //pUpdate._category = (ECategory)int.Parse(Console.ReadLine());
//        //                //Console.WriteLine("enter product's instock");
//        //                //pUpdate._inStock = int.Parse(Console.ReadLine());
//        //                //Console.WriteLine("enter product's parve(0/1)");
//        //                //pUpdate._parve = int.Parse(Console.ReadLine());
//        //                //dalProduct.update(pUpdate);
//        //                s_dal.Dependency.Update(depend);

//        //            }
//        //            catch (Exception ex)
//        //            {
//        //                Console.WriteLine(ex);
//        //            }
//        //            break;
//        //        case 'f'://delete a dependency
//        //            Console.WriteLine("enter id of dependency to delete");
//        //            int idDelete = int.Parse(Console.ReadLine()!);
//        //            try
//        //            {
//        //                s_dal.Dependency.Delete(idDelete);
//        //            }
//        //            catch (Exception ex)
//        //            {
//        //                Console.WriteLine(ex);
//        //            }
//        //            break;
//        //        default:
//        //            break;
//        //    }
//        //}
//        public static void Main(string[] args)
//        {
//            Console.Write("Would you like to create Initial data? (Y/N)");                                                              //string? ans = "Y";
//            string? ans = Console.ReadLine() ?? throw new FormatException("Wrong input"); //stage 3
//            if (ans == "Y") //stage 3

//                try
//                {
//                    //Initialization.Do(s_dal);

//                    DalTest.Initialization.Do(); //stage 4
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("error in parameters" + ex);
//                }
//            //Internal menu for every class and sending to funtion that treat this class
//            Console.WriteLine("for exit press 0");
//            Console.WriteLine("for tasks press 1");
//            Console.WriteLine("for engineers press 2");
//            Console.WriteLine("for Milestone press 3");

//            int select = int.Parse(Console.ReadLine()!);
//            char x;
//            while (select != 0)
//            {
//                switch (select)
//                {
//                    case 1:
//                        Console.WriteLine("for exit press a");
//                        Console.WriteLine("for add a task press b");
//                        Console.WriteLine("for read a task press c");
//                        Console.WriteLine("for read all tasks press d");
//                        Console.WriteLine("for update a task press e");
//                        Console.WriteLine("for delete a task press f");
//                        x = char.Parse(Console.ReadLine()!);
//                        InfoOfTask(x);//doing this function 
//                        break;
//                    case 2:
//                        Console.WriteLine("for exit press a");
//                        Console.WriteLine("for add an engineer press b");
//                        Console.WriteLine("for read an engineer press c");
//                        Console.WriteLine("for read all engineer press d");
//                        Console.WriteLine("for update an engineer press e");
//                        Console.WriteLine("for delete an engineer press f");
//                        x = char.Parse(Console.ReadLine()!);
//                        InfoOfEngineers(x);

//                        break;
//                    case 3:
//                        Console.WriteLine("for exit press a");
//                        Console.WriteLine("for add a dependency befor another press b");
//                        Console.WriteLine("for read dependency befor another press c");
//                        Console.WriteLine("for read all dependencies befor anothers press d");
//                        Console.WriteLine("for update an dependency befor another press e");
//                        Console.WriteLine("for delete an dependency befor another press f");
//                        x = char.Parse(Console.ReadLine()!);
//                        //InfoOfDependencies(x);


//                        break;
//                    default:
//                        break;
//                }

//                Console.WriteLine("for exit press 0");
//                Console.WriteLine("for tasks press 1");
//                Console.WriteLine("for engineers press 2");
//                Console.WriteLine("for Milestone press 3");
//                select = int.Parse(Console.ReadLine()!);
//            }
//        }
//    }
//}
//*/