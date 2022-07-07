
using System ;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


Person person =new Person(){FirstName="Priyanshi" , Lastname="Agrawal"};
string path=".//link.xml";
XMLSerializer xMLSerializer=new XMLSerializer();
xMLSerializer.XmlSerializer(person,path);
 


class XMLSerializer{
public void XmlSerializer(object data, string path){
    XmlSerializer xmlSerializer= new XmlSerializer(typeof(Person));
    TextWriter writer = new StreamWriter(path);
    xmlSerializer.Serialize(writer,data);
    writer.Close();    
}

}

public class Person{
    public string FirstName{get; set;}
    public string Lastname{get; set;}
}