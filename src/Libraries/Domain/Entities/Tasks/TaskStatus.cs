namespace ContractorDocuments.Domain.Entities.Tasks
{
    public enum TaskStatus
    {
        NotStarted = 0,      // Process or task has not started yet
        InProgress = 1,      // Process or task is currently ongoing
        Completed = 2,       // Process or task is completed successfully
        OnHold = 3,          // Process or task is temporarily paused
        Cancelled = 4,       // Process or task is cancelled and will not proceed
    }
}