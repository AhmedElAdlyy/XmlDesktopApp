using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab3_XML
{
    class xmlOperations
    {

        XmlDocument Doc;
        XmlNode Employees;
        string file = "../../Resources/Employees.xml";
        public int LastIndex { get; }

        public xmlOperations()
        {
            Doc = new XmlDocument();
            Doc.Load(file);
            Employees = Doc.ChildNodes[1];
            LastIndex = Employees.ChildNodes.Count - 1;
        }

        public XmlNode GetEmployee(int index)
        {
            XmlNode emp = Employees.ChildNodes[index];
            return emp;
        }

        public XmlNode SearchByName(string name)
        {
            string xPath = "//employee[name='" + name + "']";
            XmlNode node = Employees.SelectSingleNode(xPath);

            return node;
        }

        public bool UpdateEmployee(XmlNode old, string name, string phone, string addr, string email)
        {

            try
            {
                old.ChildNodes[0].InnerText = name;
                old.ChildNodes[1].InnerText = phone;
                old.ChildNodes[2].InnerText = addr;
                old.ChildNodes[3].InnerText = email;

                Doc.Save(file);

                return true;
            }
            catch
            {
                return false;
            }

        }

        public XmlNode CreateEmployee(string name, string phone, string addr, string email)
        {
            XmlElement newEmployeeEle = Doc.CreateElement("employee");
            Employees.AppendChild(newEmployeeEle);

            XmlElement newEmployeeName = Doc.CreateElement("name");
            newEmployeeName.InnerText = name;
            newEmployeeEle.AppendChild(newEmployeeName);

            XmlElement newEmployeePhone = Doc.CreateElement("phone");
            newEmployeePhone.InnerText = phone;
            newEmployeeEle.AppendChild(newEmployeePhone);

            XmlElement newEmployeeAddr = Doc.CreateElement("Address");
            newEmployeeAddr.InnerText = addr;
            newEmployeeEle.AppendChild(newEmployeeAddr);

            XmlElement newEmployeeEmail = Doc.CreateElement("email");
            newEmployeeEmail.InnerText = email;
            newEmployeeEle.AppendChild(newEmployeeEmail);

            Doc.Save(file);
            
            return newEmployeeEle;

        }



        public bool RemoveEmployee(XmlNode node)
        {
            try
            {
                node.ParentNode.RemoveChild(node);
                Doc.Save(file);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }



    }
}
