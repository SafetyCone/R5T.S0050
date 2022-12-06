using System;


namespace R5T.S0050
{
    public static class Instances
    {
        public static F0047.IGitHubOwners GitHubOwners => F0047.GitHubOwners.Instance;
        public static T0153.Z001.ILibraryContexts LibraryContexts => T0153.Z001.LibraryContexts.Instance;
        public static F0035.ILoggingOperator LoggingOperator => F0035.LoggingOperator.Instance;
        public static F0089.IRepositoryContextOperations RepositoryContextOperations => F0089.RepositoryContextOperations.Instance;
        public static F0093.IRepositoryOperations RepositoryOperations => F0093.RepositoryOperations.Instance;
        public static F0088.IVisualStudioOperator VisualStudioOperator => F0088.VisualStudioOperator.Instance;
    }
}