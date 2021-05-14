#define MyAppName "ContactsApp"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Izvekova Arina"
#define MyAppURL "https://github.com/Izvekova/ContactsApp"
#define MyAppExeName "ContactsAppUI.exe"

[Setup]
; Уникальный идентификатор приложения
AppId={{DA688CB8-7332-41BC-A7B3-638C47FA6AED}

; Прочая информация, отображаемая при установке
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
;Путь установки по-умолчанию
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Каталог, куда будет записан собранный setup и имя исполняемого файла
OutputDir = Installers
OutputBaseFilename=ContactsAppSetup
;Параметры сжатия
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
