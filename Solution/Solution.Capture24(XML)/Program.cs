using System;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Solution.Capture24_XML_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            starter();


            Console.ReadKey();
        }
        public static void starter()
        {

            //ReadertoConsoleXML(@".\people.xml");
            //ReaderXMLtoList(@".\people.xml");
            //AddToFile(@".\people.xml");
            //DeleteXML(@".\people.xml");
            //XPathMethod(@".\people.xml");
            //xmlWriterLinq("people", new Person { Name = "ok", Age = 25, Company = "LDPD" });
            //xmlWriterLinq("people", new Person { Name = "bob", Age = 18, Company = "LDPD" });
            //xmlWriterLinq("people", new Person { Name = "ancle Bill", Age = 46, Company = "LDPD" });
            //xmlWriterLinq("people", new Person { Name = "John", Age = 13, Company = "LDPD" });
            //xmlWriterLinq("people", new Person { Name = "Bobby", Age = 12, Company = "LDPD" });
            //xmlReaderLinqtoConsole("people");
            //xmlRemoverCopyData("people");
            //ClearXML("people);
            //xmlChangeData("people");
            //SerializerXml("people.xml");
            //Feserialization("people.xml");
            SerializeDeserializeList("people.xml");


            Console.WriteLine("end");

        }

        public static void BaseInfo()
        {


            //XmlNode //представляет узел xml.В качестве узла может использоваться весь документ, так и отдельный элемент

            XmlDocument xd = new XmlDocument(); //представляет весь xml - документ

            //XmlElement//представляет отдельный элемент.Наследуется от класса XmlNode

            //XmlAttribute //представляет атрибут элемента

            // XmlText  //представляет значение элемента в виде текста, то есть тот текст, который находится в элементе между его открывающим и закрывающим тегами

            //XmlComment //представляет комментарий в xml

            //XmlNodeList //используется для работы со списком узлов

        }

        public static void ReadertoConsoleXML(string xmlDocument)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(xmlDocument);    // загружаем весь xml-документ
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot != null)
            {
                // обход всех узлов в корневом элементе
                foreach (XmlElement xnode in xRoot)
                {
                    // получаем атрибут name
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    Console.WriteLine(attr?.Value);

                    // обходим все дочерние узлы элемента user
                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        // если узел - company
                        if (childnode.Name == "company")
                        {
                            Console.WriteLine($"company: {childnode.InnerText}");
                        }
                        // если узел age
                        if (childnode.Name == "age")
                        {
                            Console.WriteLine($"age: {childnode.InnerText}");
                        }
                    }
                    Console.WriteLine();
                }
            }

        }

        public static void ReaderXMLtoList(string xmldocument)
        {
            List<Person> list = new List<Person>();
            list.Add(new Person() { Name = null, Age  =0, Company = null });
            list.Add(new Person() { Name = "bbb", Age = 33, Company = "vv" });

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmldocument);

            XmlElement xRoot = xmlDoc.DocumentElement;

            if (xRoot != null)
            {
                foreach (XmlElement elem in xRoot)
                {
                    Person person = new Person();
                    XmlNode attr = elem.Attributes.GetNamedItem("name");
                    person.Name = attr?.Value;

                    foreach (XmlElement childattr in elem)
                    {

                        if(childattr.Name == "company")
                        {
                            person.Company = childattr.InnerText;
                        }
                        if (childattr.Name == "age")
                        {
                            person.Age = int.Parse(childattr.InnerText);
                        }
                    }
                    list.Add(person);
                }
            }
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Name}  {item.Age}   {item.Company}");
            }

        }

        public static void AddToFile(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlElement xRoot = xmlDoc.DocumentElement;

            // создаем новый элемент person
            XmlElement xperson = xmlDoc.CreateElement("person");
            // создаем атрибут name
            XmlAttribute xattrperson = xmlDoc.CreateAttribute("name");
            // создаем элементы company и age
            XmlElement ageelem = xmlDoc.CreateElement("age");
            XmlElement comp = xmlDoc.CreateElement("company");

            Random random = new Random();
            int number = random.Next(1, 100);

            int[] Abc = new int[32];
            for(int i=0; i< Abc.Length; i++)
            {
                Abc[i] = random.Next(65, 90);
            }

            string nname = "";
            for (int i = random.Next(3, 5); i < 10 ; i++)
            {
                nname += (char)Abc[i];
            }

            string ccompany ="";
            for (int i = random.Next(24, 29); i < 32; i++)
            {
                ccompany += (char)Abc[i];
            }

            // создаем текстовые значения для элементов и атрибута
            XmlText textName = xmlDoc.CreateTextNode(nname);
            XmlText textCompany = xmlDoc.CreateTextNode(ccompany);
            XmlText textAge = xmlDoc.CreateTextNode(number.ToString());
            //добавляем узлы
            xattrperson.AppendChild(textName);
            // добавляем атрибут name
            comp.AppendChild(textCompany);
            ageelem.AppendChild(textAge);

            xperson.Attributes.Append(xattrperson);
            xperson.AppendChild(ageelem);
            xperson.AppendChild(comp);
            // добавляем в корневой элемент новый элемент person
            xRoot.AppendChild(xperson);
            // сохраняем изменения xml-документа в файл
            xmlDoc.Save(fileName);


        }

        public static void DeleteXML(string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);

            XmlElement xRoot = xDoc?.DocumentElement;

            XmlNode firstNode = xRoot?.FirstChild;

            if(firstNode != null) xRoot.RemoveChild(firstNode);

            xDoc.Save(filename);

        }

        public static void XPathMethod(string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);

            XmlElement xRoot = xDoc.DocumentElement;

            
            //XmlNodeList nlist = xRoot.SelectNodes("person"); //all persons
            XmlNodeList nlist = xRoot.SelectNodes("person[@name='Gnom']"); //onle persons with name nom
            

            if (nlist != null)
            {
                foreach (XmlNode item in nlist)
                {
                    //Console.WriteLine(item.OuterXml); // all parameters print
                    Console.WriteLine(item.SelectSingleNode("@name")?.Value); //print names
                }
            }

            Console.WriteLine("print companys");
            XmlNodeList nlist1 = xRoot.SelectNodes("//person/company");
            foreach (XmlNode item in nlist1)
            {
                Console.WriteLine(item.InnerText);
            }


        }
        public static void xmlWriterLinq(string FileName, Person person)
        {
            using (StreamReader sm = new StreamReader("text.txt"))
            {

                //XDocument xDoc = new XDocument(
                //    new XElement(FileName,
                //    new XElement("person",
                //    new XAttribute("Name", person.Name),
                //    new XElement("company", person.Company),
                //    new XElement("age", person.Age.ToString()))));

                // пока такой варик
                XDocument xDoc = XDocument.Load($"{FileName}.xml");
                XElement xroot = xDoc.Element("people");

                if(xroot != null)
                {
                    xroot.Add(new XElement("person",
                        new XAttribute("name", person.Name),
                        new XElement("age", person.Age),
                        new XElement("company", person.Company)));
                }

                xDoc.Save($"{FileName}.xml");
            }
            Console.WriteLine("Added and saved");

        }

        public static void xmlReaderLinqtoConsole(string FileName)
        {
            XDocument xDoc = XDocument.Load($"{FileName}.xml");

            var upTo30year = xDoc.Element(FileName)?
                .Elements("person")
                //.Where(p => int.Parse(p.Element("age").Value) <= int.Parse("25"))
                .Select(p => new Person
                {
                    Name = p.Attribute("name")?.Value,
                    Age = int.Parse(p.Element("age")?.Value),
                    Company = p.Element("company")?.Value
                });

            foreach (var item in upTo30year)
            {
                Console.WriteLine($"name: {item.Name}, Age: {item.Age}, company: {item.Company}");
            }
    
        }

        public static void xmlRemoverCopyData(string FileName)
        {
            List<Person> persons = new List<Person>();

            XDocument xDoc = XDocument.Load($"{FileName}.xml");

            var allPersonswithFile = xDoc.Element(FileName)?
                .Elements("person")?
                .Select(p => new Person
                {
                    Name = p.Attribute("name")?.Value,
                    Age = int.Parse(p.Element("age")?.Value),
                    Company = p.Element("company")?.Value
                });

            //save to list
            foreach (var item in allPersonswithFile)
            {
                persons.Add(new Person { Name = item?.Name, Age = item.Age, Company = item?.Company });
            }

            persons = persons.GroupBy(p => p.Name).Select(p => p.First()).ToList();

            xDoc.Save($"{FileName}.xml");




            XDocument xDocc = XDocument.Load($"{FileName}.xml");
            ClearXML(FileName);

            
            foreach (var item in persons)
            {
               
                XElement xRoot = xDocc.Element("people");
                
                if (xRoot != null)
                {
                    xRoot.Add(new XElement("person",
                    new XAttribute("name", item?.Name),
                    new XElement("age", item?.Age),
                    new XElement("company", item?.Company)));
                }
                xRoot.Save($"{FileName}.xml");
            }
            xDoc.Save($"{FileName}.xml");


        }

        public static void ClearXML(string fileName)
        {
            XDocument xDoc = XDocument.Load($"{fileName}.xml");

            XElement xRoot = xDoc.Element(fileName);

            if (xRoot != null)
            {
                // получим элемент person с name = "Bob"
                var bob = xRoot.Elements("person")
                    .Where(x => x.Attribute("name").Value.Length > 0);
                // и удалим его
                if (bob != null)
                {
                    bob.Remove();
                    xRoot.Save("people.xml");
                    xDoc.Save("people.xml");
                }
         
            }
            Console.WriteLine("File Cleared");
        }

        public static void SerializerXml(string filename)
        {
            Person p = new Person { Age = 25, Name = "nameee", Company = "companyyy" };

            XmlSerializer xmlserialz = new XmlSerializer(typeof(Person));

            using(FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlserialz.Serialize(fs, p);

                Console.WriteLine("File has benn Serialized");
            }
        }
        public static void Feserialization(string filename)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Person));

            using(FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {

                Person persik = xs.Deserialize(fs) as Person;

                

                Console.WriteLine($"Deserialize \nname = {persik.Name}, age = {persik.Age}, company = {persik.Company}");

            }

        }

        public static void SerializeDeserializeList(string filename)
        {
            List<Person> people = new List<Person>
                {
                    new Person{Name = "a", Age = 22, Company = "a" },
                    new Person{Name = "b", Age = 23, Company = "p" },
                    new Person{Name = "c", Age = 24, Company = "p" },
                    new Person{Name = "d", Age = 25, Company = "l" },
                    new Person{Name = "e", Age = 35, Company = "e" },
                    new Person{Name = "f", Age = 45, Company = "ple" },
                    new Person{Name = "g", Age = 55, Company = "ple" },
                    new Person{Name = "h", Age = 65, Company = "ple" }

                };

            XmlSerializer serik = new XmlSerializer(typeof(List<Person>));

            //serialize
            using(FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                serik.Serialize(fs, people);
                Console.WriteLine("List Srialized");

            }

            //deserialize
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                var newPeople = serik.Deserialize(fs) as List<Person>;


                if (newPeople != null)
                {
                    foreach (var item in newPeople)
                    {
                        Console.WriteLine($"Deserialize \nname = {item.Name}, age = {item.Age}, company = {item.Company}");
                    };
                }


            }




        }

    }

    public class Person :IComparable<Person>
    {
        public string Name { get; set; }
        public int Age;
        public string Company;

        public Person()
        {

        }

        int IComparable<Person>.CompareTo(Person person)
        {
            return Name.CompareTo(person.Name);
        }
    }
}
