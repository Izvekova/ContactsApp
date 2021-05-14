#define MyAppName "ContactsApp"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Izvekova Arina"
#define MyAppURL "https://github.com/Izvekova/ContactsApp"
#define MyAppExeName "ContactsAppUI.exe"

[Setup]
; ���������� ������������� ����������
AppId={{DA688CB8-7332-41BC-A7B3-638C47FA6AED}

; ������ ����������, ������������ ��� ���������
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
;���� ��������� ��-���������
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; �������, ���� ����� ������� ��������� setup � ��� ������������ �����
OutputDir = Installers
OutputBaseFilename=ContactsAppSetup
;��������� ������
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
