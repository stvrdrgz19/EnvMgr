using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvMgr
{
    public partial class SPGPInstall : Form
    {
        private Form1 _form1;
        public SPGPInstall(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        string x86 = "x86";
        string x64 = "x64";
        string checkName = "placeholder";
        bool allowAddDLL = false;

        public void NewInstallThread(string installPath)
        {
            try
            {
                _form1.DisableInstallButton(false);

                //**COPY INSTALLER FROM NETWORK**
                string fileName = Path.GetFileName(Form1.fullInstallerPath);
                string pathToCopy = Path.GetDirectoryName(Form1.SPGPFilePath) + "\\" + Path.GetFileName(Form1.fullInstallerPath);
                string tempInstaller = Environment.CurrentDirectory + @"\Installers\" + fileName;
                string truePath = Path.GetDirectoryName(Form1.SPGPFilePath);
                File.Copy(pathToCopy, tempInstaller, true);

                //**SILENTLY INSTALLING SPGP
                Process spgpInstall = new Process();
                spgpInstall.StartInfo.FileName = tempInstaller;
                spgpInstall.StartInfo.Arguments = @"/S /D=" + installPath;
                spgpInstall.Start();
                spgpInstall.WaitForExit();

                //**DELETING THE INSTALLER
                File.Delete(tempInstaller);


                //**LOGGING THE BUILD THAT IS BEING INSTALLED
                try
                {
                    using (StreamWriter sw = File.AppendText(Environment.CurrentDirectory + @"\Files\InstallLog.txt"))
                    {
                        sw.WriteLine("{" + DateTime.Now + "} - SalesPad Desktop: " + truePath);
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }

                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                key.SetValue("zLastSPGPInstall", truePath);
                key.SetValue("zLastSPGPInstallLocal", installPath);

                //**IF DLL CHECKBOX CHECKED COPY X DLLs
                string extPath = truePath + "\\ExtModules\\" + Form1.selectedProductVersion + "\\";
                string custPath = truePath + "\\CustomModules\\" + Form1.selectedProductVersion + "\\";
                List<string> extendedDllToAdd = new List<string>();
                List<string> customDllToAdd = new List<string>();
                List<string> finalExtDLL = new List<string>();
                List<string> finalCustDLL = new List<string>();
                if (checkExpressPointDLLs.Checked)
                {
                    extendedDllToAdd.Add("AutomationAgent");
                    extendedDllToAdd.Add("AutomationAgentService");
                    extendedDllToAdd.Add("CaseTracker");
                    extendedDllToAdd.Add("TimeTracking");
                    extendedDllToAdd.Add("RemoteLibrary");
                    customDllToAdd.Add("ExpressPoint");
                    customDllToAdd.Add("SerialAuditing");
                    customDllToAdd.Add("PostMaster");
                    customDllToAdd.Add("SQLDependency");
                    customDllToAdd.Add("TKOElectronics");
                }

                if (checkTPGDLLs.Checked)
                {
                    extendedDllToAdd.Add("AutomationAgent");
                    extendedDllToAdd.Add("AutomationAgentService");
                    extendedDllToAdd.Add("FedExAddressValidation");
                    extendedDllToAdd.Add("Manufacturing");
                    extendedDllToAdd.Add("RemoteLibrary");
                    extendedDllToAdd.Add("ThomsonReuters");
                    customDllToAdd.Add("IntegrationToChannelAdvisor");
                    customDllToAdd.Add("IntegrationToCommerceV3");
                    customDllToAdd.Add("ThePondGuy");
                }

                if (checkEDIDLL.Checked)
                {
                    extendedDllToAdd.Add("SalesPadEDI");
                }

                if (checkAutomationAgentDLLs.Checked)
                {
                    extendedDllToAdd.Add("AutomationAgent");
                    extendedDllToAdd.Add("AutomationAgentService");
                }

                //**ADDING SELECTED DLLS TO LOG LIST AND DLL TO ADD LIST
                if (checkExpressPointDLLs.Checked || checkEDIDLL.Checked || checkTPGDLLs.Checked || checkAutomationAgentDLLs.Checked)
                {
                    foreach (string dll in extendedDllToAdd)
                    {
                        string[] edllx = Directory.GetFiles(extPath, @"SalesPad.Module." + dll + ".*", 0);
                        foreach (string edll in edllx)
                        {
                            finalExtDLL.Add(edll.Remove(0, truePath.Length + 32));
                            File.Copy(edll, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + edll.Remove(0, truePath.Length + 32), true);
                        }
                    }
                    foreach (string dll in customDllToAdd)
                    {
                        string[] cdllx = Directory.GetFiles(custPath, @"SalesPad.Module." + dll + ".*", 0);
                        foreach (string cdll in cdllx)
                        {
                            finalCustDLL.Add(cdll.Remove(0, truePath.Length + 35));
                            File.Copy(cdll, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + cdll.Remove(0, truePath.Length + 35), true);
                        }
                    }
                }

                //**IF NO DLLS ARE SELECTED IN THE LISTBOXES
                if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                {
                    //Determine what needs to change 
                    if (checkLaunchAfterInstall.Checked)
                    {
                        RegistryKey keyx = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                        string SPGPLaunchAfterInstall = "true";
                        keyx.SetValue("SPGP - Launch After Install", SPGPLaunchAfterInstall);
                    }
                    if (!checkLaunchAfterInstall.Checked)
                    {
                        RegistryKey keyx = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                        string SPGPLaunchAfterInstall = "false";
                        keyx.SetValue("SPGP - Launch After Install", SPGPLaunchAfterInstall);
                    }
                    //CODE HERE TO MOVE AND COPY CHECKBOX DLLs
                    if (finalExtDLL.Count != 0)
                    {
                        foreach (string dll in finalExtDLL)
                        {
                            File.Copy(truePath + "\\ExtModules\\" + Form1.selectedProductVersion + "\\SalesPad.Module." + dll, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + dll, true);
                            using (StreamWriter extLog = File.AppendText(Environment.CurrentDirectory + @"\Files\InstallLog.txt"))
                            {
                                extLog.WriteLine("\tExtended - SalesPad.Module." + dll.Remove(dll.Length - 4));
                            }
                        }
                    }
                    if (finalCustDLL.Count != 0)
                    {
                        foreach (string dll in finalCustDLL)
                        {
                            File.Copy(truePath + "\\CustomModules\\" + Form1.selectedProductVersion + "\\SalesPad.Module." + dll, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + dll, true);
                            using (StreamWriter custLog = File.AppendText(Environment.CurrentDirectory + @"\Files\InstallLog.txt"))
                            {
                                custLog.WriteLine("\tCustom - SalesPad.Module." + dll.Remove(dll.Length - 4));
                            }
                        }
                    }
                    if (finalExtDLL.Count != 0 || finalCustDLL.Count != 0)
                    {
                        string[] toExtract = Directory.GetFiles(Environment.CurrentDirectory + @"\DLLs");
                        foreach (string dll in toExtract)
                        {
                            ZipFile.ExtractToDirectory(dll, installPath);
                            File.Delete(dll);
                        }
                    }
                    Process.Start(installPath + "\\SalesPad.exe");
                    if (checkOpenInstallFolder.Checked)
                    {
                        Process.Start(installPath);
                    }
                    _form1.DisableInstallButton(true);
                    return;
                }

                if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text))
                {
                    foreach (string extendedDLL in lbExtendedDLLList.SelectedItems)
                    {
                        if (Form1.selectedProductVersion == "x86")
                        {
                            File.Copy(truePath + "\\ExtModules\\" + x86 + "\\SalesPad.Module." + extendedDLL, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + extendedDLL, true);
                        }
                        if (Form1.selectedProductVersion == "x64")
                        {
                            File.Copy(truePath + "\\ExtModules\\" + x64 + "\\SalesPad.Module." + extendedDLL, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + extendedDLL, true);
                        }
                        else if (Form1.selectedProductVersion == "Pre")
                        {
                            File.Copy(truePath + "\\ExtModules\\WithoutCardControl\\SalesPad.Module." + extendedDLL, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + extendedDLL, true);
                        }
                        //Log Extended DLLs
                        if (!finalExtDLL.Contains(extendedDLL))
                        {
                            finalExtDLL.Add(extendedDLL);
                        }
                    }
                }
                if (!String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                {
                    foreach (string customDLL in lbCustomDLLList.SelectedItems)
                    {
                        if (Form1.selectedProductVersion == "x86")
                        {
                            File.Copy(truePath + "\\CustomModules\\" + x86 + "\\SalesPad.Module." + customDLL, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + customDLL, true);
                        }
                        if (Form1.selectedProductVersion == "x64")
                        {
                            File.Copy(truePath + "\\CustomModules\\" + x64 + "\\SalesPad.Module." + customDLL, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + customDLL, true);
                        }
                        else if (Form1.selectedProductVersion == "Pre")
                        {
                            File.Copy(truePath + "\\CustomModules\\WithoutCardControl\\SalesPad.Module." + customDLL, Environment.CurrentDirectory + @"\DLLs\SalesPad.Module." + customDLL, true);
                        }
                        //Log Custom DLLs
                        if (!finalCustDLL.Contains(customDLL))
                        {
                            finalCustDLL.Add(customDLL);
                        }
                    }
                }
                finalExtDLL.Sort();
                finalCustDLL.Sort();

                using (StreamWriter extLog = File.AppendText(Environment.CurrentDirectory + @"\Files\InstallLog.txt"))
                {
                    foreach (string row in finalExtDLL)
                    {
                        extLog.WriteLine("\tExtended - SalesPad.Module." + row.Remove(row.Length - 4));
                    }
                }
                using (StreamWriter custLog = File.AppendText(Environment.CurrentDirectory + @"\Files\InstallLog.txt"))
                {
                    foreach (string row in finalCustDLL)
                    {
                        custLog.WriteLine("\tCustom - SalesPad.Module." + row.Remove(row.Length - 4));
                    }
                }
                string[] dllList = Directory.GetFiles(Environment.CurrentDirectory + @"\DLLs");
                foreach (string dll in dllList)
                {
                    ZipFile.ExtractToDirectory(dll, installPath);
                    File.Delete(dll);
                }
                if (checkLaunchAfterInstall.Checked)
                {
                    RegistryKey keyx = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                    string SPGPLaunchAfterInstall = "true";
                    keyx.SetValue("SPGP - Launch After Install", SPGPLaunchAfterInstall);
                }
                if (!checkLaunchAfterInstall.Checked)
                {
                    RegistryKey keyx = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
                    string SPGPLaunchAfterInstall = "false";
                    keyx.SetValue("SPGP - Launch After Install", SPGPLaunchAfterInstall);
                    _form1.DisableInstallButton(true);
                    return;
                }
                Process.Start(installPath + "\\SalesPad.exe");
                _form1.DisableInstallButton(true);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        }

        private void ModifyCheckbox()
        {
            // Method used to prompt the user to un-check dll checkbox when selecting dlls from list if checkbox is checked
            if (checkExpressPointDLLs.Checked || checkEDIDLL.Checked || checkTPGDLLs.Checked || checkAutomationAgentDLLs.Checked)
            {
                if (allowAddDLL == true)
                {
                    return;
                }
                if (allowAddDLL == false)
                {
                    string message = "The \"" + checkName + "\" checkbox is already checked. Do you want to un-check \"" + checkName + "\" and manually select dlls?";
                    string caption = "CONFIRM";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    DialogResult result;

                    result = MessageBox.Show(message, caption, buttons, icon);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        checkExpressPointDLLs.Checked = false;
                        checkEDIDLL.Checked = false;
                        checkTPGDLLs.Checked = false;
                        checkAutomationAgentDLLs.Checked = false;
                        allowAddDLL = true;
                        return;
                    }
                    else
                    {
                        allowAddDLL = true;
                        lbExtendedDLLList.ClearSelected();
                        lbCustomDLLList.ClearSelected();
                        allowAddDLL = false;
                        return;
                    }
                }
            }
        }

        private void SPGPInstall_Load(object sender, EventArgs e)
        {
            tbSelectedBuild.Text = Path.GetDirectoryName(Form1.SPGPFilePath);
            string truePath = Path.GetDirectoryName(Form1.SPGPFilePath);
            string toInstall = truePath.Remove(0, 43);

            //Load Checkbox values from registry
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Environment Manager");
            string varcheckLaunchAfterInstall = (Convert.ToString(key.GetValue("SPGP - Launch After Install")));
            if (varcheckLaunchAfterInstall == "true")
            {
                checkLaunchAfterInstall.Checked = true;
            }

            if (Form1.selectedProductVersion == "x86" || Form1.selectedProductVersion == "Pre")
            {
                tbInstallLocation.Text = @"C:\Program Files (x86)\SalesPad.Desktop\" + toInstall;
                string[] eDLLList = Directory.GetFiles(truePath + @"\ExtModules\" + x86);
                foreach (string eDLL in eDLLList)
                {
                    lbExtendedDLLList.Items.Add(eDLL.Remove(0, truePath.Length + 32));
                }
                string[] cDLLList = Directory.GetFiles(truePath + @"\CustomModules\" + x86);
                foreach (string cDLL in cDLLList)
                {
                    lbCustomDLLList.Items.Add(cDLL.Remove(0, truePath.Length + 35));
                }
            }
            else
            {
                tbInstallLocation.Text = @"C:\Program Files\SalesPad.Desktop\" + toInstall;
                string[] eDLLList = Directory.GetFiles(truePath + @"\ExtModules\" + x64);
                foreach (string eDLL in eDLLList)
                {
                    lbExtendedDLLList.Items.Add(eDLL.Remove(0, truePath.Length + 32));
                }
                string[] cDLLList = Directory.GetFiles(truePath + @"\CustomModules\" + x64);
                foreach (string cDLL in cDLLList)
                {
                    lbCustomDLLList.Items.Add(cDLL.Remove(0, truePath.Length + 35));
                }
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory + @"\Installers");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            string installPath = tbInstallLocation.Text;
            //**CHECKING TO INSURE THE USER DOESN'T INSTALL IN THE DEFAULT DIRECTORY**
            if (installPath == @"C:\Program Files\SalesPad.Desktop\")
            {
                MessageBox.Show("Please enter an install location different than the default \"C:\\Program Files\\SalesPad.Desktop\\\"");
                return;
            }
            //**PROMPTING THE USER TO OVERWRITE EXISTING INSTALLS IF TO INSTALL PATH MATCHES**
            if (Directory.Exists(installPath))
            {
                string existsMessage = "SalesPad is already installed in the specified location, do you want to overwrite this install?";
                string existsCaption = "EXISTS";
                MessageBoxButtons existsButtons = MessageBoxButtons.YesNo;
                MessageBoxIcon existsIcon = MessageBoxIcon.Warning;
                DialogResult existsResult;

                existsResult = MessageBox.Show(existsMessage, existsCaption, existsButtons, existsIcon);
                if (existsResult == DialogResult.Yes)
                {
                    //Deleting existing directory if Yes
                    Directory.Delete(installPath, true);
                }
                else
                {
                    return;
                }
            }
            this.Close();

            Thread newInstl = new Thread(() => NewInstallThread(installPath));
            newInstl.Start();
            return;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbExtendedDLLList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModifyCheckbox();
            return;
        }

        private void lbCustomDLLList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModifyCheckbox();
            return;
        }

        private void checkExpressPointDLLs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkExpressPointDLLs.Checked)
            {
                if (checkEDIDLL.Checked || checkTPGDLLs.Checked || checkAutomationAgentDLLs.Checked)
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked. Checking this will un-check \"" + checkName + "\", do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (checkName == "EDI DLL")
                            {
                                checkEDIDLL.Checked = false;
                            }
                            if (checkName == "TPG DLLs")
                            {
                                checkTPGDLLs.Checked = false;
                            }
                            if (checkName == "Automation Agent DLLs")
                            {
                                checkAutomationAgentDLLs.Checked = false;
                            }
                            checkName = "Expresspoint DLLs";
                            return;
                        }
                        else
                        {
                            checkExpressPointDLLs.Checked = false;
                            return;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked and there are selected dlls. Checking this will un-check \"" + checkName + "\" and any selected Extended or Custom dlls, do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            if (checkName == "EDI DLL")
                            {
                                checkEDIDLL.Checked = false;
                            }
                            if (checkName == "TPG DLLs")
                            {
                                checkTPGDLLs.Checked = false;
                            }
                            if (checkName == "Automation Agent DLLs")
                            {
                                checkAutomationAgentDLLs.Checked = false;
                            }
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "Expresspoint DLLs";
                            return;
                        }
                        else
                        {
                            checkExpressPointDLLs.Checked = false;
                            return;
                        }
                    }
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        checkName = "Expresspoint DLLs";
                        return;
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "There are selected dlls. Do you wish to add these dlls in addition with the ones added with this checkbox? Selecting no will un-select any selected dlls.";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            allowAddDLL = true;
                            checkName = "Expresspoint DLLs";
                            return;
                        }
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "Expresspoint DLLs";
                            return;
                        }
                        if (result == DialogResult.Cancel)
                        {
                            checkExpressPointDLLs.Checked = false;
                            return;
                        }
                        return;
                    }
                }
            }
            return;
        }

        private void checkEDIDLL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEDIDLL.Checked)
            {
                if (checkExpressPointDLLs.Checked || checkTPGDLLs.Checked || checkAutomationAgentDLLs.Checked)
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked. Checking this will un-check \"" + checkName + "\", do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            if (checkName == "Expresspoint DLLs")
                            {
                                checkExpressPointDLLs.Checked = false;
                            }
                            if (checkName == "TPG DLLs")
                            {
                                checkTPGDLLs.Checked = false;
                            }
                            if (checkName == "Automation Agent DLLs")
                            {
                                checkAutomationAgentDLLs.Checked = false;
                            }
                            checkName = "EDI DLL";
                            return;
                        }
                        else
                        {
                            checkEDIDLL.Checked = false;
                            return;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked and there are selected dlls. Checking this will un-check \"" + checkName + "\" and any selected Extended or Custom dlls, do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            if (checkName == "Expresspoint DLLs")
                            {
                                checkExpressPointDLLs.Checked = false;
                            }
                            if (checkName == "TPG DLLs")
                            {
                                checkTPGDLLs.Checked = false;
                            }
                            if (checkName == "Automation Agent DLLs")
                            {
                                checkAutomationAgentDLLs.Checked = false;
                            }
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "EDI DLL";
                            return;
                        }
                        else
                        {
                            checkEDIDLL.Checked = false;
                            return;
                        }
                    }
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        checkName = "EDI DLL";
                        return;
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "There are selected dlls. Do you wish to add these dlls in addition with the ones added with this checkbox? Selecting no will un-select any selected dlls.";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            allowAddDLL = true;
                            checkName = "EDI DLL";
                            return;
                        }
                        if (result == DialogResult.No)
                        {
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "EDI DLL";
                            return;
                        }
                        if (result == DialogResult.Cancel)
                        {
                            checkEDIDLL.Checked = false;
                            return;
                        }
                        return;
                    }
                }
            }
            return;
        }

        private void checkTPGDLLs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTPGDLLs.Checked)
            {
                if (checkExpressPointDLLs.Checked || checkEDIDLL.Checked || checkAutomationAgentDLLs.Checked)
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked. Checking this will un-check \"" + checkName + "\", do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            if (checkName == "Expresspoint DLLs")
                            {
                                checkExpressPointDLLs.Checked = false;
                            }
                            if (checkName == "EDI DLL")
                            {
                                checkEDIDLL.Checked = false;
                            }
                            if (checkName == "Automation Agent DLLs")
                            {
                                checkAutomationAgentDLLs.Checked = false;
                            }
                            checkName = "TPG DLLs";
                            return;
                        }
                        else
                        {
                            checkTPGDLLs.Checked = false;
                            return;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked and there are selected dlls. Checking this will un-check \"" + checkName + "\" and any selected Extended or Custom dlls, do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            if (checkName == "Expresspoint DLLs")
                            {
                                checkExpressPointDLLs.Checked = false;
                            }
                            if (checkName == "EDI DLL")
                            {
                                checkEDIDLL.Checked = false;
                            }
                            if (checkName == "Automation Agent DLLs")
                            {
                                checkAutomationAgentDLLs.Checked = false;
                            }
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "TPG DLLs";
                            return;
                        }
                        else
                        {
                            checkTPGDLLs.Checked = false;
                            return;
                        }
                    }
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        checkName = "TPG DLLs";
                        return;
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "There are selected dlls. Do you wish to add these dlls in addition with the ones added with this checkbox? Selecting no will un-select any selected dlls.";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            allowAddDLL = true;
                            checkName = "TPG DLLs";
                            return;
                        }
                        if (result == DialogResult.No)
                        {
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "TPG DLLs";
                            return;
                        }
                        if (result == DialogResult.Cancel)
                        {
                            checkTPGDLLs.Checked = false;
                            return;
                        }
                        return;
                    }
                }
            }
            return;
        }

        private void checkAutomationAgentDLLs_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutomationAgentDLLs.Checked)
            {
                if (checkExpressPointDLLs.Checked || checkEDIDLL.Checked || checkTPGDLLs.Checked)
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked. Checking this will un-check \"" + checkName + "\", do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            if (checkName == "Expresspoint DLLs")
                            {
                                checkExpressPointDLLs.Checked = false;
                            }
                            if (checkName == "EDI DLL")
                            {
                                checkEDIDLL.Checked = false;
                            }
                            if (checkName == "TPG DLLs")
                            {
                                checkTPGDLLs.Checked = false;
                            }
                            checkName = "Automation Agent DLLs";
                            return;
                        }
                        else
                        {
                            checkAutomationAgentDLLs.Checked = false;
                            return;
                        }
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "The \"" + checkName + "\" checkbox is already checked and there are selected dlls. Checking this will un-check \"" + checkName + "\" and any selected Extended or Custom dlls, do you want to continue?";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            if (checkName == "Expresspoint DLLs")
                            {
                                checkExpressPointDLLs.Checked = false;
                            }
                            if (checkName == "EDI DLL")
                            {
                                checkEDIDLL.Checked = false;
                            }
                            if (checkName == "TPG DLLs")
                            {
                                checkTPGDLLs.Checked = false;
                            }
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "Automation Agent DLLs";
                            return;
                        }
                        else
                        {
                            checkAutomationAgentDLLs.Checked = false;
                            return;
                        }
                    }
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) && String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        checkName = "Automation Agent DLLs";
                        return;
                    }
                    if (!String.IsNullOrWhiteSpace(lbExtendedDLLList.Text) || !String.IsNullOrWhiteSpace(lbCustomDLLList.Text))
                    {
                        string message = "There are selected dlls. Do you wish to add these dlls in addition with the ones added with this checkbox? Selecting no will un-select any selected dlls.";
                        string caption = "CONFIRM";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                        MessageBoxIcon icon = MessageBoxIcon.Question;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons, icon);
                        if (result == DialogResult.Yes)
                        {
                            allowAddDLL = true;
                            checkName = "Automation Agent DLLs";
                            return;
                        }
                        if (result == DialogResult.No)
                        {
                            allowAddDLL = true;
                            lbExtendedDLLList.ClearSelected();
                            lbCustomDLLList.ClearSelected();
                            allowAddDLL = false;
                            checkName = "Automation Agent DLLs";
                            return;
                        }
                        if (result == DialogResult.Cancel)
                        {
                            checkAutomationAgentDLLs.Checked = false;
                            return;
                        }
                        return;
                    }
                }
            }
            return;
        }
    }
}
