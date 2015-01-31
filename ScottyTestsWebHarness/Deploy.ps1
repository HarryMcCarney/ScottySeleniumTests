$cmd = "$OctopusPackageDirectoryPath" + "\bin\ScottyTestsWebHarness.exe"
& "Get-Process ScottyTestsWebHarness | Stop-Process"
& "Start-Process -FilePath" $cmd


