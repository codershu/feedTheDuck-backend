# FeedTheDuck

This project is the backend server for https://github.com/codershu/feedTheDuck-frontend-.git

## Precondition

I am running this sever on Mac and the detail is as below, but you can run it on other type of OS as it matches .Net SDK and runtimes.

![image](https://user-images.githubusercontent.com/44121753/147892682-9966b9d2-8668-45cc-8ee7-c78c48068d02.png)


.NET SDK (reflecting any global.json):
 Version:   5.0.400
 Commit:    d61950f9bf

Runtime Environment:
 OS Name:     Mac OS X
 OS Version:  11.0
 OS Platform: Darwin
 RID:         osx.11.0-x64
 Base Path:   /usr/local/share/dotnet/sdk/5.0.400/

Host (useful for support):
  Version: 5.0.9
  Commit:  208e377a53

.NET SDKs installed:
  3.1.412 
  5.0.400 

.NET runtimes installed:
  Microsoft.AspNetCore.App 3.1.18 
  Microsoft.AspNetCore.App 5.0.9 
  Microsoft.NETCore.App 3.1.18 
  Microsoft.NETCore.App 5.0.9 

## Development server

After clone this repo, navigate to the project folder and install node modules with `npm install`. Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Backend API URL

Navigate to 'app/services/duck-service.service.tes' and find line 12 and 13. When running for testing local server, use line 12 for localhost. When running for testing PROD server, use line 13.
