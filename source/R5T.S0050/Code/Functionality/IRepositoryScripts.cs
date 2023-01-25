using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.F0093;
using R5T.T0132;
using R5T.T0153;


namespace R5T.S0050
{
	[FunctionalityMarker]
	public partial interface IRepositoryScripts : IFunctionalityMarker
	{
        /// <summary>
        /// Creates a new repository containing a solution with a Razor Class Library project.
        /// </summary>
        public async Task New_RazorClassLibrary()
        {
            // Inputs.
            var clearAnyExistingRepositoryForConstruction = true;
            var libraryContext =
                //Instances.LibraryContexts.Example
                new LibraryContext
                {
                    LibraryName = "R5T.R0004",
                    LibraryDescription = "Table of contents Razor Components."
                }
                ;
            var owner =
                Instances.GitHubOwners.SafetyCone
                ;
            var isPrivate = false;


            /// Run.
            await Operations.Instance.CreateRepository(
                clearAnyExistingRepositoryForConstruction,
                libraryContext,
                owner,
                isPrivate,
                Internal.Operations.Instance.CreateRepository_RazorClassLibrary);
        }

		public async Task New_WinFormsApplication()
		{
            /// Inputs.
            var clearAnyExistingRepositoryForConstruction = true;
            var libraryContext =
                Instances.LibraryContexts.Example
                ;
            var owner =
                Instances.GitHubOwners.SafetyCone
                ;
            var isPrivate = true;


            /// Run.
            await Operations.Instance.CreateRepository(
                clearAnyExistingRepositoryForConstruction,
                libraryContext,
                owner,
                isPrivate,
                Internal.Operations.Instance.CreateRepository_WinFormsApplication);
            //Operations.Instance.CreateRepository_WinFormsApplication);
        }

		/// <summary>
		/// Creates a new repository that contains only the gitignore file.
		/// </summary>
		public async Task New_OnlyGitIgnore()
		{
            /// Inputs.
            var deleteRepositoryForConstruction = true;
            var libraryContext =
                //Instances.LibraryContexts.Example
                new LibraryContext
                {
                    LibraryName = "R5T.S0060",
                    LibraryDescription = "Various example executables."
                }
                ;
            var owner =
                Instances.GitHubOwners.SafetyCone
                ;
            var isPrivate = false;


            /// Run.
            CreateNonSolutionedRepositoryResult repositoryResult = default;

            await Instances.LoggingOperator.InConsoleLoggerContext(
                nameof(New_Console),
                async logger =>
                {
                    logger.LogInformation("Generating repository context (if exists)...");

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

                    logger.LogInformation("Creating non-solutioned repository...");

                    repositoryResult = await Instances.RepositoryOperations.NewRepository_GitIgnoreOnly(
                        libraryContext,
                        owner,
                        isPrivate,
                        logger);
                });

            /// Show outputs.
            F0034.WindowsExplorerOperator.Instance.OpenDirectoryInExplorer(
                repositoryResult.LocalRepositoryResult.DirectoryPath);
        }

		public async Task New_Console()
		{
			/// Inputs.
			var deleteRepositoryForConstruction = true;
			var libraryContext =
				//Instances.LibraryContexts.Example
				new LibraryContext
				{
					LibraryName = "R5T.S0058",
					LibraryDescription = "Example executable, autogenerated."
                }
				;
			var owner =
				Instances.GitHubOwners.SafetyCone
				;
			var isPrivate = false;


			/// Run.
			ConsoleRepositoryResult consoleRepositoryResult = default;

			await Instances.LoggingOperator.InConsoleLoggerContext(
				nameof(New_Console),
				async logger =>
				{
					logger.LogInformation("Generating repository context (if exists)...");

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

					consoleRepositoryResult = await Instances.RepositoryOperations.NewRepository_Console(
						libraryContext,
						owner,
						isPrivate,
						logger);
				});

			/// Show outputs.
			Instances.VisualStudioOperator.OpenSolutionFile(
				consoleRepositoryResult.SolutionResult.SolutionContext.SolutionFilePath);
        }
	}
}