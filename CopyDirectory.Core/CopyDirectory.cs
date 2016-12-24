using System;
using System.IO;

namespace CopyDirectory.Core
{
    public class CopyDirectory
    {
        private readonly Progress<string> _progress;

        public CopyDirectory(Progress<string> progress)
        {
            _progress = progress;
        }

        public void Copy(string pathToSourceFolder, string pathToDestinationFolder)
        {
            ValidateThatSourceDirectoryExists(pathToSourceFolder);
            ValidateThatSourceDirectoryDoesNotExistInDestinationDirectory(pathToSourceFolder, pathToDestinationFolder);

            pathToDestinationFolder = CreateDestinationFolderAndReturnNewPath(pathToSourceFolder, pathToDestinationFolder);

            CopyFilesToTargetDirectory(pathToSourceFolder, pathToDestinationFolder);

            CopySubDirectoriesWithFiles(pathToSourceFolder, pathToDestinationFolder);
        }

        private static void ValidateThatSourceDirectoryExists(string pathToSourceFolder)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToSourceFolder);

            if (!directory.Exists)
            {
                throw new DirectoryNotFoundException($"The specified directory doesn't exist: '{pathToSourceFolder}'");
            }
        }

        private static void ValidateThatSourceDirectoryDoesNotExistInDestinationDirectory(string pathToSourceFolder, string pathToDestinationFolder)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToSourceFolder);

            if (Directory.Exists(Path.Combine(pathToDestinationFolder, directory.Name)))
            {
                throw new IOException($"Directory '{directory.Name}' already exists in '{pathToDestinationFolder}'");
            }
        }

        private static string CreateDestinationFolderAndReturnNewPath(string pathToSourceFolder, string pathToDestinationFolder)
        {
            DirectoryInfo directory = new DirectoryInfo(pathToSourceFolder);

            var path = Path.Combine(pathToDestinationFolder, directory.Name);
            
            Directory.CreateDirectory(path);

            return path;
        }

        private void CopyFilesToTargetDirectory(string pathToSourceFolder, string pathToDestinationFolder)
        {
            var files = Directory.GetFiles(pathToSourceFolder);

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);

                var resultFilePath = Path.Combine(pathToDestinationFolder, Path.GetFileName(fileInfo.Name));

                File.Copy(file, resultFilePath);

                ((IProgress<string>) _progress)?.Report(resultFilePath);
            }
        }

        private void CopySubDirectoriesWithFiles(string pathToSourceFolder, string pathToDestinationFolder)
        {
            foreach (var subDirectory in Directory.GetDirectories(pathToSourceFolder))
            {
                Copy(subDirectory, pathToDestinationFolder);
            }
        }
    }
}
