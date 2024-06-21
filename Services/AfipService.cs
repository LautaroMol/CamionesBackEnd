using LoginAFIP;
using ServiceAfip;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace API_Camiones.Services
{
    public class AfipService
    {
        private string CertificadoPath { get; }
        private string CertificadoPassword { get; }

        public AfipService(string certificadoPath, string certificadoPassword)
        {
            CertificadoPath = certificadoPath;
            CertificadoPassword = certificadoPassword;
        }

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

        public string FirmarTRA(string traXml)
        {
            X509Certificate2 cert = new X509Certificate2(CertificadoPath, CertificadoPassword, X509KeyStorageFlags.MachineKeySet);

            RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PrivateKey;

            byte[] traBytes = Encoding.UTF8.GetBytes(traXml);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashBytes = sha256.ComputeHash(traBytes);

            byte[] firmaBytes = rsa.SignHash(hashBytes, CryptoConfig.MapNameToOID("SHA256"));

            string firmaBase64 = Convert.ToBase64String(firmaBytes);
            return firmaBase64;
        }

        public async Task<string> ObtenerTicketAcceso(string traFirmado)
        {
            X509Certificate2 cert = new X509Certificate2(CertificadoPath, CertificadoPassword);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new LoginCMSClient(); // Usar el nuevo nombre de la clase
            client.ClientCredentials.ClientCertificate.Certificate = cert;

            var response = await client.loginCmsAsync(traFirmado);
            return response.loginCmsReturn;
        }
        public (bool esValido, DateTime? fechaVencimiento, string detallesCadena) ValidarCertificado()
        {
            try
            {
                X509Certificate2 cert = new X509Certificate2(CertificadoPath, CertificadoPassword);

                // Verificar la fecha de vencimiento
                DateTime fechaVencimiento = cert.NotAfter;
                bool estaVencido = fechaVencimiento < DateTime.Now;

                // Validar la cadena de certificación
                X509Chain chain = new X509Chain();
                chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck; // Deshabilitar verificación de revocación
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

                bool cadenaValida = chain.Build(cert);

                string detallesCadena = "La cadena de certificación es válida.";
                if (!cadenaValida)
                {
                    detallesCadena = "La cadena de certificación no es válida:";
                    foreach (X509ChainStatus status in chain.ChainStatus)
                    {
                        detallesCadena += $"\n - {status.StatusInformation}";
                    }
                }

                // Retorna si el certificado es válido, la fecha de vencimiento y los detalles de la cadena
                return (!estaVencido && cadenaValida, fechaVencimiento, detallesCadena);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al validar el certificado: {ex.Message}");
                return (false, null, $"Error: {ex.Message}");
            }
        }
    }
}
