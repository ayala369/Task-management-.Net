namespace BlApi
{ 
public interface IBl
{
        /// <summary>
        /// Interface for all
        /// </summary>
        public IEngineer Engineer { get; }
public ITask Task { get; }
public IMilestone Milestone { get; }
}
}