# README #

EOS is a productivity enhancement application, with the goal of creating a task and subject organizer that makes it easy to understand what tasks are more important or pertinant to its user.

Eos is curerntly under development, unfortunately until a server is set up to host the code you cannot build it easily. If you really want to get it working, you'll need to install glassfish and derby. Configure glassfish to look at a database for eos, and then build the dependencies to the EAR and deploy the EAR to the glassfish server. Then you can run the gui.

But I'll gladly explain the idea and design behind it! Eos has been implemented using Enteprise Java Beans as the backend. On the front end we're using a Java desktop application. The EJB code will be run on a glassfish server connected to a Java Derby SQL database. We're hoping to be able to host the glassfish server on AWS.

Any questions or comments, just leave us a message. Any feedback is greately appreciated.

Future plans: In order to reach as many users as possible EOS needs to run as many devices as possible. That was the primary reason for reason to start it in java. Java will reach Apple, Windows, and Linux but not any phones. So to reach windows phones we'll C#, to reach android we'll have to modify our java code, and to reach apple phones it'll obviously be objective C.

### What is this repository for? ###

* EOS
* Version 0.1.0
* [Learn Markdown](https://bitbucket.org/tutorials/markdowndemo)