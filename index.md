# IDEA Open Model - IOM
IOM interface can be used for the implementation of the link of any application with IDEA StatiCa products. For example IOM interface can be used for the implementation of the link of FEA software with IDEA StatiCa products like Connection or Beam.

![IOM.png](images/fea-idea.png)

The Structure model is an internal description of a designed structure which is used in Idea StatiCa. It contains information about geometry of members, cross-sections, materials etc. as well as loading.

The classes in the public assembly IdeaRS.OpenModel correspond to the internal classes of IDEA Structural Model (SM). IOM objects are small and do not contain any object references among themselves. Simple numerical identifications (id) are used for relations between objects. In fact, the IOM looks like Relation Database.

Results which were generated by a FEA application (internal forces) can be optionally saved as in the format of IdeaRS.OpenModel.Result.OpenModelResult. It contains internal forces on the Member1Ds. The relationships between the IOM and the IOM Results are defined by Id of objects.

### Coordinate system, forces
A geometry of a structure as well as its loading must be passed in basic SI units. There is the description of [the coordinate system and the convention of forces](coord-system.md) wich are used in IDEA StatiCa.

### IdeaRS.OpenModel
There is the documentation of [IdeaRS.OpenModel](iom-api/index.html)

IdeaRS.OpenModel is also published as [the nuget package](https://www.nuget.org/packages/IdeaStatiCa.OpenModel/).

### IdeaRS.ConnectionLink
This assembly is installed with other IDEA StatiCa products. You can find it in the installation directory. You can use it for controlling the application IdeaConnection from other applications. It enables to open a project in our application, update loading, apply template etc. [Here](samples/idea-connections/idea-connections.md) you can find examples how to use IdeaRS.ConnectionLink in your applications.

There is also the documentation of [IdeaRS.ConnectionLink](connectionlink-api/index.html)

### Samples
* It shows how to create [IOM of a Steel Frame structure](https://github.com/idea-statica/iom-examples)
* It shows how to create [Idea Connection project](samples/idea-connections/idea-connections.md) from your application.
* It shows how to create [Idea beam project](samples/idea-beam/idea-beam.md) in C# 