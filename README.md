# asp.net-core-and-angular-Participant-meeting

asp.net-Core-and-angular

Pre Requirements 

Visual Studio 2019 
Node.js 6.9+ with NPM 3.10+ 
yarn

Step to run project

1 First, we select eduvanz.Web.Host as startup project.

Open appsettings.json in .Web.Host project and change the Default connection string if you want:

Open Package Manager Console in Visual Studio, set *.EntityFrameworkCore as the Default Project and run the Update-Database command as shown below:

select eduvanz.EntityFrameworkCore in pacjage manager console

type command "update-database" and enter

run eduvanz.Web.Host project. We will see swagger screen

7.We will use Angular-CLI to start Angular UI. Here is the steps to start Angular UI:

Open cmd on eduvanz.Web.Host/angular location

Run npm start to run application(if npm is not installed then run npm install cmd)

go to browser and run localhost:\4200

you will see login screen

for admin login username is admin and password is : 123qwe
