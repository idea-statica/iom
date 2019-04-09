using System;
using System.Collections.Generic;

namespace IdeaRS.SimpleStructModel
{
  public static class SimpleConnectionFactory
  {
    private static Dictionary<string, Func<object, object>> factoryDict;
    static SimpleConnectionFactory()
    {
      factoryDict = new Dictionary<string, Func<object, object>>();
    }
    public static object CreateSimpleCrossSection(object source)
    {
      string sourceType = source.GetType().FullName;
      var factoryMethod = factoryDict[sourceType];
      return factoryMethod(source);
    }

    public static object CreateSMElementIntance(SimpleElementBase simpleElement)
    {
      Type smClsType = simpleElement.GetStructClsType();
      var res = Activator.CreateInstance(smClsType);
      simpleElement.CopyToSM(res);
      return res;
    }


  }
}

