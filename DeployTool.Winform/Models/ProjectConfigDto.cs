namespace DeployTool.Ui.Models
{
    public class ProjectConfigDto
    {
        public string ProjectPath { get; set; }
        public string TargetPath { get; set; }
        public bool Selected { get; set; }
        public string IgnoreRules { get; set; }
    }
}