; Instalador de Inventario Río Bravo (Inno Setup 7).
; Compilar desde esta carpeta, después de compilar el proyecto en Release:
;   "C:\Program Files\Inno Setup 7\ISCC.exe" /DClaveInstalador=LA_CLAVE RioBravo.iss
; La clave nunca se escribe aquí: este archivo va a git y el instalador incluye el .env de producción.

#ifndef ClaveInstalador
  #error Falta /DClaveInstalador=... (contraseña que cifra el instalador)
#endif

#define Nombre "Inventario Río Bravo"
#define Exe "gestion_inventario_rio_bravo.exe"
#define Release "..\bin\Release"
#define Version GetVersionNumbersString(Release + "\" + Exe)

[Setup]
AppId={{6F2B8C1E-4A7D-4E7B-9B3A-2D5C8E1F0A94}
AppName={#Nombre}
AppVersion={#Version}
AppPublisher=Río Bravo
DefaultDirName={autopf}\{#Nombre}
DefaultGroupName={#Nombre}
DisableProgramGroupPage=yes
; Sin permisos de administrador: se instala para el usuario actual.
PrivilegesRequired=lowest
Password={#ClaveInstalador}
Encryption=yes
OutputDir=Output
OutputBaseFilename=InstalarInventarioRioBravo-{#Version}
UninstallDisplayIcon={app}\{#Exe}
SetupIconFile=..\Resources\RioBravo.ico
Compression=lzma2
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "es"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "escritorio"; Description: "Crear un ícono en el escritorio"; GroupDescription: "Íconos:"

[Files]
Source: "{#Release}\{#Exe}"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Release}\{#Exe}.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "{#Release}\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\.env"; DestDir: "{app}"; Flags: ignoreversion
Source: "..\Docs\MANUAL_USUARIO.pdf"; DestDir: "{app}"; DestName: "Manual de uso.pdf"; Flags: ignoreversion

[Icons]
Name: "{group}\{#Nombre}"; Filename: "{app}\{#Exe}"
Name: "{group}\Manual de uso"; Filename: "{app}\Manual de uso.pdf"
Name: "{autodesktop}\{#Nombre}"; Filename: "{app}\{#Exe}"; Tasks: escritorio

[Run]
Filename: "{app}\{#Exe}"; Description: "Abrir {#Nombre}"; Flags: nowait postinstall skipifsilent
