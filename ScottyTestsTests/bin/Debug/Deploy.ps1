$cmd = "$OctopusPackageDirectoryPath" + "\bin\ScottyTestsWebHarness.exe"

& $cmd "stop"
& $cmd "uninstall"
& $cmd "install"
& $cmd "start"



