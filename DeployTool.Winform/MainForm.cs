using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AutoMapper;
using DeployTool.Core.Interfaces.Services;
using DeployTool.Core.Models;
using DeployTool.Core.Repositories;
using DeployTool.Core.Settings;
using DeployTool.SharedKernel.Exceptions;
using DeployTool.Ui.Controls;
using DeployTool.Ui.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DeployTool.WinForm
{
    public partial class MainForm : Form
    {
        private readonly ILogger<MainForm> _logger;
        private readonly IMapper _mapper;
        private readonly ICatalogConfigRepository _catalogConfigRepository;
        private readonly ICatalogRepository _catalogRepository;
        private readonly IWorkflowConfigRepository _workflowConfigRepository;
        private readonly IDeployService _deployService;
        private readonly IOptions<AppSettings> _appSettings;

        public MainForm(
            ILogger<MainForm> logger,
            IMapper mapper,
            ICatalogConfigRepository catalogConfigRepository,
            ICatalogRepository catalogRepository,
            IWorkflowConfigRepository workflowConfigRepository,
            IDeployService deployService,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _catalogConfigRepository = catalogConfigRepository;
            _catalogRepository = catalogRepository;
            _workflowConfigRepository = workflowConfigRepository;
            _deployService = deployService;
            _appSettings = appSettings;

            InitializeComponent();
            SetupControls();
        }

        private void CatalogConfigSave(string currentCatalog, string currentWorkFlow)
        {
            _catalogConfigRepository.Save(new CatalogConfig()
            {
                CurrentCatalog = currentCatalog,
                CurrentWorkFlow = currentWorkFlow
            });
        }

        private void WorkflowConfigSave(string currentCatalog, string currentWorkFlow, WorkflowConfig workflowConfig)
        {
            _workflowConfigRepository.Save(currentCatalog, currentWorkFlow,workflowConfig);
        }

        #region Events
        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void ExecuteDeploy_Click(object sender, EventArgs e)
        {
            var workflowConfigDto = GetWorkflowConfigDtoByUi();
            var workflowConfig = _mapper.Map<WorkflowConfig>(workflowConfigDto);
            workflowConfig.LastExecuteTime = DateTime.Now;
            var targetFolderName = workflowConfig.LastExecuteTime.ToString("yyyyMMddHHmmss");

            _deployService.ExecuteDeploy(workflowConfig);
            WorkflowConfigSave(cboCatalog.SelectedItem.ToString(), cboWorkflow.SelectedItem.ToString(), workflowConfig);
            RenderUiByWorkFlowConfigDto(_mapper.Map<WorkflowConfigDto>(workflowConfig));
            MessageBox.Show(@"執行完成！");
        }

        private void CboCatalogConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderCboWorkflow(_catalogRepository.GetWorkFlowConfigs(cboCatalog.SelectedItem.ToString()), null);
        }

        private void CboWorkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            var catalogName = cboCatalog.SelectedItem?.ToString();
            var workflowName = cboWorkflow.SelectedItem?.ToString();
            var workflowConfigDto =
                catalogName == null || workflowName == null ? new WorkflowConfigDto() :
                _mapper.Map<WorkflowConfigDto>(_workflowConfigRepository.Read(catalogName, workflowName));
            RenderUiByWorkFlowConfigDto(workflowConfigDto);
            CatalogConfigSave(catalogName, workflowName);
        }

        private void OpenWorkflowConfig_Click(object sender, EventArgs e)
        {
            var path = _appSettings.Value.GetWorkflowConfigPath(cboCatalog.SelectedItem.ToString(), cboWorkflow.SelectedItem.ToString());
            if (!File.Exists(path)) throw new CustomException("此路徑無檔案！");
            Process.Start(new ProcessStartInfo
            {
                FileName = _appSettings.Value.GetWorkflowConfigPath(cboCatalog.SelectedItem.ToString(), cboWorkflow.SelectedItem.ToString()),
                UseShellExecute = true
            });
        }

        private void OpenCatalogFolder_Click(object sender, EventArgs e)
        {
            var path = _appSettings.Value.GetCatalogFolderPath(cboCatalog.SelectedItem.ToString());
            if (!Directory.Exists(path)) throw new CustomException("此路徑無資料夾！");
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private void OpenExecuteFolder_Click(object sender, EventArgs e)
        {
            var workflowConfigDto = GetWorkflowConfigDtoByUi();
            var workflowConfig = _mapper.Map<WorkflowConfig>(workflowConfigDto);
            var path = workflowConfig.GetTargetDirectoryPath();
            if (!Directory.Exists(path)) throw new CustomException("此路徑無資料夾！");
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var workflowConfigDto = GetWorkflowConfigDtoByUi();
            var workflowConfig = _mapper.Map<WorkflowConfig>(workflowConfigDto);
            WorkflowConfigSave(cboCatalog.SelectedItem.ToString(), cboWorkflow.SelectedItem.ToString(), workflowConfig);
        }

        private void OpenOriginalPathFolder_Click(object sender, EventArgs e)
        {
            var path = tbOriginalPath.Text;
            if (!Directory.Exists(path)) throw new CustomException("此路徑無資料夾！");
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private void OpenTargetPathFolder_Click(object sender, EventArgs e)
        {
            var path = tbTargetPath.Text;
            if (!Directory.Exists(path)) throw new CustomException("此路徑無資料夾！");
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }
        #endregion

        #region Ui
        private void RenderCboWorkflow(List<string> workflowKeys, string currentWorkflow)
        {
            cboWorkflow.DataSource = workflowKeys;
            cboWorkflow.SelectedIndex = currentWorkflow == null ? -1 : cboWorkflow.FindStringExact(currentWorkflow);
        }

        private void RenderUiByWorkFlowConfigDto(WorkflowConfigDto workflowConfig)
        {
            tbOriginalPath.Text = workflowConfig.OriginalPath;
            tbTargetPath.Text = workflowConfig.TargetPath;
            tbLastWriteTime.Text = workflowConfig.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");
            tbLastExecuteTime.Text = workflowConfig.LastExecuteTime.ToString("yyyy/MM/dd HH:mm:ss");
            dgvProject.DataSource = workflowConfig.Projects;
            tbFtpUrl.Text = workflowConfig.FtpUrl;
            tbFtpUserName.Text = workflowConfig.FtpUserName;
            tbFtpPassword.Text = workflowConfig.FtpPassword;
            tbFtpPath.Text = workflowConfig.FtpPath;
            tbCompressionPassword.Text = workflowConfig.CompressionPassword;
            tbPublishFtpUrl.Text = workflowConfig.PublishFtpUrl;
            tbPublishFtpUserName.Text = workflowConfig.PublishFtpUserName;
            tbPublishFtpPassword.Text = workflowConfig.PublishFtpPassword;
            tbPublishFtpPath.Text = workflowConfig.PublishFtpPath;
            tbDiskPath.Text = workflowConfig.DiskPath;
            tbIgnoreRule.Text = workflowConfig.IgnoreRules;
            tbBuildConfiguration.Text = workflowConfig.BuildConfiguration;
            tbMsBuildPath.Text = workflowConfig.MsBuildPath;
            tbSlnPath.Text = workflowConfig.SlnPath;
            chkIsIgnoreCs.Checked = workflowConfig.IsIgnoreCs;
            chkIsIgnoreConfig.Checked = workflowConfig.IsIgnoreConfig;
            chkIsKeepEmptyDir.Checked = workflowConfig.IsKeepEmptyDir;
            chkIsCompression.Checked = workflowConfig.IsCompression;
            chkIsCopyToFtp.Checked = workflowConfig.IsCopyToFtp;
            chkIsPublish.Checked = workflowConfig.IsPublishToFtp;
            chkIsPublishToDisk.Checked = workflowConfig.IsPublishToDisk;
            chkIsBuild.Checked = workflowConfig.IsBuild;
        }

        private WorkflowConfigDto GetWorkflowConfigDtoByUi()
        {
            var itemConfig = new WorkflowConfigDto();
            itemConfig.OriginalPath = tbOriginalPath.Text;
            itemConfig.TargetPath = tbTargetPath.Text;
            itemConfig.LastWriteTime = DateTime.Parse((string)tbLastWriteTime.Text);
            itemConfig.LastExecuteTime = DateTime.Parse((string)tbLastExecuteTime.Text);
            var projects = (dgvProject.DataSource as List<ProjectConfigDto>);
            itemConfig.Projects = projects;
            itemConfig.IsIgnoreCs = chkIsIgnoreCs.Checked;
            itemConfig.IsIgnoreConfig = chkIsIgnoreConfig.Checked;
            itemConfig.IsCompression = chkIsCompression.Checked;
            itemConfig.IsKeepEmptyDir = chkIsKeepEmptyDir.Checked;
            itemConfig.IsBuild = chkIsBuild.Checked;
            itemConfig.IsCopyToFtp = chkIsCopyToFtp.Checked;
            itemConfig.CompressionPassword = tbCompressionPassword.Text;
            itemConfig.FtpUrl = tbFtpUrl.Text;
            itemConfig.FtpUserName = tbFtpUserName.Text;
            itemConfig.FtpPassword = tbFtpPassword.Text;
            itemConfig.FtpPath = tbFtpPath.Text;
            itemConfig.IsPublishToFtp = chkIsPublish.Checked;
            itemConfig.PublishFtpUrl = tbPublishFtpUrl.Text;
            itemConfig.PublishFtpUserName = tbPublishFtpUserName.Text;
            itemConfig.PublishFtpPassword = tbPublishFtpPassword.Text;
            itemConfig.PublishFtpPath = tbPublishFtpPath.Text;
            itemConfig.IsPublishToDisk = chkIsPublishToDisk.Checked;
            itemConfig.DiskPath = tbDiskPath.Text;
            itemConfig.IgnoreRules = tbIgnoreRule.Text;
            itemConfig.BuildConfiguration = tbBuildConfiguration.Text;
            itemConfig.MsBuildPath = tbMsBuildPath.Text;
            itemConfig.SlnPath = tbSlnPath.Text;
            return itemConfig;
        }

        private void SetupControls()
        {
            var catalogs = _catalogRepository.GetCatalogs();
            var catalogConfig = _catalogConfigRepository.Read();
            var currentCatalog = catalogConfig.CurrentCatalog;
            var currentWorkFlow = catalogConfig.CurrentWorkFlow;

            cboCatalog.DataSource = catalogs;
            cboCatalog.SelectedIndex = cboCatalog.FindStringExact(currentCatalog);
            RenderCboWorkflow(_catalogRepository.GetWorkFlowConfigs(currentCatalog), currentWorkFlow);
            var workflowConfigDto =
                _mapper.Map<WorkflowConfigDto>(_workflowConfigRepository.Read(currentCatalog, currentWorkFlow));
            RenderUiByWorkFlowConfigDto(workflowConfigDto);
            cboCatalog.SelectedIndexChanged += CboCatalogConfig_SelectedIndexChanged;
            cboWorkflow.SelectedIndexChanged += CboWorkflow_SelectedIndexChanged;

            //init Project Grid
            var dgv = dgvProject;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            var colIgnoreRules = dgv.Columns["IgnoreRules"];
            colIgnoreRules.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            colIgnoreRules.CellTemplate = new CustomDataGridViewTextBoxCell();
        }
        #endregion
    }
}
