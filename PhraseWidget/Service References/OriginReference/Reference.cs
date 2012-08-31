﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17626
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace PhraseWidget.OriginReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Origin", Namespace="http://schemas.datacontract.org/2004/07/PopCornOneWebApp.Models")]
    public partial class Origin : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int OriginIdField;
        
        private string OriginNameField;
        
        private string OriginUrlField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int OriginId {
            get {
                return this.OriginIdField;
            }
            set {
                if ((this.OriginIdField.Equals(value) != true)) {
                    this.OriginIdField = value;
                    this.RaisePropertyChanged("OriginId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OriginName {
            get {
                return this.OriginNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginNameField, value) != true)) {
                    this.OriginNameField = value;
                    this.RaisePropertyChanged("OriginName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OriginUrl {
            get {
                return this.OriginUrlField;
            }
            set {
                if ((object.ReferenceEquals(this.OriginUrlField, value) != true)) {
                    this.OriginUrlField = value;
                    this.RaisePropertyChanged("OriginUrl");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OriginReference.IOriginService")]
    public interface IOriginService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IOriginService/DisplayOrigins", ReplyAction="http://tempuri.org/IOriginService/DisplayOriginsResponse")]
        System.IAsyncResult BeginDisplayOrigins(System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin> EndDisplayOrigins(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IOriginService/CreateOrigin", ReplyAction="http://tempuri.org/IOriginService/CreateOriginResponse")]
        System.IAsyncResult BeginCreateOrigin(PhraseWidget.OriginReference.Origin origin, System.AsyncCallback callback, object asyncState);
        
        bool EndCreateOrigin(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IOriginService/EditOrigin", ReplyAction="http://tempuri.org/IOriginService/EditOriginResponse")]
        System.IAsyncResult BeginEditOrigin(PhraseWidget.OriginReference.Origin origin, System.AsyncCallback callback, object asyncState);
        
        bool EndEditOrigin(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IOriginService/DeleteOrigin", ReplyAction="http://tempuri.org/IOriginService/DeleteOriginResponse")]
        System.IAsyncResult BeginDeleteOrigin(int id, System.AsyncCallback callback, object asyncState);
        
        bool EndDeleteOrigin(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOriginServiceChannel : PhraseWidget.OriginReference.IOriginService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DisplayOriginsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DisplayOriginsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CreateOriginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public CreateOriginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EditOriginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public EditOriginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeleteOriginCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DeleteOriginCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OriginServiceClient : System.ServiceModel.ClientBase<PhraseWidget.OriginReference.IOriginService>, PhraseWidget.OriginReference.IOriginService {
        
        private BeginOperationDelegate onBeginDisplayOriginsDelegate;
        
        private EndOperationDelegate onEndDisplayOriginsDelegate;
        
        private System.Threading.SendOrPostCallback onDisplayOriginsCompletedDelegate;
        
        private BeginOperationDelegate onBeginCreateOriginDelegate;
        
        private EndOperationDelegate onEndCreateOriginDelegate;
        
        private System.Threading.SendOrPostCallback onCreateOriginCompletedDelegate;
        
        private BeginOperationDelegate onBeginEditOriginDelegate;
        
        private EndOperationDelegate onEndEditOriginDelegate;
        
        private System.Threading.SendOrPostCallback onEditOriginCompletedDelegate;
        
        private BeginOperationDelegate onBeginDeleteOriginDelegate;
        
        private EndOperationDelegate onEndDeleteOriginDelegate;
        
        private System.Threading.SendOrPostCallback onDeleteOriginCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public OriginServiceClient() {
        }
        
        public OriginServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OriginServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OriginServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OriginServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<DisplayOriginsCompletedEventArgs> DisplayOriginsCompleted;
        
        public event System.EventHandler<CreateOriginCompletedEventArgs> CreateOriginCompleted;
        
        public event System.EventHandler<EditOriginCompletedEventArgs> EditOriginCompleted;
        
        public event System.EventHandler<DeleteOriginCompletedEventArgs> DeleteOriginCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhraseWidget.OriginReference.IOriginService.BeginDisplayOrigins(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDisplayOrigins(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin> PhraseWidget.OriginReference.IOriginService.EndDisplayOrigins(System.IAsyncResult result) {
            return base.Channel.EndDisplayOrigins(result);
        }
        
        private System.IAsyncResult OnBeginDisplayOrigins(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((PhraseWidget.OriginReference.IOriginService)(this)).BeginDisplayOrigins(callback, asyncState);
        }
        
        private object[] OnEndDisplayOrigins(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin> retVal = ((PhraseWidget.OriginReference.IOriginService)(this)).EndDisplayOrigins(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDisplayOriginsCompleted(object state) {
            if ((this.DisplayOriginsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DisplayOriginsCompleted(this, new DisplayOriginsCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DisplayOriginsAsync() {
            this.DisplayOriginsAsync(null);
        }
        
        public void DisplayOriginsAsync(object userState) {
            if ((this.onBeginDisplayOriginsDelegate == null)) {
                this.onBeginDisplayOriginsDelegate = new BeginOperationDelegate(this.OnBeginDisplayOrigins);
            }
            if ((this.onEndDisplayOriginsDelegate == null)) {
                this.onEndDisplayOriginsDelegate = new EndOperationDelegate(this.OnEndDisplayOrigins);
            }
            if ((this.onDisplayOriginsCompletedDelegate == null)) {
                this.onDisplayOriginsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDisplayOriginsCompleted);
            }
            base.InvokeAsync(this.onBeginDisplayOriginsDelegate, null, this.onEndDisplayOriginsDelegate, this.onDisplayOriginsCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhraseWidget.OriginReference.IOriginService.BeginCreateOrigin(PhraseWidget.OriginReference.Origin origin, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateOrigin(origin, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool PhraseWidget.OriginReference.IOriginService.EndCreateOrigin(System.IAsyncResult result) {
            return base.Channel.EndCreateOrigin(result);
        }
        
        private System.IAsyncResult OnBeginCreateOrigin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            PhraseWidget.OriginReference.Origin origin = ((PhraseWidget.OriginReference.Origin)(inValues[0]));
            return ((PhraseWidget.OriginReference.IOriginService)(this)).BeginCreateOrigin(origin, callback, asyncState);
        }
        
        private object[] OnEndCreateOrigin(System.IAsyncResult result) {
            bool retVal = ((PhraseWidget.OriginReference.IOriginService)(this)).EndCreateOrigin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnCreateOriginCompleted(object state) {
            if ((this.CreateOriginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateOriginCompleted(this, new CreateOriginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateOriginAsync(PhraseWidget.OriginReference.Origin origin) {
            this.CreateOriginAsync(origin, null);
        }
        
        public void CreateOriginAsync(PhraseWidget.OriginReference.Origin origin, object userState) {
            if ((this.onBeginCreateOriginDelegate == null)) {
                this.onBeginCreateOriginDelegate = new BeginOperationDelegate(this.OnBeginCreateOrigin);
            }
            if ((this.onEndCreateOriginDelegate == null)) {
                this.onEndCreateOriginDelegate = new EndOperationDelegate(this.OnEndCreateOrigin);
            }
            if ((this.onCreateOriginCompletedDelegate == null)) {
                this.onCreateOriginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateOriginCompleted);
            }
            base.InvokeAsync(this.onBeginCreateOriginDelegate, new object[] {
                        origin}, this.onEndCreateOriginDelegate, this.onCreateOriginCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhraseWidget.OriginReference.IOriginService.BeginEditOrigin(PhraseWidget.OriginReference.Origin origin, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginEditOrigin(origin, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool PhraseWidget.OriginReference.IOriginService.EndEditOrigin(System.IAsyncResult result) {
            return base.Channel.EndEditOrigin(result);
        }
        
        private System.IAsyncResult OnBeginEditOrigin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            PhraseWidget.OriginReference.Origin origin = ((PhraseWidget.OriginReference.Origin)(inValues[0]));
            return ((PhraseWidget.OriginReference.IOriginService)(this)).BeginEditOrigin(origin, callback, asyncState);
        }
        
        private object[] OnEndEditOrigin(System.IAsyncResult result) {
            bool retVal = ((PhraseWidget.OriginReference.IOriginService)(this)).EndEditOrigin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnEditOriginCompleted(object state) {
            if ((this.EditOriginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.EditOriginCompleted(this, new EditOriginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void EditOriginAsync(PhraseWidget.OriginReference.Origin origin) {
            this.EditOriginAsync(origin, null);
        }
        
        public void EditOriginAsync(PhraseWidget.OriginReference.Origin origin, object userState) {
            if ((this.onBeginEditOriginDelegate == null)) {
                this.onBeginEditOriginDelegate = new BeginOperationDelegate(this.OnBeginEditOrigin);
            }
            if ((this.onEndEditOriginDelegate == null)) {
                this.onEndEditOriginDelegate = new EndOperationDelegate(this.OnEndEditOrigin);
            }
            if ((this.onEditOriginCompletedDelegate == null)) {
                this.onEditOriginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnEditOriginCompleted);
            }
            base.InvokeAsync(this.onBeginEditOriginDelegate, new object[] {
                        origin}, this.onEndEditOriginDelegate, this.onEditOriginCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult PhraseWidget.OriginReference.IOriginService.BeginDeleteOrigin(int id, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDeleteOrigin(id, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool PhraseWidget.OriginReference.IOriginService.EndDeleteOrigin(System.IAsyncResult result) {
            return base.Channel.EndDeleteOrigin(result);
        }
        
        private System.IAsyncResult OnBeginDeleteOrigin(object[] inValues, System.AsyncCallback callback, object asyncState) {
            int id = ((int)(inValues[0]));
            return ((PhraseWidget.OriginReference.IOriginService)(this)).BeginDeleteOrigin(id, callback, asyncState);
        }
        
        private object[] OnEndDeleteOrigin(System.IAsyncResult result) {
            bool retVal = ((PhraseWidget.OriginReference.IOriginService)(this)).EndDeleteOrigin(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDeleteOriginCompleted(object state) {
            if ((this.DeleteOriginCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DeleteOriginCompleted(this, new DeleteOriginCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DeleteOriginAsync(int id) {
            this.DeleteOriginAsync(id, null);
        }
        
        public void DeleteOriginAsync(int id, object userState) {
            if ((this.onBeginDeleteOriginDelegate == null)) {
                this.onBeginDeleteOriginDelegate = new BeginOperationDelegate(this.OnBeginDeleteOrigin);
            }
            if ((this.onEndDeleteOriginDelegate == null)) {
                this.onEndDeleteOriginDelegate = new EndOperationDelegate(this.OnEndDeleteOrigin);
            }
            if ((this.onDeleteOriginCompletedDelegate == null)) {
                this.onDeleteOriginCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDeleteOriginCompleted);
            }
            base.InvokeAsync(this.onBeginDeleteOriginDelegate, new object[] {
                        id}, this.onEndDeleteOriginDelegate, this.onDeleteOriginCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override PhraseWidget.OriginReference.IOriginService CreateChannel() {
            return new OriginServiceClientChannel(this);
        }
        
        private class OriginServiceClientChannel : ChannelBase<PhraseWidget.OriginReference.IOriginService>, PhraseWidget.OriginReference.IOriginService {
            
            public OriginServiceClientChannel(System.ServiceModel.ClientBase<PhraseWidget.OriginReference.IOriginService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginDisplayOrigins(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("DisplayOrigins", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin> EndDisplayOrigins(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin> _result = ((System.Collections.ObjectModel.ObservableCollection<PhraseWidget.OriginReference.Origin>)(base.EndInvoke("DisplayOrigins", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginCreateOrigin(PhraseWidget.OriginReference.Origin origin, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = origin;
                System.IAsyncResult _result = base.BeginInvoke("CreateOrigin", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndCreateOrigin(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("CreateOrigin", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginEditOrigin(PhraseWidget.OriginReference.Origin origin, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = origin;
                System.IAsyncResult _result = base.BeginInvoke("EditOrigin", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndEditOrigin(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("EditOrigin", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginDeleteOrigin(int id, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = id;
                System.IAsyncResult _result = base.BeginInvoke("DeleteOrigin", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndDeleteOrigin(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("DeleteOrigin", _args, result)));
                return _result;
            }
        }
    }
}
