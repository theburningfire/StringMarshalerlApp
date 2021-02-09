using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringMarshallerApp
{
    class MainWindowViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private string _displayText;

        public string DisplayText
        {
            get
            {
                return _displayText;
            }
            set
            {
                _displayText = value;
                OnPropertyChanged("DisplayText");
            }
        }

        public void GetVersionCharPtr()
        {
            IntPtr intPtr = DLLImports.GetVersionCharPtr();
            DisplayText = "GetVersionCharPtr() returned \"" + System.Runtime.InteropServices.Marshal.PtrToStringAnsi(intPtr) + "\"";
        }

        public void GetVersionCharPtr_2()
        {
            DisplayText = "GetVersionCharPtr_2() returned \"" + DLLImports.GetVersionCharPtr_2() + "\"";
        }

        public void GetVersionBSTR()
        {
            DisplayText = "GetVersionBSTR() returned \"" + DLLImports.GetVersionBSTR() + "\"";
        }

        public void SetVersionCharPtr()
        {
            DLLImports.SetVersionCharPtr("Version 1.0");
            DisplayText = "SetVersionCharPtr(\"Version 1.0\") passed version \"" + DLLImports.GetVersionBSTR() + "\"";
        }

        public void SetVersionBSTR()
        {
            DLLImports.SetVersionBSTR("Version 2.0");
            DisplayText = "SetVersionBSTR(\"Version 2.0\") passed version \"" + DLLImports.GetVersionBSTR() + "\"";
        }

        public void GetVersionCharPtrPtr()
        {
            IntPtr intPtr;
            DLLImports.GetVersionCharPtrPtr(out intPtr);
            DisplayText = "GetVersionCharPtr() returned " + System.Runtime.InteropServices.Marshal.PtrToStringAnsi(intPtr); ;
        }

        public void GetVersionBSTRPtr()
        {
            string version = "";
            DLLImports.GetVersionBSTRPtr(out version);
            DisplayText = "GetVersionBSTRPtr() returned " + version;
        }

        public void GetVersionBuffer()
        {
            UInt32 size = 0;
            DLLImports.GetVersionBuffer(null, ref size);
            
            var sb = new StringBuilder((int)size);
            DLLImports.GetVersionBuffer(sb, ref size);
            DisplayText = "GetVersionBuffer() returned " + sb.ToString();
        }

        public void SetVersion()
        {
            DLLImports.SetVersion("Version 8.0");
            DisplayText = DLLImports.GetLastVersionFunctionName() + " was called!";
        }

        public void SetStringArray()
        {
            string[] array = new string[4] {"one", "two", "three", "four"};
            DLLImports.SetStringArray(array);

            string [] results = null;
            DisplayText = "The following strings were passed: ";
            DLLImports.GetStringArray(out results);
            foreach (var item in results)
            {
                DisplayText += "\"" + item + "\" ";
            }
        }

        #region INotifyPropertyChanged

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion    
    }
}
