using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.F0093;
using R5T.T0132;


namespace R5T.S0050
{
	[FunctionalityMarker]
	public partial interface IRepositoryScripts : IFunctionalityMarker
	{
		public async Task Create_ConsoleRepository()
		{
			/// Inputs.
			var deleteRepositoryForConstruction = true;
			var libraryContext =
				Instances.LibraryContexts.Example
				;
			var owner =
				Instances.GitHubOwners.SafetyCone
				;
			var isPrivate = true;


			/// Run.
			ConsoleRepositoryResult consoleRepositoryResult = default;

			await Instances.LoggingOperator.InConsoleLoggerContext(
				nameof(Create_ConsoleRepository),
				async logger =>
				{
					logger.LogInformation("Generating repository context...");

					var repositoryContext = Instances.RepositoryContextOperations.GetRepositoryContext(
						owner,
						libraryContext,
						isPrivate);

					// For construction.
					if (deleteRepositoryForConstruction)
					{
						logger.LogWarning("CONSTRUCTION: Deleting repository...");

						await Instances.RepositoryOperations.DeleteRepository_Idempotent(repositoryContext);
					}

                    logger.LogInformation("Creating console repository...");

                    consoleRepositoryResult = await Instances.RepositoryOperations.CreateRepository_Console(
						libraryContext,
						repositoryContext,
						logger);
				});

			/// Show outputs.
			Instances.VisualStudioOperator.OpenSolutionFile(
				consoleRepositoryResult.ConsoleSolutionResult.SolutionContext.SolutionFilePath);
        }
	}
}