## Sample
The sample describes how to create the IOM and the IOM Results programmatically in the c# language code.
In the followed picture, there is an original beam in the application.

<img src="images/beam-sample.png" alt="beam-sample" width="80%"/><br/>

## Sample code
The project sample **BeamSampleIOM** is the console application. It creates xml files with the IOM and the IOM Result data. The name of xml file of the IOM must be set as a parameter of this application. The name of xml file of the IOM Results is the same as the xml file with IOM but extension contains letter “r” at the end.
The project contains the c# class **BeamSampleIOM** (BeamSampleIOM.cs), which provides the IOM and IOM Results for this sample.

Method **GenerateIOM()** compiles of the IOM. 
This method contains these methods:
### CreateSettings()
-	Compiles base data of project
### CreateGeometry()
-	Compiles the 3D geometry
-	Points
-	Lines
-	Polylines
### CreateMaterials()
-	Compiles the materials

<img src="images/beam-mat.png" alt="beam-mat" width="50%"/><br/>

### CreateCrossSections()
-	Compiles the cross-sections

<img src="images/beam-css.png" alt="beam-css" width="50%"/><br/>
<img src="images/beam-css2.png" alt="beam-css2" width="50%"/><br/>

### CreateModel()
-	Compiles the structural model
-	Elements
-	Members
-	Beams
-	Supports

<img src="images/beam-model.png" alt="model" width="50%"/><br/>

### CreateLoad()
-	Compiles the loading data
-	Load groups

<img src="images/beam-load1.png" alt="model" width="30%"/><br/>
<img src="images/beam-load2.png" alt="model" width="50%"/><br/>

-	Load cases

<img src="images/beam-load3.png" alt="model" width="50%"/><br/>

-	Combinations

Method **GenerateIOMResult()** compiles of the IOMResults. 
