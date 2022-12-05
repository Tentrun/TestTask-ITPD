# TestTask-ITPD | Completed task for ITPDevelopment

Test Job

Create a time attendance application. After completion, you need to upload the project to any open GIT repository.

This application should be able to:

Show the user the current tasks in the context of projects and dates
Calculate the amount of time spent on a task
Be able to create tasks and projects
For implementation, you need to use:

С#. ASP.NET.Core Mvc. Entity Framework.
JavaScript/TypeScript. ReactJS/Angular or any other JS framework
SCSS/CSS. Bootstrap or any other Framework
The application must have a layered architecture:

DAL
Buisness
UI.
User Interface

The task table should display all the necessary information for the user and have the following columns
Number in order
Project name
The amount of time spent on a task in hours and minutes. Format 00:00
Task name (Link to edit page)
Start time
End time
On the page with the table of tasks, you need to display the total time spent on tasks from the table.
Above the table, you need to display the DatePicker to filter tasks by date, as well as display a drop-down list of projects, to filter by project.
To create a task, you must use the pop-up dialog with the form. After saving the data, the page should not be reloaded and the table data should be updated. Fields:
Task name (required parameter)
Project (required parameter, drop-down list)
Start time and end time. Start time cannot be greater than End time
Description of the task. It can be either a file or just a text field, provide for switching.
The task is edited on a separate page. The displayed fields are the same as when creating (item 2). On this page to provide the ability to display, add and delete sets of Descriptions of the current task.
On the page with the table of tasks, you need to display the total time spent on tasks from the table
Time counting

The column "The amount of time spent on the task" is dynamic and is calculated by the formula:

"Amount of time spent on the task" = "End time" - "Start time"

If the Start time is specified and the End Time is not specified, then the task is considered to be in progress and the end time is considered from the current time. DateTime.Now. Time counting must be implemented on the server.

Provide filling of all tables in the database with test data when updating migrations.
