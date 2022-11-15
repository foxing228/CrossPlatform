[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
  $ChocoInstallPath = "$env:SystemDrive\ProgramData\Chocolatey\bin"

  if (!(Test-Path $ChocoInstallPath)) {
      iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
  }