Title: How to serialize an object to XML string?
Published: 05/08/2017
Author: Ankush Jain
IsActive: true
Tags:
  - Tag1
---
You can use below method to serialize an object to XML string.

Namespaces required:

`using System.Xml.Serialization;
using System.IO;
`

Method definition:

`public string GetXMLString<T>(T objectToSerialize)
{
      XmlSerializer xmlSerializer = new XmlSerializer(objectToSerialize.GetType());

      using (StringWriter stringWriter = new System.IO.StringWriter())
      {
            xmlSerializer.Serialize(stringWriter, objectToSerialize);
            return stringWriter.ToString();
      }
}
`

                