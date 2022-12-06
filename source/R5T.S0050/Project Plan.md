# R5T.S0050
Complex repository-related scripts.

Scripts for not creating local and remote code repositories (of the Git and GitHub variety), but for creating repositories full of source directories, solutions, projects, code files, and other code-related files.


## See Also

* R5T.S0049 - Simple repository-related scripts.
* R5T.C0003 - Ithaca functionality (GUI for all code operations).
* R5T.S0043 - Old Nazareth scripts (code operations).


## Prior Work



## Design

This works by using:

* R5T.F0080.IRepositoryOperations.CreateRepository(
	RepositoryContext,
	Func{Task} setupRepository): Task{string}
* Supplied with a repository setup closure supplied by GetRepositorySetup(Func{Task} setupSolution) method.