# Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))

choco install notepad2-mod -y;
choco install vscode -y;
choco install dotnetcore-sdk --version 2.2.105 -y;
choco install sql-server-management-studio -y;
choco install docker-desktop -y;
choco install docker-cli -y;
choco install docker-compose -y;
choco install nuget.commandline -y;

choco install docker-machine -y;
choco install git -y;
choco install firacode -y;

choco install mremoteng -y;
choco install opera -y;
choco install insomnia-rest-api-client -y;



choco install 7zip.install -y;
choco install python3 -y;

choco install chromium -y;
choco install sharex -y;
choco install jq -y;
choco install procexp -y;
choco install procmon -y;
# choco install postman -y;

# choco install debugdiagnostic -y;


# choco install linqpad -y;
# choco install stylecop -y;
choco install ack -y;
choco install which -y;

choco install gpg4win -y;
choco install docker-desktop -y;

choco install sourcetree -y;

choco install linqpad5 -y;

choco install authy-desktop -y;

choco install visualstudio2017community -y;
choco install visualstudio2017-workload-netcoretools -y;
choco install visualstudio2017-workload-netweb -y;


choco install selenium-chrome-driver -y;

choco install selenium-gecko-driver -y;

choco install selenium-ie-driver -y;
choco install selenium-edge-driver -y;

choco install selenium-opera-driver -y;
choco install selenium-all-drivers -y;


choco install wget -y;


#
# choco uninstall selenium-chrome-driver -y;
# choco uninstall selenium-gecko-driver -y;
# choco uninstall selenium-ie-driver -y;
# choco uninstall selenium-edge-driver -y;
# choco uninstall selenium-opera-driver -y;

choco install nodejs-lts -y;
choco install yarn -y;

Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All;


# docker

docker pull mcr.microsoft.com/dotnet/core/sdk:2.2;
docker pull mcr.microsoft.com/dotnet/core/sdk:2.1;

choco install jdk8 -y;


# https://stackoverflow.com/a/41428132/1766716

Set-ExecutionPolicy RemoteSigned -scope CurrentUser;
iex (new-object net.webclient).downloadstring('https://get.scoop.sh');

scoop install concfg;
scoop install curl;

concfg import solarized-dark -y;


# choco install redis -y;
choco install redis-64 -y;

choco install neo4j-community -y;
choco install mongodb -y;
choco install studio3t -y;
choco install sqlite -y;

choco install jenkins -y;

choco install make -y;

choco install neovim -y;

pip install httpie;

choco install fiddler -y;

choco install mitmproxy -y;

choco install jenkins-x -y;

docker pull mcr.microsoft.com/mssql/server:2017-latest

choco install minikube kubernetes-cli -y;

choco install kubernetes-helm -y;

Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Windows-Subsystem-Linux


choco install maven -y;


Enable-WindowsOptionalFeature -Online -FeatureName TelnetClient


choco install jmeter -y;

httkgmgr /iu:IIS-WebServerRole;IIS-WebServer;IIS-CommonHttpFeatures;IIS-StaticContent;IIS-DefaultDocument;IIS-DirectoryBrowsing;IIS-HttpErrors;IIS-ApplicationDevelopment;IIS-ASPNET;IIS-NetFxExtensibility;IIS-ISAPIExtensions;IIS-ISAPIFilter;IIS-HealthAndDiagnostics;IIS-HttpLogging;IIS-LoggingLibraries;IIS-RequestMonitor;IIS-Security;IIS-RequestFiltering;IIS-HttpCompressionStatic;IIS-WebServerManagementTools;IIS-ManagementConsole;WAS-WindowsActivationService;WAS-ProcessModel;WAS-NetFxEnvironment;WAS-ConfigurationAPI


choco install sumatrapdf -y;

Install-PackageProvider -Name Nuget -Force;

Install-Module -Name SqlServer; # Install-Module -Name SqlServer -Scope CurrentUser


choco install eventstore-oss -y;


# https://pandoc.org/installing.html
choco install pandoc -y
choco install rsvg-convert python miktex -y
choco install notepadplusplus.install -y

choco install hugo -confirm
choco install hugo-extended -y
choco install dbeaver -y