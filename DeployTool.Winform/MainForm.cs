using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using DeployTool.Core.Interfaces.Services;
using DeployTool.Core.Models;
using DeployTool.Core.Repositories;
using DeployTool.Core.Settings;
using DeployTool.SharedKernel.Exceptions;
using DeployTool.Ui.Controls;
using DeployTool.WinForm.Models;
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
        private readonly IDeployWorkConfigRepository _deployWorkConfigRepository;
        private readonly IDeployService _deployService;
        private readonly IOptions<AppSettings> _appSettings;

        public MainForm(
            ILogger<MainForm> logger,
            IMapper mapper,
            ICatalogConfigRepository catalogConfigRepository,
            ICatalogRepository catalogRepository,
            IDeployWorkConfigRepository deployWorkConfigRepository,
            IDeployService deployService,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _catalogConfigRepository = catalogConfigRepository;
            _catalogRepository = catalogRepository;
            _deployWorkConfigRepository = deployWorkConfigRepository;
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
                CurrentDeployWork = currentWorkFlow
            });
        }

        private void DeployWorkConfigSave(string currentCatalog, string currentWorkFlow, DeployWorkConfig deployWorkConfig)
        {
            _deployWorkConfigRepository.Save(currentCatalog, currentWorkFlow,deployWorkConfig);
        }

        #region Events
        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void ExecuteDeploy_Click(object sender, EventArgs e)
        {
            var deployWorkConfigDto = GetDeployWorkConfigDtoByUi();
            var deployWorkConfig = _mapper.Map<DeployWorkConfig>(deployWorkConfigDto);
            deployWorkConfig.LastExecuteTime = DateTime.Now;
            var targetFolderName = deployWorkConfig.LastExecuteTime.ToString("yyyyMMddHHmmss");

            _deployService.ExecuteDeploy(deployWorkConfig);
            DeployWorkConfigSave(cboCatalog.SelectedItem.ToString(), cboDeployWork.SelectedItem.ToString(), deployWorkConfig);
            RenderUiByWorkFlowConfigDto(_mapper.Map<DeployWorkConfigDto>(deployWorkConfig));
            MessageBox.Show(@"執行完成！");
        }

        private void CboCatalogConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderCboDeployWork(_catalogRepository.GetWorkFlowConfigs(cboCatalog.SelectedItem.ToString()), null);
        }

        private void CboDeployWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            var catalogName = cboCatalog.SelectedItem?.ToString();
            var deployWorkName = cboDeployWork.SelectedItem?.ToString();
            var deployWorkConfigDto =
                catalogName == null || deployWorkName == null ? new DeployWorkConfigDto() :
                _mapper.Map<DeployWorkConfigDto>(_deployWorkConfigRepository.Read(catalogName, deployWorkName));
            RenderUiByWorkFlowConfigDto(deployWorkConfigDto);
            CatalogConfigSave(catalogName, deployWorkName);
        }

        private void OpenDeployWorkConfig_Click(object sender, EventArgs e)
        {
            var path = _appSettings.Value.GetDeployWorkConfigPath(cboCatalog.SelectedItem.ToString(), cboDeployWork.SelectedItem.ToString());
            if (!File.Exists(path)) throw new CustomException("此路徑無檔案！");
            Process.Start(new ProcessStartInfo
            {
                FileName = _appSettings.Value.GetDeployWorkConfigPath(cboCatalog.SelectedItem.ToString(), cboDeployWork.SelectedItem.ToString()),
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
            var deployWorkConfigDto = GetDeployWorkConfigDtoByUi();
            var deployWorkConfig = _mapper.Map<DeployWorkConfig>(deployWorkConfigDto);
            var path = deployWorkConfig.GetTargetDirectoryPath();
            if (!Directory.Exists(path)) throw new CustomException("此路徑無資料夾！");
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var deployWorkConfigDto = GetDeployWorkConfigDtoByUi();
            var deployWorkConfig = _mapper.Map<DeployWorkConfig>(deployWorkConfigDto);
            DeployWorkConfigSave(cboCatalog.SelectedItem.ToString(), cboDeployWork.SelectedItem.ToString(), deployWorkConfig);
            MessageBox.Show("儲存成功");
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
        private void RenderCboDeployWork(List<string> deployWorkKeys, string currentDeployWork)
        {
            cboDeployWork.DataSource = deployWorkKeys;
            cboDeployWork.SelectedIndex = currentDeployWork == null ? cboDeployWork.FindStringExact(deployWorkKeys.First()) : cboDeployWork.FindStringExact(currentDeployWork);
        }

        private void RenderUiByWorkFlowConfigDto(DeployWorkConfigDto deployWorkConfig)
        {
            tbOriginalPath.Text = deployWorkConfig.OriginalPath;
            tbTargetPath.Text = deployWorkConfig.TargetPath;
            tbLastWriteTime.Text = deployWorkConfig.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");
            tbLastExecuteTime.Text = deployWorkConfig.LastExecuteTime.ToString("yyyy/MM/dd HH:mm:ss");
            dgvProject.DataSource = deployWorkConfig.Projects;
            tbFtpUrl.Text = deployWorkConfig.FtpUrl;
            tbFtpUserName.Text = deployWorkConfig.FtpUserName;
            tbFtpPassword.Text = deployWorkConfig.FtpPassword;
            tbFtpPath.Text = deployWorkConfig.FtpPath;
            tbCompressionPassword.Text = deployWorkConfig.CompressionPassword;
            tbPublishFtpUrl.Text = deployWorkConfig.PublishFtpUrl;
            tbPublishFtpUserName.Text = deployWorkConfig.PublishFtpUserName;
            tbPublishFtpPassword.Text = deployWorkConfig.PublishFtpPassword;
            tbPublishFtpPath.Text = deployWorkConfig.PublishFtpPath;
            tbDiskPath.Text = deployWorkConfig.DiskPath;
            tbIgnoreRule.Text = deployWorkConfig.IgnoreRules;
            tbBuildConfiguration.Text = deployWorkConfig.BuildConfiguration;
            tbMsBuildPath.Text = deployWorkConfig.MsBuildPath;
            tbSlnPath.Text = deployWorkConfig.SlnPath;
            chkIsIgnoreCs.Checked = deployWorkConfig.IsIgnoreCs;
            chkIsIgnoreConfig.Checked = deployWorkConfig.IsIgnoreConfig;
            chkIsKeepEmptyDir.Checked = deployWorkConfig.IsKeepEmptyDir;
            chkIsCompression.Checked = deployWorkConfig.IsCompression;
            chkIsCopyToFtp.Checked = deployWorkConfig.IsCopyToFtp;
            chkIsPublish.Checked = deployWorkConfig.IsPublishToFtp;
            chkIsPublishToDisk.Checked = deployWorkConfig.IsPublishToDisk;
            chkIsBuild.Checked = deployWorkConfig.IsBuild;
        }

        private DeployWorkConfigDto GetDeployWorkConfigDtoByUi()
        {
            var itemConfig = new DeployWorkConfigDto();
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
            var currentWorkFlow = catalogConfig.CurrentDeployWork;

            cboCatalog.DataSource = catalogs;
            cboCatalog.SelectedIndex = cboCatalog.FindStringExact(currentCatalog);
            RenderCboDeployWork(_catalogRepository.GetWorkFlowConfigs(currentCatalog), currentWorkFlow);
            var deployWorkConfigDto =
                _mapper.Map<DeployWorkConfigDto>(_deployWorkConfigRepository.Read(currentCatalog, currentWorkFlow));
            RenderUiByWorkFlowConfigDto(deployWorkConfigDto);
            cboCatalog.SelectedIndexChanged += CboCatalogConfig_SelectedIndexChanged;
            cboDeployWork.SelectedIndexChanged += CboDeployWork_SelectedIndexChanged;

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
