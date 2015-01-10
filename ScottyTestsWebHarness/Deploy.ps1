$cmd = "$OctopusPackageDirectoryPath" + "\bin\Scotty.SeleniumTests.exe"

& $cmd "stop"
& $cmd "uninstall"
& $cmd "install"
& $cmd "start"



