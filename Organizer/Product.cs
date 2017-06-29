using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Organizer
{
    public class Product
    {
        /// <summary>
        /// Название программы.
        /// </summary>
        public string Name;
        /// <summary>
        /// Идентификация продукта, такая как серийный номер программного обеспечения, или номер штампа на аппаратном чипе.
        /// </summary>
        public string IdentifyingNumber;
        /// <summary>
        /// Дата, когда этот продукт был установлен в системе.
        /// </summary>
        public DateTime InstallDate;
        /// <summary>
        /// Расположение установленного продукта.
        /// </summary>
        public string InstallLocation;
        /// <summary>
        /// Название поставщика продукта. 
        /// </summary>
        public string Vendor;
        /// <summary>
        /// Версия
        /// </summary>
        public string Version;

        public string Fields
        {
            get
            {
                return "Name;IdentifyingNumber;InstallDate;InstallLocation;Vendor;Version";
            }
        }

        public string GetSign()
        {
            return "Product";
        }

        public List<Product> GetData()
        {
            List<Product> list = new List<Product>();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT " + "Caption,IdentifyingNumber,InstallDate,InstallLocation,Vendor,Version,InstallDate2" + " FROM Win32_Product");

            foreach (ManagementObject item in searcher.Get())
            {
                list.Add(new Product()
                {
                    Name = (string)item["Caption"],
                    IdentifyingNumber = (string)item["IdentifyingNumber"],
                    InstallDate = ((DateTime)item["InstallDate"]),
                    InstallLocation = (string)item["InstallLocation"],
                    Vendor = (string)item["Vendor"],
                    Version = (string)item["Version"]
                });
            }
            return list;
        }

        public object this[string name]
        {
            get
            {
                switch (name)
                {
                    case "Name": return Name;
                    case "IdentifyingNumber": return IdentifyingNumber;
                    case "InstallDate": return InstallDate;
                    case "InstallLocation": return InstallLocation;
                    case "Vendor": return Vendor;
                    case "Version": return Version;
                    default:
                        return null;
                }
            }
            protected set
            {
                switch (name)
                {
                    case "Name": Name = (string)value; break;
                    case "IdentifyingNumber": IdentifyingNumber = (string)value; break;
                    case "InstallDate": InstallDate = (DateTime)value; break;
                    case "InstallLocation": InstallLocation = (string)value; break;
                    case "Vendor": Vendor = (string)value; break;
                    case "Version": Version = (string)value; break;
                    default:
                        break;
                }
            }
        }
    }
}