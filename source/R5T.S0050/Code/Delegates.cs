using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using R5T.F0093;
using R5T.T0153;
using R5T.T0155;


namespace R5T.S0050
{
    /// <inheritdoc cref="Documentation.CreateRepository"/>
    [DraftDelegateMarker]
    public delegate Task<TCreateRepositoryResult> CreateRepository<TCreateRepositoryResult>(
        LibraryContext libraryContext,
        string gitHubOwner,
        bool isPrivate,
        ILogger logger)
        where TCreateRepositoryResult : ICreateRepositoryResult;


    namespace N001
    {
        /// <inheritdoc cref="Documentation.CreateRepository"/>
        [DraftDelegateMarker]
        public delegate Task<TCreateRepositoryResult> CreateRepository<TCreateRepositoryResult>(
            string name,
            string description,
            string gitHubOwner,
            bool isPrivate,
            ILogger logger)
            where TCreateRepositoryResult : ICreateRepositoryResult;
    }
}
