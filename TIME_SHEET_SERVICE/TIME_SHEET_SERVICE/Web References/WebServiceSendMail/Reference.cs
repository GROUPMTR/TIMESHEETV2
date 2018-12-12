﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18444.
// 
#pragma warning disable 1591

namespace TIME_SHEET_SERVICE.WebServiceSendMail {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="SALES_INVOICESSoap", Namespace="http://tempuri.org/")]
    public partial class SALES_INVOICES : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SET_INVOICEOperationCompleted;
        
        private System.Threading.SendOrPostCallback GET_INVOICE_NUMBEROperationCompleted;
        
        private System.Threading.SendOrPostCallback GET_INVOICE_LISTOperationCompleted;
        
        private System.Threading.SendOrPostCallback GET_INVOICE_DETAILOperationCompleted;
        
        private System.Threading.SendOrPostCallback GET_INVOICE_MATCH_LISTOperationCompleted;
        
        private System.Threading.SendOrPostCallback SendMailOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveDocumentOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDocumentLenOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDocumentOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SALES_INVOICES() {
            this.Url = global::TIME_SHEET_SERVICE.Properties.Settings.Default.TIME_SHEET_SERVICE_WebServiceSendMail_SALES_INVOICES;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SET_INVOICECompletedEventHandler SET_INVOICECompleted;
        
        /// <remarks/>
        public event GET_INVOICE_NUMBERCompletedEventHandler GET_INVOICE_NUMBERCompleted;
        
        /// <remarks/>
        public event GET_INVOICE_LISTCompletedEventHandler GET_INVOICE_LISTCompleted;
        
        /// <remarks/>
        public event GET_INVOICE_DETAILCompletedEventHandler GET_INVOICE_DETAILCompleted;
        
        /// <remarks/>
        public event GET_INVOICE_MATCH_LISTCompletedEventHandler GET_INVOICE_MATCH_LISTCompleted;
        
        /// <remarks/>
        public event SendMailCompletedEventHandler SendMailCompleted;
        
        /// <remarks/>
        public event SaveDocumentCompletedEventHandler SaveDocumentCompleted;
        
        /// <remarks/>
        public event GetDocumentLenCompletedEventHandler GetDocumentLenCompleted;
        
        /// <remarks/>
        public event GetDocumentCompletedEventHandler GetDocumentCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SET_INVOICE", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SET_INVOICE(string xmlString) {
            object[] results = this.Invoke("SET_INVOICE", new object[] {
                        xmlString});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SET_INVOICEAsync(string xmlString) {
            this.SET_INVOICEAsync(xmlString, null);
        }
        
        /// <remarks/>
        public void SET_INVOICEAsync(string xmlString, object userState) {
            if ((this.SET_INVOICEOperationCompleted == null)) {
                this.SET_INVOICEOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSET_INVOICEOperationCompleted);
            }
            this.InvokeAsync("SET_INVOICE", new object[] {
                        xmlString}, this.SET_INVOICEOperationCompleted, userState);
        }
        
        private void OnSET_INVOICEOperationCompleted(object arg) {
            if ((this.SET_INVOICECompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SET_INVOICECompleted(this, new SET_INVOICECompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_INVOICE_NUMBER", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GET_INVOICE_NUMBER(string FIRMA_KODU, string TASLAK_FATURA_NO) {
            object[] results = this.Invoke("GET_INVOICE_NUMBER", new object[] {
                        FIRMA_KODU,
                        TASLAK_FATURA_NO});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GET_INVOICE_NUMBERAsync(string FIRMA_KODU, string TASLAK_FATURA_NO) {
            this.GET_INVOICE_NUMBERAsync(FIRMA_KODU, TASLAK_FATURA_NO, null);
        }
        
        /// <remarks/>
        public void GET_INVOICE_NUMBERAsync(string FIRMA_KODU, string TASLAK_FATURA_NO, object userState) {
            if ((this.GET_INVOICE_NUMBEROperationCompleted == null)) {
                this.GET_INVOICE_NUMBEROperationCompleted = new System.Threading.SendOrPostCallback(this.OnGET_INVOICE_NUMBEROperationCompleted);
            }
            this.InvokeAsync("GET_INVOICE_NUMBER", new object[] {
                        FIRMA_KODU,
                        TASLAK_FATURA_NO}, this.GET_INVOICE_NUMBEROperationCompleted, userState);
        }
        
        private void OnGET_INVOICE_NUMBEROperationCompleted(object arg) {
            if ((this.GET_INVOICE_NUMBERCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GET_INVOICE_NUMBERCompleted(this, new GET_INVOICE_NUMBERCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_INVOICE_LIST", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GET_INVOICE_LIST(string FIRMA_KODU, System.DateTime BAS_TARIHI, System.DateTime BIT_TARIHI) {
            object[] results = this.Invoke("GET_INVOICE_LIST", new object[] {
                        FIRMA_KODU,
                        BAS_TARIHI,
                        BIT_TARIHI});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GET_INVOICE_LISTAsync(string FIRMA_KODU, System.DateTime BAS_TARIHI, System.DateTime BIT_TARIHI) {
            this.GET_INVOICE_LISTAsync(FIRMA_KODU, BAS_TARIHI, BIT_TARIHI, null);
        }
        
        /// <remarks/>
        public void GET_INVOICE_LISTAsync(string FIRMA_KODU, System.DateTime BAS_TARIHI, System.DateTime BIT_TARIHI, object userState) {
            if ((this.GET_INVOICE_LISTOperationCompleted == null)) {
                this.GET_INVOICE_LISTOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGET_INVOICE_LISTOperationCompleted);
            }
            this.InvokeAsync("GET_INVOICE_LIST", new object[] {
                        FIRMA_KODU,
                        BAS_TARIHI,
                        BIT_TARIHI}, this.GET_INVOICE_LISTOperationCompleted, userState);
        }
        
        private void OnGET_INVOICE_LISTOperationCompleted(object arg) {
            if ((this.GET_INVOICE_LISTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GET_INVOICE_LISTCompleted(this, new GET_INVOICE_LISTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_INVOICE_DETAIL", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GET_INVOICE_DETAIL(string FIRMA_KODU, string UUID) {
            object[] results = this.Invoke("GET_INVOICE_DETAIL", new object[] {
                        FIRMA_KODU,
                        UUID});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GET_INVOICE_DETAILAsync(string FIRMA_KODU, string UUID) {
            this.GET_INVOICE_DETAILAsync(FIRMA_KODU, UUID, null);
        }
        
        /// <remarks/>
        public void GET_INVOICE_DETAILAsync(string FIRMA_KODU, string UUID, object userState) {
            if ((this.GET_INVOICE_DETAILOperationCompleted == null)) {
                this.GET_INVOICE_DETAILOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGET_INVOICE_DETAILOperationCompleted);
            }
            this.InvokeAsync("GET_INVOICE_DETAIL", new object[] {
                        FIRMA_KODU,
                        UUID}, this.GET_INVOICE_DETAILOperationCompleted, userState);
        }
        
        private void OnGET_INVOICE_DETAILOperationCompleted(object arg) {
            if ((this.GET_INVOICE_DETAILCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GET_INVOICE_DETAILCompleted(this, new GET_INVOICE_DETAILCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GET_INVOICE_MATCH_LIST", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable GET_INVOICE_MATCH_LIST(string FIRMA_KODU, System.DateTime BAS_TARIHI, System.DateTime BIT_TARIHI) {
            object[] results = this.Invoke("GET_INVOICE_MATCH_LIST", new object[] {
                        FIRMA_KODU,
                        BAS_TARIHI,
                        BIT_TARIHI});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void GET_INVOICE_MATCH_LISTAsync(string FIRMA_KODU, System.DateTime BAS_TARIHI, System.DateTime BIT_TARIHI) {
            this.GET_INVOICE_MATCH_LISTAsync(FIRMA_KODU, BAS_TARIHI, BIT_TARIHI, null);
        }
        
        /// <remarks/>
        public void GET_INVOICE_MATCH_LISTAsync(string FIRMA_KODU, System.DateTime BAS_TARIHI, System.DateTime BIT_TARIHI, object userState) {
            if ((this.GET_INVOICE_MATCH_LISTOperationCompleted == null)) {
                this.GET_INVOICE_MATCH_LISTOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGET_INVOICE_MATCH_LISTOperationCompleted);
            }
            this.InvokeAsync("GET_INVOICE_MATCH_LIST", new object[] {
                        FIRMA_KODU,
                        BAS_TARIHI,
                        BIT_TARIHI}, this.GET_INVOICE_MATCH_LISTOperationCompleted, userState);
        }
        
        private void OnGET_INVOICE_MATCH_LISTOperationCompleted(object arg) {
            if ((this.GET_INVOICE_MATCH_LISTCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GET_INVOICE_MATCH_LISTCompleted(this, new GET_INVOICE_MATCH_LISTCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendMail", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SendMail(string fromAddress, string toAddress, string subject, string body, string FileList) {
            object[] results = this.Invoke("SendMail", new object[] {
                        fromAddress,
                        toAddress,
                        subject,
                        body,
                        FileList});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SendMailAsync(string fromAddress, string toAddress, string subject, string body, string FileList) {
            this.SendMailAsync(fromAddress, toAddress, subject, body, FileList, null);
        }
        
        /// <remarks/>
        public void SendMailAsync(string fromAddress, string toAddress, string subject, string body, string FileList, object userState) {
            if ((this.SendMailOperationCompleted == null)) {
                this.SendMailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendMailOperationCompleted);
            }
            this.InvokeAsync("SendMail", new object[] {
                        fromAddress,
                        toAddress,
                        subject,
                        body,
                        FileList}, this.SendMailOperationCompleted, userState);
        }
        
        private void OnSendMailOperationCompleted(object arg) {
            if ((this.SendMailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendMailCompleted(this, new SendMailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveDocument", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool SaveDocument([System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] docbinaryarray, string docname) {
            object[] results = this.Invoke("SaveDocument", new object[] {
                        docbinaryarray,
                        docname});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void SaveDocumentAsync(byte[] docbinaryarray, string docname) {
            this.SaveDocumentAsync(docbinaryarray, docname, null);
        }
        
        /// <remarks/>
        public void SaveDocumentAsync(byte[] docbinaryarray, string docname, object userState) {
            if ((this.SaveDocumentOperationCompleted == null)) {
                this.SaveDocumentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveDocumentOperationCompleted);
            }
            this.InvokeAsync("SaveDocument", new object[] {
                        docbinaryarray,
                        docname}, this.SaveDocumentOperationCompleted, userState);
        }
        
        private void OnSaveDocumentOperationCompleted(object arg) {
            if ((this.SaveDocumentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveDocumentCompleted(this, new SaveDocumentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDocumentLen", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetDocumentLen(string DocumentName) {
            object[] results = this.Invoke("GetDocumentLen", new object[] {
                        DocumentName});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetDocumentLenAsync(string DocumentName) {
            this.GetDocumentLenAsync(DocumentName, null);
        }
        
        /// <remarks/>
        public void GetDocumentLenAsync(string DocumentName, object userState) {
            if ((this.GetDocumentLenOperationCompleted == null)) {
                this.GetDocumentLenOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDocumentLenOperationCompleted);
            }
            this.InvokeAsync("GetDocumentLen", new object[] {
                        DocumentName}, this.GetDocumentLenOperationCompleted, userState);
        }
        
        private void OnGetDocumentLenOperationCompleted(object arg) {
            if ((this.GetDocumentLenCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDocumentLenCompleted(this, new GetDocumentLenCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetDocument", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] GetDocument(string DocumentName) {
            object[] results = this.Invoke("GetDocument", new object[] {
                        DocumentName});
            return ((byte[])(results[0]));
        }
        
        /// <remarks/>
        public void GetDocumentAsync(string DocumentName) {
            this.GetDocumentAsync(DocumentName, null);
        }
        
        /// <remarks/>
        public void GetDocumentAsync(string DocumentName, object userState) {
            if ((this.GetDocumentOperationCompleted == null)) {
                this.GetDocumentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDocumentOperationCompleted);
            }
            this.InvokeAsync("GetDocument", new object[] {
                        DocumentName}, this.GetDocumentOperationCompleted, userState);
        }
        
        private void OnGetDocumentOperationCompleted(object arg) {
            if ((this.GetDocumentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDocumentCompleted(this, new GetDocumentCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SET_INVOICECompletedEventHandler(object sender, SET_INVOICECompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SET_INVOICECompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SET_INVOICECompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GET_INVOICE_NUMBERCompletedEventHandler(object sender, GET_INVOICE_NUMBERCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GET_INVOICE_NUMBERCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GET_INVOICE_NUMBERCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GET_INVOICE_LISTCompletedEventHandler(object sender, GET_INVOICE_LISTCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GET_INVOICE_LISTCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GET_INVOICE_LISTCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GET_INVOICE_DETAILCompletedEventHandler(object sender, GET_INVOICE_DETAILCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GET_INVOICE_DETAILCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GET_INVOICE_DETAILCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GET_INVOICE_MATCH_LISTCompletedEventHandler(object sender, GET_INVOICE_MATCH_LISTCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GET_INVOICE_MATCH_LISTCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GET_INVOICE_MATCH_LISTCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SendMailCompletedEventHandler(object sender, SendMailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendMailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SendMailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void SaveDocumentCompletedEventHandler(object sender, SaveDocumentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveDocumentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveDocumentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetDocumentLenCompletedEventHandler(object sender, GetDocumentLenCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDocumentLenCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDocumentLenCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetDocumentCompletedEventHandler(object sender, GetDocumentCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDocumentCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDocumentCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public byte[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((byte[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591