& "Get-Process ScottyTestsWebHarness | Stop-Process"
& "Start-Process -FilePath" + "$OctopusPackageDirectoryPath" + "\bin\ScottyTestsWebHarness.exe"
