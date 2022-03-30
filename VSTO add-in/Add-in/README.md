# Create a VSTO project for PowerPoint Add-in

## Step One

Launch Visual Studio, select ```Create a new Project```, then select ```PowerPoint VSTO Add-in```, use ```.NET Framework 4.7.2```

## Step Two

In the tool bar, click ```Project``` -> ```Add Component``` -> ```Ribbon (Visual Designer)```, change name to ```Code.cs``` and click ```Add```.

## Step Three

Copy all the files (except ```README.md```) to project folder. Then in ```Solution Explorer```, right click the solution and select ```Add``` -> ```Existing Item...```, select ```Auxiliary.CodeEvaluation.cs```, ```Auxiliary.Naming.cs``` and ```Auxiliary.RGBColor.cs```.

## To package
To package the project into an executable file:
1. Open the project in Visual Studio
2. Right click the solution and select ```property```
3. Select ```publish```, setup the configurations according to your requirements
4. Click ```publish now```

## Note

1. Before closing Visual Studio, click ```Build``` -> ```Clean Solution```, otherwise the add-in will present in the PowerPoint.  

2. Test case ppt is in the test_case folder. Whenever a new features works, it is recommended to add a test slide.
3. The documentation is in folder ```html```, use ```index.html``` to view the full version. 
