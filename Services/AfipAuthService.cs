using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using LoginAFIP;

namespace API_Camiones.Services
{
    public class AfipAuthService
    {
        public string CrearTRA(string service)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode root = xmlDoc.AppendChild(xmlDoc.CreateElement("loginTicketRequest"));
            root.Attributes.Append(xmlDoc.CreateAttribute("version")).Value = "1.0";
            XmlNode header = root.AppendChild(xmlDoc.CreateElement("header"));
            header.AppendChild(xmlDoc.CreateElement("uniqueId")).InnerText = Convert.ToString(DateTime.UtcNow.Ticks);
            header.AppendChild(xmlDoc.CreateElement("generationTime")).InnerText = DateTime.UtcNow.AddMinutes(-10).ToString("s");
            header.AppendChild(xmlDoc.CreateElement("expirationTime")).InnerText = DateTime.UtcNow.AddMinutes(10).ToString("s");
            header.AppendChild(xmlDoc.CreateElement("service")).InnerText = service;
            return xmlDoc.OuterXml;
        }

        public string FirmarTRA(string tra, string certificadoPath, string certificadoPassword)
        {
            X509Certificate2 cert = new X509Certificate2(certificadoPath, certificadoPassword);
            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PrivateKey;

            byte[] traBytes = Encoding.UTF8.GetBytes(tra);
            byte[] firmaBytes = rsa.SignData(traBytes, new SHA256CryptoServiceProvider());

            return Convert.ToBase64String(firmaBytes);
        }

        public async Task<string> ObtenerTicketAcceso(string traFirmado, string certificadoPath)
        {
            X509Certificate2 cert = new X509Certificate2(certificadoPath);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new LoginCMSClient(); // Usar el nuevo nombre de la clase
            client.ClientCredentials.ClientCertificate.Certificate = cert;

            var response = await client.loginCmsAsync(traFirmado); // Pasa el string directamente
            return response.loginCmsReturn;
        }
    }
}

