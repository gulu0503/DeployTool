using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeployTool.Infrastructure.Common
{
    public sealed class MsBuilder
    {
        public string ProjectPath { get; }
        public string LogPath { get; set; }

        public string Configuration { get; }
        public string Platform { get; }

        public int MaxCpuCount { get; set; } = 1;
        public string Target { get; set; } = "Build";

        public string MsBuildPath { get; set; }

        public string BuildOutput { get; private set; }

        public MsBuilder(string msBuildPath, string projectPath, string configuration)
        {
            MsBuildPath = msBuildPath ?? throw new ArgumentNullException(nameof(msBuildPath));
            ProjectPath = projectPath ?? throw new ArgumentNullException(nameof(projectPath));
            if (!File.Exists(ProjectPath)) throw new FileNotFoundException(projectPath);
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            LogPath = Path.Combine(Path.GetDirectoryName(ProjectPath), $"{Path.GetFileName(ProjectPath)}.{Configuration}-{Platform}.msbuild.log");
        }

        public bool Build(out string buildOutput)
        {
            List<string> arguments = new List<string>()
            {
                $"/nologo",
                $"\"{ProjectPath}\"",
                $"/p:Configuration={Configuration}",
                //$"/t:{Target}",
                $"/maxcpucount:{(MaxCpuCount > 0 ? MaxCpuCount : 1)}",
                $"/fileLoggerParameters:LogFile=\"{LogPath}\";Append;Verbosity=diagnostic;Encoding=UTF-8",
            };

            using (CommandLineProcess cmd = new CommandLineProcess(MsBuildPath, string.Join(" ", arguments)))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Build started: Project: '{ProjectPath}', Configuration: {Configuration}, Platform: {Platform}");

                // Call MsBuild:
                int exitCode = cmd.Run(out string processOutput, out string processError);

                // Check result:
                sb.AppendLine(processOutput);
                if (exitCode == 0)
                {
                    sb.AppendLine("Build completed successfully!");
                    buildOutput = sb.ToString();
                    return true;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(processError))
                        sb.AppendLine($"MSBUILD PROCESS ERROR: {processError}");
                    sb.AppendLine("Build failed!");
                    buildOutput = sb.ToString();
                    return false;
                }
            }
        }

    }
}