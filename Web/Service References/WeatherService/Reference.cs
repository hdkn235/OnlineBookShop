﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1008
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookShop.Web.WeatherService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://WebXml.com.cn/", ConfigurationName="WeatherService.WeatherWebServiceSoap")]
    public interface WeatherWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportCity", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getSupportCity(string byProvinceName);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://WebXml.com.cn/getSupportCity", ReplyAction="*")]
        System.IAsyncResult BegingetSupportCity(string byProvinceName, System.AsyncCallback callback, object asyncState);
        
        string[] EndgetSupportCity(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportProvince", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getSupportProvince();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://WebXml.com.cn/getSupportProvince", ReplyAction="*")]
        System.IAsyncResult BegingetSupportProvince(System.AsyncCallback callback, object asyncState);
        
        string[] EndgetSupportProvince(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getSupportDataSet", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet getSupportDataSet();
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://WebXml.com.cn/getSupportDataSet", ReplyAction="*")]
        System.IAsyncResult BegingetSupportDataSet(System.AsyncCallback callback, object asyncState);
        
        System.Data.DataSet EndgetSupportDataSet(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getWeatherbyCityName(string theCityName);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://WebXml.com.cn/getWeatherbyCityName", ReplyAction="*")]
        System.IAsyncResult BegingetWeatherbyCityName(string theCityName, System.AsyncCallback callback, object asyncState);
        
        string[] EndgetWeatherbyCityName(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://WebXml.com.cn/getWeatherbyCityNamePro", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] getWeatherbyCityNamePro(string theCityName, string theUserID);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://WebXml.com.cn/getWeatherbyCityNamePro", ReplyAction="*")]
        System.IAsyncResult BegingetWeatherbyCityNamePro(string theCityName, string theUserID, System.AsyncCallback callback, object asyncState);
        
        string[] EndgetWeatherbyCityNamePro(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WeatherWebServiceSoapChannel : BookShop.Web.WeatherService.WeatherWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getSupportCityCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getSupportCityCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getSupportProvinceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getSupportProvinceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getSupportDataSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getSupportDataSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Data.DataSet Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getWeatherbyCityNameCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getWeatherbyCityNameCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class getWeatherbyCityNameProCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public getWeatherbyCityNameProCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public string[] Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WeatherWebServiceSoapClient : System.ServiceModel.ClientBase<BookShop.Web.WeatherService.WeatherWebServiceSoap>, BookShop.Web.WeatherService.WeatherWebServiceSoap {
        
        private BeginOperationDelegate onBegingetSupportCityDelegate;
        
        private EndOperationDelegate onEndgetSupportCityDelegate;
        
        private System.Threading.SendOrPostCallback ongetSupportCityCompletedDelegate;
        
        private BeginOperationDelegate onBegingetSupportProvinceDelegate;
        
        private EndOperationDelegate onEndgetSupportProvinceDelegate;
        
        private System.Threading.SendOrPostCallback ongetSupportProvinceCompletedDelegate;
        
        private BeginOperationDelegate onBegingetSupportDataSetDelegate;
        
        private EndOperationDelegate onEndgetSupportDataSetDelegate;
        
        private System.Threading.SendOrPostCallback ongetSupportDataSetCompletedDelegate;
        
        private BeginOperationDelegate onBegingetWeatherbyCityNameDelegate;
        
        private EndOperationDelegate onEndgetWeatherbyCityNameDelegate;
        
        private System.Threading.SendOrPostCallback ongetWeatherbyCityNameCompletedDelegate;
        
        private BeginOperationDelegate onBegingetWeatherbyCityNameProDelegate;
        
        private EndOperationDelegate onEndgetWeatherbyCityNameProDelegate;
        
        private System.Threading.SendOrPostCallback ongetWeatherbyCityNameProCompletedDelegate;
        
        public WeatherWebServiceSoapClient() {
        }
        
        public WeatherWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WeatherWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WeatherWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<getSupportCityCompletedEventArgs> getSupportCityCompleted;
        
        public event System.EventHandler<getSupportProvinceCompletedEventArgs> getSupportProvinceCompleted;
        
        public event System.EventHandler<getSupportDataSetCompletedEventArgs> getSupportDataSetCompleted;
        
        public event System.EventHandler<getWeatherbyCityNameCompletedEventArgs> getWeatherbyCityNameCompleted;
        
        public event System.EventHandler<getWeatherbyCityNameProCompletedEventArgs> getWeatherbyCityNameProCompleted;
        
        public string[] getSupportCity(string byProvinceName) {
            return base.Channel.getSupportCity(byProvinceName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BegingetSupportCity(string byProvinceName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetSupportCity(byProvinceName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string[] EndgetSupportCity(System.IAsyncResult result) {
            return base.Channel.EndgetSupportCity(result);
        }
        
        private System.IAsyncResult OnBegingetSupportCity(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string byProvinceName = ((string)(inValues[0]));
            return this.BegingetSupportCity(byProvinceName, callback, asyncState);
        }
        
        private object[] OnEndgetSupportCity(System.IAsyncResult result) {
            string[] retVal = this.EndgetSupportCity(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetSupportCityCompleted(object state) {
            if ((this.getSupportCityCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getSupportCityCompleted(this, new getSupportCityCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getSupportCityAsync(string byProvinceName) {
            this.getSupportCityAsync(byProvinceName, null);
        }
        
        public void getSupportCityAsync(string byProvinceName, object userState) {
            if ((this.onBegingetSupportCityDelegate == null)) {
                this.onBegingetSupportCityDelegate = new BeginOperationDelegate(this.OnBegingetSupportCity);
            }
            if ((this.onEndgetSupportCityDelegate == null)) {
                this.onEndgetSupportCityDelegate = new EndOperationDelegate(this.OnEndgetSupportCity);
            }
            if ((this.ongetSupportCityCompletedDelegate == null)) {
                this.ongetSupportCityCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetSupportCityCompleted);
            }
            base.InvokeAsync(this.onBegingetSupportCityDelegate, new object[] {
                        byProvinceName}, this.onEndgetSupportCityDelegate, this.ongetSupportCityCompletedDelegate, userState);
        }
        
        public string[] getSupportProvince() {
            return base.Channel.getSupportProvince();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BegingetSupportProvince(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetSupportProvince(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string[] EndgetSupportProvince(System.IAsyncResult result) {
            return base.Channel.EndgetSupportProvince(result);
        }
        
        private System.IAsyncResult OnBegingetSupportProvince(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BegingetSupportProvince(callback, asyncState);
        }
        
        private object[] OnEndgetSupportProvince(System.IAsyncResult result) {
            string[] retVal = this.EndgetSupportProvince(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetSupportProvinceCompleted(object state) {
            if ((this.getSupportProvinceCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getSupportProvinceCompleted(this, new getSupportProvinceCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getSupportProvinceAsync() {
            this.getSupportProvinceAsync(null);
        }
        
        public void getSupportProvinceAsync(object userState) {
            if ((this.onBegingetSupportProvinceDelegate == null)) {
                this.onBegingetSupportProvinceDelegate = new BeginOperationDelegate(this.OnBegingetSupportProvince);
            }
            if ((this.onEndgetSupportProvinceDelegate == null)) {
                this.onEndgetSupportProvinceDelegate = new EndOperationDelegate(this.OnEndgetSupportProvince);
            }
            if ((this.ongetSupportProvinceCompletedDelegate == null)) {
                this.ongetSupportProvinceCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetSupportProvinceCompleted);
            }
            base.InvokeAsync(this.onBegingetSupportProvinceDelegate, null, this.onEndgetSupportProvinceDelegate, this.ongetSupportProvinceCompletedDelegate, userState);
        }
        
        public System.Data.DataSet getSupportDataSet() {
            return base.Channel.getSupportDataSet();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BegingetSupportDataSet(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetSupportDataSet(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.Data.DataSet EndgetSupportDataSet(System.IAsyncResult result) {
            return base.Channel.EndgetSupportDataSet(result);
        }
        
        private System.IAsyncResult OnBegingetSupportDataSet(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return this.BegingetSupportDataSet(callback, asyncState);
        }
        
        private object[] OnEndgetSupportDataSet(System.IAsyncResult result) {
            System.Data.DataSet retVal = this.EndgetSupportDataSet(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetSupportDataSetCompleted(object state) {
            if ((this.getSupportDataSetCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getSupportDataSetCompleted(this, new getSupportDataSetCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getSupportDataSetAsync() {
            this.getSupportDataSetAsync(null);
        }
        
        public void getSupportDataSetAsync(object userState) {
            if ((this.onBegingetSupportDataSetDelegate == null)) {
                this.onBegingetSupportDataSetDelegate = new BeginOperationDelegate(this.OnBegingetSupportDataSet);
            }
            if ((this.onEndgetSupportDataSetDelegate == null)) {
                this.onEndgetSupportDataSetDelegate = new EndOperationDelegate(this.OnEndgetSupportDataSet);
            }
            if ((this.ongetSupportDataSetCompletedDelegate == null)) {
                this.ongetSupportDataSetCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetSupportDataSetCompleted);
            }
            base.InvokeAsync(this.onBegingetSupportDataSetDelegate, null, this.onEndgetSupportDataSetDelegate, this.ongetSupportDataSetCompletedDelegate, userState);
        }
        
        public string[] getWeatherbyCityName(string theCityName) {
            return base.Channel.getWeatherbyCityName(theCityName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BegingetWeatherbyCityName(string theCityName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetWeatherbyCityName(theCityName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string[] EndgetWeatherbyCityName(System.IAsyncResult result) {
            return base.Channel.EndgetWeatherbyCityName(result);
        }
        
        private System.IAsyncResult OnBegingetWeatherbyCityName(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string theCityName = ((string)(inValues[0]));
            return this.BegingetWeatherbyCityName(theCityName, callback, asyncState);
        }
        
        private object[] OnEndgetWeatherbyCityName(System.IAsyncResult result) {
            string[] retVal = this.EndgetWeatherbyCityName(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetWeatherbyCityNameCompleted(object state) {
            if ((this.getWeatherbyCityNameCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getWeatherbyCityNameCompleted(this, new getWeatherbyCityNameCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getWeatherbyCityNameAsync(string theCityName) {
            this.getWeatherbyCityNameAsync(theCityName, null);
        }
        
        public void getWeatherbyCityNameAsync(string theCityName, object userState) {
            if ((this.onBegingetWeatherbyCityNameDelegate == null)) {
                this.onBegingetWeatherbyCityNameDelegate = new BeginOperationDelegate(this.OnBegingetWeatherbyCityName);
            }
            if ((this.onEndgetWeatherbyCityNameDelegate == null)) {
                this.onEndgetWeatherbyCityNameDelegate = new EndOperationDelegate(this.OnEndgetWeatherbyCityName);
            }
            if ((this.ongetWeatherbyCityNameCompletedDelegate == null)) {
                this.ongetWeatherbyCityNameCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetWeatherbyCityNameCompleted);
            }
            base.InvokeAsync(this.onBegingetWeatherbyCityNameDelegate, new object[] {
                        theCityName}, this.onEndgetWeatherbyCityNameDelegate, this.ongetWeatherbyCityNameCompletedDelegate, userState);
        }
        
        public string[] getWeatherbyCityNamePro(string theCityName, string theUserID) {
            return base.Channel.getWeatherbyCityNamePro(theCityName, theUserID);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public System.IAsyncResult BegingetWeatherbyCityNamePro(string theCityName, string theUserID, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BegingetWeatherbyCityNamePro(theCityName, theUserID, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public string[] EndgetWeatherbyCityNamePro(System.IAsyncResult result) {
            return base.Channel.EndgetWeatherbyCityNamePro(result);
        }
        
        private System.IAsyncResult OnBegingetWeatherbyCityNamePro(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string theCityName = ((string)(inValues[0]));
            string theUserID = ((string)(inValues[1]));
            return this.BegingetWeatherbyCityNamePro(theCityName, theUserID, callback, asyncState);
        }
        
        private object[] OnEndgetWeatherbyCityNamePro(System.IAsyncResult result) {
            string[] retVal = this.EndgetWeatherbyCityNamePro(result);
            return new object[] {
                    retVal};
        }
        
        private void OngetWeatherbyCityNameProCompleted(object state) {
            if ((this.getWeatherbyCityNameProCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.getWeatherbyCityNameProCompleted(this, new getWeatherbyCityNameProCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void getWeatherbyCityNameProAsync(string theCityName, string theUserID) {
            this.getWeatherbyCityNameProAsync(theCityName, theUserID, null);
        }
        
        public void getWeatherbyCityNameProAsync(string theCityName, string theUserID, object userState) {
            if ((this.onBegingetWeatherbyCityNameProDelegate == null)) {
                this.onBegingetWeatherbyCityNameProDelegate = new BeginOperationDelegate(this.OnBegingetWeatherbyCityNamePro);
            }
            if ((this.onEndgetWeatherbyCityNameProDelegate == null)) {
                this.onEndgetWeatherbyCityNameProDelegate = new EndOperationDelegate(this.OnEndgetWeatherbyCityNamePro);
            }
            if ((this.ongetWeatherbyCityNameProCompletedDelegate == null)) {
                this.ongetWeatherbyCityNameProCompletedDelegate = new System.Threading.SendOrPostCallback(this.OngetWeatherbyCityNameProCompleted);
            }
            base.InvokeAsync(this.onBegingetWeatherbyCityNameProDelegate, new object[] {
                        theCityName,
                        theUserID}, this.onEndgetWeatherbyCityNameProDelegate, this.ongetWeatherbyCityNameProCompletedDelegate, userState);
        }
    }
}
