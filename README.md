####ABNUNISOL PORTAL STANDARD
ABNUNISOL PORTAL STANDARD is a standardized web portal with intergranted features that enables students and staffs access an array of content depending on their privileges. 
Some of the services that can be accessed through the portal include Hostel Booking, Evaluations, View Events, Access to News among others. 

###Requirements
-HTTP server, 
-ms server

###Deployment procedure
##Enabling IIS server
Assuming you are running your server on Microsoft® IIS, on the start window, search for IIS to check whether it has been enable. If enabled, internet information services (IIS) manager 
window will loaded on the screen and if not enabled, the window will not load. To install IIS on your server, search for control panel, click on the programs to load 
programs window, on the programs window click on programs and features to load program and feature window. On the left of program and feature window, click on turn windows 
features on or off to load window features. Scroll to internet information services expand it and enable its childrens 
(FTP server, web management tools and world wide web services). The internet information services subfolders contains subfolders which may need to be enabled as well.

##Publishing the application
On the solution explorer window in visual studio, right click on the project, and click publish. Click on new profile link to load a publish target window. Select folder option 
and browse to the location where you want to store your published folders and files.

##Deployment
Browse to C:\inetpub\wwwroot and paste your published content there.

###Usage
After deployment, you can now access your application by browsing to the url of the application.