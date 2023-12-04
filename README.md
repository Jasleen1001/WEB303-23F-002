dotnet new mvc -o Jasleen --no-https

dotnet tool install --global dotnet-aspnet-codegenerator --version 6

dotnet tool install --global dotnet-ef --version 6

dotnet add package Microsoft.EntityFrameworkCore.Design --version 6

dotnet add package Microsoft.EntityFrameworkCore.SQlite --version 6

dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 6

dotnet add package Microsoft.EntityFrameworkCore.sqlServer --version 6

dotnet aspnet-codegenerator controller -name SongsController -m Song -dc MvcSongContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite

dotnet ef migrations add InitialCreate

dotnet ef database update

12/04/2023 (10:00 am)

Firstly I run the project that I have made for my assignment to check what I have done with the help of a command that is dotnet watch run

(10:30 am)

Then I add two properties in my model that is rating and director.
Then update seed data that include new properties in that four records.
Then again I run my project

(11:00 am)

I add a search function to index page in which my properties are sort out in the order that is mentioned in the code.
And run the project.

(11:30 am)

Then I add a check box and Toggle function in Index View.

(12:30 pm)

I create a function which help to hide the items and also a function that helps to delete all that hidden items.

(1:00 pm)

When I try to run my project I face alot of errors and my hidden button and delete all buttons are not working properly.

(1:30 pm)

I used many methods and class examples which help me to solve these issues and I am able to run my project properly.