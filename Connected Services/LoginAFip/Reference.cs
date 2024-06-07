﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginAFip
{
    using System.Net.Sockets;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Security.Cryptography.Pkcs;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginFault", Namespace="https://wsaahomo.afip.gov.ar/ws/services/LoginCms")]
    internal partial class LoginFault : object, System.ComponentModel.INotifyPropertyChanged
    {
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://wsaahomo.afip.gov.ar/ws/services/LoginCms", ConfigurationName="LoginAFip.LoginCMS")]
    internal interface LoginCMS
    {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el espacio de nombres de contenedor (http://wsaa.view.sua.dvadac.desein.afip.gov) del mensaje loginCmsRequest no coincide con el valor predeterminado (https://wsaahomo.afip.gov.ar/ws/services/LoginCms)
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        [System.ServiceModel.FaultContractAttribute(typeof(LoginAFip.LoginFault), Action="", Name="fault")]
        LoginAFip.loginCmsResponse loginCms(LoginAFip.loginCmsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
        System.Threading.Tasks.Task<LoginAFip.loginCmsResponse> loginCmsAsync(LoginAFip.loginCmsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="loginCms", WrapperNamespace="http://wsaa.view.sua.dvadac.desein.afip.gov", IsWrapped=true)]
    internal partial class loginCmsRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wsaa.view.sua.dvadac.desein.afip.gov", Order=0)]
        public string in0;
        
        public loginCmsRequest()
        {
        }
        
        public loginCmsRequest(string in0)
        {
            this.in0 = in0;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="loginCmsResponse", WrapperNamespace="http://wsaa.view.sua.dvadac.desein.afip.gov", IsWrapped=true)]
    internal partial class loginCmsResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://wsaa.view.sua.dvadac.desein.afip.gov", Order=0)]
        public string loginCmsReturn;
        
        public loginCmsResponse()
        {
        }
        
        public loginCmsResponse(string loginCmsReturn)
        {
            this.loginCmsReturn = loginCmsReturn;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    internal interface LoginCMSChannel : LoginAFip.LoginCMS, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    internal partial class LoginCMSClient : System.ServiceModel.ClientBase<LoginAFip.LoginCMS>, LoginAFip.LoginCMS
    {
        
        /// <summary>
        /// Implemente este método parcial para configurar el punto de conexión de servicio.
        /// </summary>
        /// <param name="serviceEndpoint">El punto de conexión para configurar</param>
        /// <param name="clientCredentials">Credenciales de cliente</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public LoginCMSClient() : 
                base(LoginCMSClient.GetDefaultBinding(), LoginCMSClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.LoginCms.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginCMSClient(EndpointConfiguration endpointConfiguration) : 
                base(LoginCMSClient.GetBindingForEndpoint(endpointConfiguration), LoginCMSClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginCMSClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(LoginCMSClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginCMSClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(LoginCMSClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public LoginCMSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LoginAFip.loginCmsResponse LoginAFip.LoginCMS.loginCms(LoginAFip.loginCmsRequest request)
        {
            return base.Channel.loginCms(request);
        }
        
        public string loginCms(string in0)
        {
            LoginAFip.loginCmsRequest inValue = new LoginAFip.loginCmsRequest();
            inValue.in0 = in0;
            LoginAFip.loginCmsResponse retVal = ((LoginAFip.LoginCMS)(this)).loginCms(inValue);
            return retVal.loginCmsReturn;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<LoginAFip.loginCmsResponse> LoginAFip.LoginCMS.loginCmsAsync(LoginAFip.loginCmsRequest request)
        {
            return base.Channel.loginCmsAsync(request);
        }
        
        public System.Threading.Tasks.Task<LoginAFip.loginCmsResponse> loginCmsAsync(string in0)
        {
            LoginAFip.loginCmsRequest inValue = new LoginAFip.loginCmsRequest();
            inValue.in0 = in0;
            return ((LoginAFip.LoginCMS)(this)).loginCmsAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.LoginCms))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.LoginCms))
            {
                return new System.ServiceModel.EndpointAddress("https://wsaahomo.afip.gov.ar/ws/services/LoginCms");
            }
            throw new System.InvalidOperationException(string.Format("No se pudo encontrar un punto de conexión con el nombre \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return LoginCMSClient.GetBindingForEndpoint(EndpointConfiguration.LoginCms);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return LoginCMSClient.GetEndpointAddress(EndpointConfiguration.LoginCms);
        }
        
        public enum EndpointConfiguration
        {
            
            LoginCms,
        }
        public static DateTime GetNetworkTime()
        {
            const string ntpServer = "time.afip.gov.ar";
            var ntpData = new byte[48];
            ntpData[0] = 0x1B; //LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)

            var addresses = Dns.GetHostEntry(ntpServer).AddressList;
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            socket.Connect(ipEndPoint);
            socket.Send(ntpData);
            socket.Receive(ntpData);
            socket.Close();

            ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
            ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);


            return networkDateTime;
        }

        private string Ticket()
        {
            var fechaAfip = GetNetworkTime();
            var generateTimeAfip = fechaAfip.AddMinutes(-2); //resto algunos minutos para que no me error en el pedido de acuerdo a instrucciones del manual
            var fechaPedido = DateTimeOffset.Parse(generateTimeAfip.AddHours(-3).ToString()).ToString("yyyy-MM-dd'T'HH:mm:sszzz");

            var expirationTimeAfip = fechaAfip.AddMinutes(+2); //lo mismo que en el generateTimeAfip 
            var fechaExpira = DateTimeOffset.Parse(expirationTimeAfip.AddHours(-3).ToString()).ToString("yyyy-MM-dd'T'HH:mm:sszzz");

            XmlDocument xml = new XmlDocument();

            var archivo = "certificado.pfx";

            var certificate = new X509Certificate2(archivo, "certificado", X509KeyStorageFlags.Exportable);

            var encodingUTF = Encoding.UTF8;

            xml.LoadXml("<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>");

            var unique = xml.SelectSingleNode("//uniqueId");
            var generateTime = xml.SelectSingleNode("//generationTime");
            var expirationTime = xml.SelectSingleNode("//expirationTime");
            var service = xml.SelectSingleNode("//service");

            unique.InnerText = "1";
            generateTime.InnerText = fechaPedido;
            expirationTime.InnerText = fechaExpira;
            service.InnerText = "ws_sr_constancia_inscripcion";
            var outXml = xml.InnerXml;

            byte[] msgBytes = encodingUTF.GetBytes(outXml);

            ContentInfo contentInfo = new ContentInfo(msgBytes);
            SignedCms signedCms = new SignedCms(contentInfo);
            CmsSigner cmsSigner = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);
            cmsSigner.IncludeOption = X509IncludeOption.EndCertOnly;
            signedCms.ComputeSignature(cmsSigner);

            byte[] cmsCodificado = signedCms.Encode();

            var codBase64 = Convert.ToBase64String(cmsCodificado);


            return codBase64;
        }
        private async Task<string> Gen()
        {
            string ticket = Ticket();
            LoginAFip.LoginCMSClient loginCMS = new LoginAFip.LoginCMSClient();
            var login = await loginCMS.loginCmsAsync(ticket);

            var xdoc = XDocument.Parse(login.loginCmsReturn);
            var token = xdoc.Descendants().First(node => node.Name == "token").Value;
            var sign = xdoc.Descendants().First(node => node.Name == "sign").Value;
            var expTime = xdoc.Descendants().First(node => node.Name == "expirationTime").Value;

            return ticket;
        }
    }
}
