; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{69821B90-D3FD-44AA-A07D-0A6B431F4FB1}}
AppName=EasySSHd
AppVerName=EasySSHd 0.2.0
AppPublisher=RENONA-Studios
AppPublisherURL=http://renona-studios.org
AppSupportURL=http://renona-studios.org
AppUpdatesURL=http://renona-studios.org
DefaultDirName={pf}\EasySSHd
DefaultGroupName=EasySSHd
AllowNoIcons=yes
OutputBaseFilename=EasySSHd-setup
WizardSmallImageFile=icons\EasySSHd.bmp
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin


[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "cygwin\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: "..\bin\Release\EasySSHd.exe"; DestDir: "{app}\GUI"; Flags: ignoreversion
Source: "..\bin\Release\parser.dll"; DestDir: "{app}\GUI"; Flags: ignoreversion
Source: "unix2dos.exe"; DestDir: "{app}\GUI"; Flags: ignoreversion
Source: "icons\EasySSHd.ico"; DestDir: "{app}\GUI"; Flags: ignoreversion
Source: "post_install.sh"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{cm:UninstallProgram,EasySSHd}"; Filename: "{uninstallexe}"
Name: "{group}\EasySSHd"; Filename: "{app}\GUI\EasySSHd.exe"; IconFilename: "{app}\GUI\EasySSHd.ico"; Comment: "Windows SSH-server with GUI by RENONA Studios"
Name: "{commondesktop}\EasySSHd"; Filename: "{app}\GUI\EasySSHd.exe"; IconFilename: "{app}\GUI\EasySSHd.ico"; Comment: "Windows SSH-server with GUI by RENONA Studios"

[Registry]
Root: HKLM; Subkey: "SOFTWARE\Cygwin"; Flags: deletekey uninsdeletekey

Root: HKLM; Subkey: "SOFTWARE\Cygwin\setup"; ValueType: string; ValueName: "rootdir"; ValueData: "{app}"

Root: HKLM; Subkey: "SOFTWARE\Cygwin\Program Options"; Flags: deletekey uninsdeletekey
Root: HKLM; Subkey: "SOFTWARE\Cygwin\Program Options"; ValueType: string; ValueName: "EasySSHd-GUI-lang"; ValueData: "eng"

[Run]
Filename: "{app}\bin\bash.exe"; Parameters: "--login -c /post_install.sh {app}"

[UninstallRun]
Filename: "net stop sshd"; Parameters: ""; Flags: runhidden
Filename: "{app}\bin\cygrunsrv.exe"; Parameters: "-R sshd"; Flags: runhidden
Filename: "{app}\bin\sed.exe"; Parameters: " -i /ssh/d '{sys}\drivers\etc\services'"; Flags: runhidden
Filename: "{app}\GUI\unix2dos.exe"; Parameters: " {sys}\drivers\etc\services"; Flags: runhidden


[UninstallDelete]
Type: filesandordirs; Name: {app}

[Code]
const
  WM_QUIT = $0012;
var
  reUnInstall: TInputOptionWizardPage;
  afterUninstall: TWizardPage;

procedure CreateWizardPages;
begin
    reUnInstall := CreateInputOptionPage(wpWelcome, 'Options', 'What do you want this setup to do?', 'Choose an option:', True, False);
    reUnInstall.Add('Reinstall');
    reUnInstall.Add('Uninstall');
    reUnInstall.Values[0] := True;

    afterUninstall := CreateCustomPage(reUnInstall.ID, 'Unistallation finished.', '');
end;

procedure InitializeWizard;
begin
    CreateWizardPages;
end;

procedure CurPageChanged(CurPageID: Integer);
begin
  if (CurPageID = afterUninstall.ID) and (reUnInstall.Values[1]) then
  begin
    WizardForm.NextButton.Caption := 'Finish';
    WizardForm.CancelButton.Visible := false;
  end;
end;

function ShouldSkipPage(CurPageID: Integer): Boolean;
begin
  if (CurPageID = reUnInstall.ID) and not RegValueExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\\Cygwin\\Program Options', 'EasySSHd-GUI-lang') then
    Result := True
  else if (CurPageID = afterUninstall.ID) and not reUnInstall.Values[1] then
    Result := True
  else
    Result := False;
end;

function NextButtonClick(CurPageID: Integer): Boolean;
var
  ResultCode: Integer;
  AppDir: String;
begin
  if RegValueExists(HKEY_LOCAL_MACHINE, 'SOFTWARE\\Cygwin\\Program Options', 'EasySSHd-GUI-lang') then
  begin
    RegQueryStringValue(HKEY_LOCAL_MACHINE, 'SOFTWARE\Cygwin\setup', 'rootdir', AppDir);
    try
      if (CurPageID = wpFinished) then
        Result := True
      else if CurPageID = reUnInstall.ID then
      begin
        if reUnInstall.Values[0] then
        begin
          Exec(AppDir + '\unins000.exe', '', '', SW_SHOW, ewWaitUntilTerminated, ResultCode)
          if (ResultCode <> 0) then
          begin
            MsgBox('An error occured while uninstalling installed version of EasySSHd. Please try again.', mbCriticalError, MB_OK);
            Result := False;
            Exit;
          end;
          Result := True
        end;
        if reUnInstall.Values[1]  then
        begin
          Exec(AppDir + '\unins000.exe', '', '', SW_SHOW, ewWaitUntilTerminated, ResultCode)
          Result := True;
        end;
      end;
    except
        Result := True;
    end;
    Result := False;
  end;
  if (CurPageID = afterUninstall.ID) then
  begin
    PostMessage(WizardForm.Handle, WM_QUIT, 0, 0);
    Result := False;
  end;
  Result := True;
end;











