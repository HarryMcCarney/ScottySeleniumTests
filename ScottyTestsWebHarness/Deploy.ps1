$cmd = "$OctopusPackageDirectoryPath" + "\bin\Release\ScottyTestsWebHarness.exe"

& $cmd "stop"
& $cmd "uninstall"
& $cmd "install"
& $cmd "start"



