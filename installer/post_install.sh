#!/bin/bash

/bin/chmod.exe a+x /var
/bin/mkpasswd.exe -l -c > /etc/passwd
/bin/mkgroup.exe --local > /etc/group
/bin/ssh-host-config -y
/bin/sed -i 's/%INSTALLPATH%/${1}/g' ${1}/Cygwin.bat
