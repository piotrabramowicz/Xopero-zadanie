## Create an application that allows the user to manage issues

(https://docs.github.com/en/rest/issues/issues?apiVersion=2022-11-28) in the following Git
hosting services:

- GitHub
- Bitbucket
- GitLab

You should write code that handles 2 (chosen by you) of these hosting services and leaves
room for easy implementation of the third one in the future.

The application should offer the following functionalities:

- adding a new issue (with name and description defined by the user)
- modifying an issue's name and description
- closing an issue

The application should be divided into 2 parts:

- a library that handles application logic
  - requests to Git hosting services have to be sent directly using HttpClient
    (using libraries that handle the GitHub API etc. is not allowed)
  - use of other libraries (e.g. JSON-handling libraries) is allowed

- a REST API with endpoints providing execution of above functionalities
