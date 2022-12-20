using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.Extensions.Logging;

using R5T.F0093;
using R5T.T0131;
using R5T.T0132;
using R5T.T0153;


namespace R5T.S0050
{
    [FunctionalityMarker, ValuesMarker]
    public partial interface IOperations : IFunctionalityMarker, IValuesMarker
    {
        private static Internal.IOperations Internal => S0050.Internal.Operations.Instance;


        public CreateRepository<CreateRepositoryResult> CreateRepository_WinFormsApplication => Internal.CreateRepository_WinFormsApplication;


        public async Task<TCreateRepositoryResult> CreateRepository<TCreateRepositoryResult>(
            bool clearAnyExistingRepositoryForConstruction,
            LibraryContext libraryContext,
            string gitHubOwner,
            bool isPrivate,
            CreateRepository<TCreateRepositoryResult> createRepositoryAction)
            where TCreateRepositoryResult : ICreateRepositoryResult
        {
            var repositoryContext = Instances.RepositoryContextOperations.GetRepositoryContext(
                gitHubOwner,
                libraryContext,
                isPrivate);

            TCreateRepositoryResult createRepositoryResult = default;

            await Instances.LoggingOperator.InConsoleLoggerContext(
               nameof(CreateRepository),
               async logger =>
               {
                   logger.LogInformation("Generating repository context...");

                   // For construction.
                   if (clearAnyExistingRepositoryForConstruction)
                   {
                       logger.LogWarning("CONSTRUCTION: Deleting repository (if exists)...");

                       await Instances.RepositoryOperations.DeleteRepository_Idempotent(repositoryContext);
                   }

                   logger.LogInformation("Creating repository...");

                   createRepositoryResult = await createRepositoryAction(
                       libraryContext,
                       gitHubOwner,
                       isPrivate,
                       logger);
               });

            /// Show outputs.
            Instances.VisualStudioOperator.OpenSolutionFile(
                createRepositoryResult.SolutionFilePath);

            return createRepositoryResult;
        }
    }
}


namespace R5T.S0050.Internal
{
    [FunctionalityMarker]
    public partial interface IOperations : IFunctionalityMarker
    {
        async Task<CreateRepositoryResult> CreateRepository_WinFormsApplication(
            LibraryContext libraryContext,
            string gitHubOwner,
            bool isPrivate,
            ILogger logger)
        {
            var repositoryContext = Instances.RepositoryContextOperations.GetRepositoryContext(
                gitHubOwner,
                libraryContext,
                isPrivate);

            var solutionRepositoryResult = await Instances.RepositoryOperations.CreateRepository(
                libraryContext,
                repositoryContext,
                async repositoryResult =>
                {
                    var solutionResult = await F0087.SolutionOperations.Instance.NewSolution_WindowsFormsApplication(
                        libraryContext,
                        repositoryContext.IsPrivate,
                        repositoryContext.LocalDirectoryPath);

                    var winFormsRepositoryResult = new CreateRepositoryResult
                    {
                        LocalRepositoryResult = repositoryResult,
                        SolutionResult = solutionResult,
                    };

                    return winFormsRepositoryResult;
                },
                logger);

            return solutionRepositoryResult;
        }
    }
}
