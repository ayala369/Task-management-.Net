    namespace Dal
{
    internal static class DataSource
    {//An internal static class called Config, where we will define the running numbers:
        internal static class Config
        {
            internal const int startTaskId = 1;//Initial value for a running number
            private static int nextTaskId = startTaskId;//The initial value is the previous fixed field
            internal static int NextTaskId { get => nextTaskId++; }//Automatic promotion of the private field

            internal const int startDependencyId = 1;//Initial value for a running number
            private static int nextDependencyId = startDependencyId;//The initial value is the previous fixed field
            internal static int NextDependencyId { get => nextDependencyId++; }//Automatic promotion of the private field
            internal static DateTime? ProjectStartDate = new DateTime(2020, 01, 01);
            internal static DateTime? ProjectCompletionDate = new DateTime(2024, 01, 01);

        }//Defining GET operations
        internal static List<DO.Dependency> Dependencys { get; } = new();
        internal static List<DO.Engineer> Engineers { get; } = new();
        internal static List<DO.Task> Tasks { get; } = new();

    }
}
